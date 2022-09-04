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
    public class tblFoodProductsController : Controller
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: tblFoodProducts
        public ActionResult Index()
        {
            var tblFoodProducts = db.tblFoodProducts.Include(t => t.tblFoodCategory);
            return View(tblFoodProducts.ToList());
        }

        // GET: tblFoodProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            if (tblFoodProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblFoodProduct);
        }

        // GET: tblFoodProducts/Create
        public ActionResult Create()
        {
            ViewBag.FOOD_CATEGORY_FID = new SelectList(db.tblFoodCategories, "FOOD_CATEGORY_ID", "FOOD_CATEGORY_NAME");
            return View();
        }

        // POST: tblFoodProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tblFoodProduct tblFoodProduct,HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/webpics/" + pic.FileName);
            pic.SaveAs(fullpath);
            tblFoodProduct.FOOD_PRODUCTS_PICTURE = "~/content/webpics/" + pic.FileName;
           var res= UploadCloud.firebaseUpload(pic);
            tblFoodProduct.PicLink =  await res;
            if (ModelState.IsValid)
            {
                
                db.tblFoodProducts.Add(tblFoodProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FOOD_CATEGORY_FID = new SelectList(db.tblFoodCategories, "FOOD_CATEGORY_ID", "FOOD_CATEGORY_NAME", tblFoodProduct.FOOD_CATEGORY_FID);
            return View(tblFoodProduct);
        }

        // GET: tblFoodProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            if (tblFoodProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.FOOD_CATEGORY_FID = new SelectList(db.tblFoodCategories, "FOOD_CATEGORY_ID", "FOOD_CATEGORY_NAME", tblFoodProduct.FOOD_CATEGORY_FID);
            return View(tblFoodProduct);
        }

        // POST: tblFoodProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(tblFoodProduct tblFoodProduct, HttpPostedFileBase pic)
        {
            if (pic != null)
            { 
            string fullpath = Server.MapPath("~/content/webpics" + pic.FileName);
            pic.SaveAs(fullpath);
            tblFoodProduct.FOOD_PRODUCTS_PICTURE = "~/content/webpics" + pic.FileName;
                var res = UploadCloud.firebaseUpload(pic);
                tblFoodProduct.PicLink = await res;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblFoodProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FOOD_CATEGORY_FID = new SelectList(db.tblFoodCategories, "FOOD_CATEGORY_ID", "FOOD_CATEGORY_NAME", tblFoodProduct.FOOD_CATEGORY_FID);
            return View(tblFoodProduct);
        }

        // GET: tblFoodProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            if (tblFoodProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblFoodProduct);
        }

        // POST: tblFoodProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            db.tblFoodProducts.Remove(tblFoodProduct);
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
