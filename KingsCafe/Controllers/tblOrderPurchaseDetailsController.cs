using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KingsCafe.Models;

namespace KingsCafe.Controllers
{
    public class tblOrderPurchaseDetailsController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblOrderPurchaseDetails
        public ActionResult Index()
        {
            var tblOrderPurchaseDetails = db.tblOrderPurchaseDetails.Include(t => t.tblIngredient);
            return View(tblOrderPurchaseDetails.ToList());
        }

        // GET: tblOrderPurchaseDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            if (tblOrderPurchaseDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblOrderPurchaseDetail);
        }

        // GET: tblOrderPurchaseDetails/Create
        public ActionResult Create()
        {
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME");
            return View();
        }

        // POST: tblOrderPurchaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDER_PURCHASE_DETAIL_ID,ORDER_PURCHASE_DETAIL_QUANTITY,ORDER_PURCHASE_DETAIL_PRICE,ORDER_PURCHASE_FID,INGREDIENT_FID")] tblOrderPurchaseDetail tblOrderPurchaseDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblOrderPurchaseDetails.Add(tblOrderPurchaseDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblOrderPurchaseDetail.INGREDIENT_FID);
            return View(tblOrderPurchaseDetail);
        }

        // GET: tblOrderPurchaseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            if (tblOrderPurchaseDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblOrderPurchaseDetail.INGREDIENT_FID);
            return View(tblOrderPurchaseDetail);
        }

        // POST: tblOrderPurchaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDER_PURCHASE_DETAIL_ID,ORDER_PURCHASE_DETAIL_QUANTITY,ORDER_PURCHASE_DETAIL_PRICE,ORDER_PURCHASE_FID,INGREDIENT_FID")] tblOrderPurchaseDetail tblOrderPurchaseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrderPurchaseDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblOrderPurchaseDetail.INGREDIENT_FID);
            return View(tblOrderPurchaseDetail);
        }

        // GET: tblOrderPurchaseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            if (tblOrderPurchaseDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblOrderPurchaseDetail);
        }

        // POST: tblOrderPurchaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            db.tblOrderPurchaseDetails.Remove(tblOrderPurchaseDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
