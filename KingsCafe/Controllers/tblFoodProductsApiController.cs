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
    public class tblFoodProductsApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblFoodProductsApi
        public IQueryable<tblFoodProduct> GettblFoodProducts()
        {
            return db.tblFoodProducts;
        }

        // GET: api/tblFoodProductsApi/5
        [ResponseType(typeof(tblFoodProduct))]
        public IHttpActionResult GettblFoodProduct(int id)
        {
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            if (tblFoodProduct == null)
            {
                return NotFound();
            }

            return Ok(tblFoodProduct);
        }

        // PUT: api/tblFoodProductsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFoodProduct(int id, tblFoodProduct tblFoodProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFoodProduct.FOOD_PRODUCTS_ID)
            {
                return BadRequest();
            }

            db.Entry(tblFoodProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFoodProductExists(id))
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

        // POST: api/tblFoodProductsApi
        [ResponseType(typeof(tblFoodProduct))]
        public IHttpActionResult PosttblFoodProduct(tblFoodProduct tblFoodProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFoodProducts.Add(tblFoodProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFoodProduct.FOOD_PRODUCTS_ID }, tblFoodProduct);
        }

        // DELETE: api/tblFoodProductsApi/5
        [ResponseType(typeof(tblFoodProduct))]
        public IHttpActionResult DeletetblFoodProduct(int id)
        {
            tblFoodProduct tblFoodProduct = db.tblFoodProducts.Find(id);
            if (tblFoodProduct == null)
            {
                return NotFound();
            }

            db.tblFoodProducts.Remove(tblFoodProduct);
            db.SaveChanges();

            return Ok(tblFoodProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFoodProductExists(int id)
        {
            return db.tblFoodProducts.Count(e => e.FOOD_PRODUCTS_ID == id) > 0;
        }
    }
}