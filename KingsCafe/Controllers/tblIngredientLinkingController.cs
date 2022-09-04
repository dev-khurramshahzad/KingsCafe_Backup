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
    public class tblIngredientLinkingController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblIngredientLinking
        public ActionResult Index()
        {
            var tblIngredientLinkings = db.tblIngredientLinkings.Include(t => t.tblFoodProduct).Include(t => t.tblIngredient);
            return View(tblIngredientLinkings.ToList());
        }

        // GET: tblIngredientLinking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            if (tblIngredientLinking == null)
            {
                return HttpNotFound();
            }
            return View(tblIngredientLinking);
        }

        // GET: tblIngredientLinking/Create
        public ActionResult Create()
        {
            ViewBag.FOOD_PRODUCTS_FID = new SelectList(db.tblFoodProducts, "FOOD_PRODUCTS_ID", "FOOD_PRODUCTS_NAME");
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME");
            return View();
        }

        // POST: tblIngredientLinking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INGREDIENT_LINKING_ID,FOOD_PRODUCTS_FID,INGREDIENT_FID,INGREDIENT_LINKING_QUANTITY")] tblIngredientLinking tblIngredientLinking)
        {
            if (ModelState.IsValid)
            {
                db.tblIngredientLinkings.Add(tblIngredientLinking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FOOD_PRODUCTS_FID = new SelectList(db.tblFoodProducts, "FOOD_PRODUCTS_ID", "FOOD_PRODUCTS_NAME", tblIngredientLinking.FOOD_PRODUCTS_FID);
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblIngredientLinking.INGREDIENT_FID);
            return View(tblIngredientLinking);
        }

        // GET: tblIngredientLinking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            if (tblIngredientLinking == null)
            {
                return HttpNotFound();
            }
            ViewBag.FOOD_PRODUCTS_FID = new SelectList(db.tblFoodProducts, "FOOD_PRODUCTS_ID", "FOOD_PRODUCTS_NAME", tblIngredientLinking.FOOD_PRODUCTS_FID);
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblIngredientLinking.INGREDIENT_FID);
            return View(tblIngredientLinking);
        }

        // POST: tblIngredientLinking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INGREDIENT_LINKING_ID,FOOD_PRODUCTS_FID,INGREDIENT_FID,INGREDIENT_LINKING_QUANTITY")] tblIngredientLinking tblIngredientLinking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIngredientLinking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FOOD_PRODUCTS_FID = new SelectList(db.tblFoodProducts, "FOOD_PRODUCTS_ID", "FOOD_PRODUCTS_NAME", tblIngredientLinking.FOOD_PRODUCTS_FID);
            ViewBag.INGREDIENT_FID = new SelectList(db.tblIngredients, "INGREDIENT_ID", "INGREDIENT_NAME", tblIngredientLinking.INGREDIENT_FID);
            return View(tblIngredientLinking);
        }

        // GET: tblIngredientLinking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            if (tblIngredientLinking == null)
            {
                return HttpNotFound();
            }
            return View(tblIngredientLinking);
        }

        // POST: tblIngredientLinking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            db.tblIngredientLinkings.Remove(tblIngredientLinking);
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
