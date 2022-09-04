using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KingsCafe.Models;

namespace KingsCafe.Controllers
{
    public class AdminsideController : Controller
    {

        dbKingsCafeEntities db = new dbKingsCafeEntities();
        // GET: Adminside
        public ActionResult NewOrders()
        {

           var orderlist=  db.tblOrders.Where(x => x.ORDER_STATUS == "Booked").ToList();
            return View(orderlist);
        }
        public ActionResult ProceedOrders()
        {

           var orderlist=  db.tblOrders.Where(x => x.ORDER_STATUS == "Proceed").ToList();
            return View(orderlist);
        }
        public ActionResult DeliveredOrders()
        {

           var orderlist=  db.tblOrders.Where(x => x.ORDER_STATUS == "Delivered").ToList();
            return View(orderlist);
        }
        public ActionResult Invoice(int id)
        {
           var invoicedata=  db.tblOrders.Where(x => x.ORDER_ID == id).FirstOrDefault();
            return View(invoicedata);
        }
        public ActionResult Sendtoproceed(int id)
        {
           var Orderdata=  db.tblOrders.Find(id);
            Orderdata.ORDER_STATUS = "Proceed";
            db.Entry(Orderdata).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "  Your order is " + id + " now in proceed list ";
            return RedirectToAction("NewOrders");
        }
        public ActionResult SendToDelivered(int id)
        {
           var Orderdata=  db.tblOrders.Find(id);
            Orderdata.ORDER_STATUS = "Delivered";
            db.Entry(Orderdata).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = " Your order is " + id + " now in delivered list ";
            return RedirectToAction("ProceedOrders");
        }
    }
}