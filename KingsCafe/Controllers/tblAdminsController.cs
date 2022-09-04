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
    public class tblAdminsController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblAdmins
        public ActionResult Index()
        {
            return View(db.tblAdmins.ToList());
        }

        // GET: tblAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            if (tblAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmin);
        }

        // GET: tblAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ADMIN_ID,ADMIN_NAME,ADMIN_EMAIL,ADMIN_PASSWORD,ADMIN_CONTACT,ADMIN_ADDRESS,ADMIN_PICTURE")] tblAdmin tblAdmin)
        {
            if (ModelState.IsValid)
            {
                db.tblAdmins.Add(tblAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAdmin);
        }

        // GET: tblAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            if (tblAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmin);
        }

        // POST: tblAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADMIN_ID,ADMIN_NAME,ADMIN_EMAIL,ADMIN_PASSWORD,ADMIN_CONTACT,ADMIN_ADDRESS,ADMIN_PICTURE")] tblAdmin tblAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAdmin);
        }

        // GET: tblAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            if (tblAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmin);
        }

        // POST: tblAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            db.tblAdmins.Remove(tblAdmin);
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
