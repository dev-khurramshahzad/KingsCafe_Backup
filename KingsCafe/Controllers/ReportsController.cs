using KingsCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingsCafe.Controllers
{
    public class ReportsController : Controller
    {

        dbKingsCafeEntities db = new dbKingsCafeEntities();
        // GET: Reports
        public ActionResult SaleReport(DateTime? ToDate, DateTime? FromDate, int? Category,int? Product)
        {
            ViewBag.Category = new SelectList(db.tblFoodCategories, "FOOD_CATEGORY_ID", "FOOD_CATEGORY_NAME");
            ViewBag.Product = new SelectList(db.tblFoodProducts, "FOOD_PRODUCTS_ID", "FOOD_PRODUCTS_NAME");


            if (FromDate == null)
            {
                FromDate = DateTime.Today;
            }
             if (ToDate == null)
            {
                ToDate = DateTime.Now;
            }

            ViewBag.DateTo = ToDate.Value.ToString("s");
            ViewBag.DateFrom = FromDate.Value.ToString("s");

            var orderlist = new List<tblOrder>();
            db.tblOrders.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE <= ToDate && x.ORDER_DATE >= FromDate).ToList();

            if (Category != null)
            {
                orderlist = db.tblOrders.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE <= ToDate && x.ORDER_DATE >= FromDate).ToList();
                orderlist = orderlist.Where(x => x.tblOrderDetails.Any(z => z.tblFoodProduct.FOOD_CATEGORY_FID == Category)).ToList();     
            }


            if (Product != null)
            {
                orderlist = db.tblOrders.Where(x => x.ORDER_STATUS == "Delivered" && x.ORDER_DATE <= ToDate && x.ORDER_DATE >= FromDate).ToList();
                orderlist = orderlist.Where(x => x.tblOrderDetails.Any(z => z.FOOD_PRODUCTS_FID == Product)).ToList();
            }
           
            return View(orderlist);
        }
    }
}