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
    public class tblIngredientsController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblIngredients
        public ActionResult Index()
        {
            return View(db.tblIngredients.ToList());
        }

        // GET: tblIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            if (tblIngredient == null)
            {
                return HttpNotFound();
            }
            return View(tblIngredient);
        }

        // GET: tblIngredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblIngredient tblIngredient)
        {
            if (ModelState.IsValid)
            {
                db.tblIngredients.Add(tblIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblIngredient);
        }

        // GET: tblIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            if (tblIngredient == null)
            {
                return HttpNotFound();
            }
            return View(tblIngredient);
        }

        // POST: tblIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblIngredient tblIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblIngredient);
        }

        // GET: tblIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            if (tblIngredient == null)
            {
                return HttpNotFound();
            }
            return View(tblIngredient);
        }

        // POST: tblIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            db.tblIngredients.Remove(tblIngredient);
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
