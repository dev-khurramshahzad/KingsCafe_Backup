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
    public class tblWorkersController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblWorkers
        public ActionResult Index()
        {
            return View(db.tblWorkers.ToList());
        }

        // GET: tblWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorker tblWorker = db.tblWorkers.Find(id);
            if (tblWorker == null)
            {
                return HttpNotFound();
            }
            return View(tblWorker);
        }

        // GET: tblWorkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WORKER_ID,WORKER_NAME,WORKER_EMAIL,WORKER_PASSWORD,WORKER_CONTACT,WORKER_ADDRESS,WORKER_PICTURES")] tblWorker tblWorker)
        {
            if (ModelState.IsValid)
            {
                db.tblWorkers.Add(tblWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblWorker);
        }

        // GET: tblWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorker tblWorker = db.tblWorkers.Find(id);
            if (tblWorker == null)
            {
                return HttpNotFound();
            }
            return View(tblWorker);
        }

        // POST: tblWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WORKER_ID,WORKER_NAME,WORKER_EMAIL,WORKER_PASSWORD,WORKER_CONTACT,WORKER_ADDRESS,WORKER_PICTURES")] tblWorker tblWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblWorker);
        }

        // GET: tblWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorker tblWorker = db.tblWorkers.Find(id);
            if (tblWorker == null)
            {
                return HttpNotFound();
            }
            return View(tblWorker);
        }

        // POST: tblWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWorker tblWorker = db.tblWorkers.Find(id);
            db.tblWorkers.Remove(tblWorker);
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
