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
    public class tblIngredientsApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();
        // GET: api/tblIngredientsApi
        public IQueryable<tblIngredient> GettblIngredients()
        {
            return db.tblIngredients;
        }

        // GET: api/tblIngredientsApi/5
        [ResponseType(typeof(tblIngredient))]
        public IHttpActionResult GettblIngredient(int id)
        {
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            if (tblIngredient == null)
            {
                return NotFound();
            }

            return Ok(tblIngredient);
        }

        // PUT: api/tblIngredientsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblIngredient(int id, tblIngredient tblIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblIngredient.INGREDIENT_ID)
            {
                return BadRequest();
            }

            db.Entry(tblIngredient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblIngredientExists(id))
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

        // POST: api/tblIngredientsApi
        [ResponseType(typeof(tblIngredient))]
        public IHttpActionResult PosttblIngredient(tblIngredient tblIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblIngredients.Add(tblIngredient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblIngredient.INGREDIENT_ID }, tblIngredient);
        }

        // DELETE: api/tblIngredientsApi/5
        [ResponseType(typeof(tblIngredient))]
        public IHttpActionResult DeletetblIngredient(int id)
        {
            tblIngredient tblIngredient = db.tblIngredients.Find(id);
            if (tblIngredient == null)
            {
                return NotFound();
            }

            db.tblIngredients.Remove(tblIngredient);
            db.SaveChanges();

            return Ok(tblIngredient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblIngredientExists(int id)
        {
            return db.tblIngredients.Count(e => e.INGREDIENT_ID == id) > 0;
        }
    }
}