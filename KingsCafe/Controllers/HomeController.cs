using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KingsCafe.Models;
namespace KingsCafe.Controllers
{
    public class HomeController : Controller
    {
        dbKingsCafeEntities db = new dbKingsCafeEntities();
       
        public ActionResult indexAdmin()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }
        public ActionResult indexworker()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult login(tblAdmin Admin)
        {

            tblAdmin admin = db.tblAdmins.Where(x => x.ADMIN_EMAIL == Admin.ADMIN_EMAIL
           && x.ADMIN_PASSWORD == Admin.ADMIN_PASSWORD).FirstOrDefault();
            if (Admin != null)
            {
                CurrentAdmin.Current_Admin = Admin;
                return RedirectToAction("indexAdmin");
            }
            else
            {
                TempData["error"] = " Invalid Email and Password!! ";
                return View();
            }
        }

        public ActionResult about()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        public ActionResult contactus(tblfeedback feedback)
        {
            //if (ModelState.IsValid)
            //{
                db.tblfeedbacks.Add(feedback);
                db.SaveChanges();
                TempData["msg"] = " Thanks for Contact us ";
              
            //}
            return RedirectToAction("index");
        }
        public ActionResult Menu(int? id)
        {
            if (id != null) 
            { 
            ViewData["catid"] = id;
            }
            return View();
        }
        public ActionResult ChangeIngredient(int id)
        {
          
            var c = db.tblIngredientLinkings.Where(x => x.FOOD_PRODUCTS_FID == id).ToList();

            return View(c);
        }
    }
}