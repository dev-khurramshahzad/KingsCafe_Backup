using KingsCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingsCafe.Controllers
{
    public class CartController : Controller
    {
        dbKingsCafeEntities db = new dbKingsCafeEntities();
        // GET: Cart

        public ActionResult Displaycart()
        {
            return View();
        } 
        public ActionResult Ordercomplete()
        {
            return View();
        } 
        public ActionResult OrderBooked(tblOrder order)
        {

            order.ORDER_STATUS = "Booked";
            order.ORDER_DATE = System.DateTime.Now;
   
            db.tblOrders.Add(order);
            db.SaveChanges();

            
            foreach (var item in (List<tblFoodProduct>)Session["cart"])
            {
                tblOrderDetail od = new tblOrderDetail();

                od.FOOD_PRODUCTS_FID = item.FOOD_PRODUCTS_ID;
                od.ORDER_DETAILS_PRICE = item.FOOD_PRODUCTS_PRICE;
                od.ORDER_DETAILS_QUANTITY = item.Quantity;
                od.ORDER_FID= order.ORDER_ID;
                //od.ORDER_DETAILS_isAdding = "false";
                db.tblOrderDetails.Add(od);
                db.SaveChanges();
            }

            TempData["cart"] = Session["cart"];
            Session["cart"] = null;
            return RedirectToAction("Ordercomplete");
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Removefromcart(int id)
        {
            List<tblFoodProduct> tblFoodProductslist = new List<tblFoodProduct>();
            if (Session["Cart"] != null)
            {
                tblFoodProductslist = (List<tblFoodProduct>)Session["Cart"];
            }
            tblFoodProductslist.RemoveAt(id);
            Session["Cart"] = tblFoodProductslist;
            return RedirectToAction("Displaycart");
        }
        public ActionResult Addtocart(int id)

        {
            List<tblFoodProduct> list = new List<tblFoodProduct>();
            tblFoodProduct tblFoodProduct1 = new tblFoodProduct();
            if (Session["Cart"]!=null)
            {
                list = (List<tblFoodProduct>)Session["Cart"];
            }

                tblFoodProduct1=list.Where(x=>x.FOOD_PRODUCTS_ID==id).FirstOrDefault();
            
            if (tblFoodProduct1==null)
            {
                tblFoodProduct1 = db.tblFoodProducts.Where(x => x.FOOD_PRODUCTS_ID == id).FirstOrDefault();
                tblFoodProduct1.Quantity = 1;
                list.Add(tblFoodProduct1);
            }
            else
            {
                tblFoodProduct1.Quantity++;
            }
            
            Session["cart"] = list;
            return RedirectToAction("menu","home");
        }
        public ActionResult Plustocart(int id)
        {
            List<tblFoodProduct> tblFoodProductslist = new List<tblFoodProduct>();
            if (Session["Cart"] != null)
            {
                tblFoodProductslist = (List<tblFoodProduct>)Session["Cart"];
            }
            tblFoodProductslist[id].Quantity++;
            Session["Cart"] = tblFoodProductslist;
            return RedirectToAction("DisplayCart");
        }
       
        public ActionResult Minusfromcart(int id)
        {
            List<tblFoodProduct> tblFoodProductslist = new List<tblFoodProduct>();
            if (Session["Cart"] != null)
            {
                tblFoodProductslist = (List<tblFoodProduct>)Session["Cart"];
            }
            tblFoodProductslist[id].Quantity--;
            if (tblFoodProductslist[id].Quantity < 1)
            {
                tblFoodProductslist.RemoveAt(id);
            }
            Session["Cart"] = tblFoodProductslist;
            return RedirectToAction("DisplayCart");
        }
    }
}