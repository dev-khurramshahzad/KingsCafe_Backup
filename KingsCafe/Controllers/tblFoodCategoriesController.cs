using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KingsCafe.Models;
using KingsCafe.Utills;

namespace KingsCafe.Controllers
{
    public class tblFoodCategoriesController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblFoodCategories
        public ActionResult Index()
        {
            return View(db.tblFoodCategories.ToList());
        }

        // GET: tblFoodCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            if (tblFoodCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblFoodCategory);
        }

        // GET: tblFoodCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblFoodCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( tblFoodCategory tblFoodCategory, HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/webpics/" + pic.FileName);
            pic.SaveAs(fullpath);
            tblFoodCategory.FOOD_CATEGORY_PICTURE = "~/content/webpics/" + pic.FileName;
            var res = UploadCloud.firebaseUpload(pic);
            tblFoodCategory.PicLink = await res;
            if (ModelState.IsValid)
            {
                
                db.tblFoodCategories.Add(tblFoodCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFoodCategory);
        }

        // GET: tblFoodCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            if (tblFoodCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblFoodCategory);
        }

        // POST: tblFoodCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tblFoodCategory tblFoodCategory, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/webpics" + pic.FileName);
                pic.SaveAs(fullpath);
                tblFoodCategory.FOOD_CATEGORY_PICTURE = "~/content/webpics" + pic.FileName;
                var res = UploadCloud.firebaseUpload(pic);
                tblFoodCategory.PicLink = await res;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblFoodCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFoodCategory);
        }

        // GET: tblFoodCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            if (tblFoodCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblFoodCategory);
        }

        // POST: tblFoodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            db.tblFoodCategories.Remove(tblFoodCategory);
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
