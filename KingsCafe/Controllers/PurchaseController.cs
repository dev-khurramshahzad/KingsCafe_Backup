using KingsCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingsCafe.Controllers
{
    public class PurchaseController : Controller
    {

        dbKingsCafeEntities db = new dbKingsCafeEntities();
        // GET: Purchase
        public ActionResult AllIngredients()
        {
            var p= db.tblIngredients.ToList();
            return View(p);
        }
        public ActionResult Displaycart()
        {
           
            return View();
        }
        public ActionResult Addtocart(int id, int qty)

        {
            List<tblIngredient> list = new List<tblIngredient>();
            tblIngredient tblIngredient1 = new tblIngredient();
            if (Session["Cart"] != null)
            {
                list = (List<tblIngredient>)Session["Cart"];
            }

            tblIngredient1 = list.Where(x => x.INGREDIENT_ID == id).FirstOrDefault();

            if (tblIngredient1 == null)
            {
                tblIngredient1 = db.tblIngredients.Where(x => x.INGREDIENT_ID == id).FirstOrDefault();
                tblIngredient1.Quantity = 1;
                list.Add(tblIngredient1);
            }
            else
            {
                tblIngredient1.Quantity+=qty;
            }

            Session["purchasecart"] = list;
            return RedirectToAction("Displaycart");
        }
    }
}