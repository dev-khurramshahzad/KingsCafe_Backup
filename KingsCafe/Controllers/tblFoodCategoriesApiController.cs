using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KingsCafe.Models;

namespace KingsCafe.Controllers
{
    public class tblFoodCategoriesApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblFoodCategoriesApi
        public IEnumerable<tblFoodCategory> GettblFoodCategories()
        {
            var data = db.tblFoodCategories.ToList();
            return data;
        }

        // GET: api/tblFoodCategoriesApi/5
        [ResponseType(typeof(tblFoodCategory))]
        public IHttpActionResult GettblFoodCategory(int id)
        {
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            if (tblFoodCategory == null)
            {
                return NotFound();
            }

            return Ok(tblFoodCategory);
        }

        // PUT: api/tblFoodCategoriesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFoodCategory(int id, tblFoodCategory tblFoodCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFoodCategory.FOOD_CATEGORY_ID)
            {
                return BadRequest();
            }

            db.Entry(tblFoodCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFoodCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblFoodCategoriesApi
        [ResponseType(typeof(tblFoodCategory))]
        public IHttpActionResult PosttblFoodCategory(tblFoodCategory tblFoodCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFoodCategories.Add(tblFoodCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFoodCategory.FOOD_CATEGORY_ID }, tblFoodCategory);
        }

        // DELETE: api/tblFoodCategoriesApi/5
        [ResponseType(typeof(tblFoodCategory))]
        public IHttpActionResult DeletetblFoodCategory(int id)
        {
            tblFoodCategory tblFoodCategory = db.tblFoodCategories.Find(id);
            if (tblFoodCategory == null)
            {
                return NotFound();
            }

            db.tblFoodCategories.Remove(tblFoodCategory);
            db.SaveChanges();

            return Ok(tblFoodCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFoodCategoryExists(int id)
        {
            return db.tblFoodCategories.Count(e => e.FOOD_CATEGORY_ID == id) > 0;
        }
    }
}