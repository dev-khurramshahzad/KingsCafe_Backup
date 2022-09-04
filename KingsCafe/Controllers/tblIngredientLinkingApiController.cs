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
    public class tblIngredientLinkingApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblIngredientLinkingApi
        public IQueryable<tblIngredientLinking> GettblIngredientLinkings()
        {
            return db.tblIngredientLinkings;
        }

        // GET: api/tblIngredientLinkingApi/5
        [ResponseType(typeof(tblIngredientLinking))]
        public IHttpActionResult GettblIngredientLinking(int id)
        {
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            if (tblIngredientLinking == null)
            {
                return NotFound();
            }

            return Ok(tblIngredientLinking);
        }

        // PUT: api/tblIngredientLinkingApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblIngredientLinking(int id, tblIngredientLinking tblIngredientLinking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblIngredientLinking.INGREDIENT_LINKING_ID)
            {
                return BadRequest();
            }

            db.Entry(tblIngredientLinking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblIngredientLinkingExists(id))
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

        // POST: api/tblIngredientLinkingApi
        [ResponseType(typeof(tblIngredientLinking))]
        public IHttpActionResult PosttblIngredientLinking(tblIngredientLinking tblIngredientLinking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblIngredientLinkings.Add(tblIngredientLinking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblIngredientLinking.INGREDIENT_LINKING_ID }, tblIngredientLinking);
        }

        // DELETE: api/tblIngredientLinkingApi/5
        [ResponseType(typeof(tblIngredientLinking))]
        public IHttpActionResult DeletetblIngredientLinking(int id)
        {
            tblIngredientLinking tblIngredientLinking = db.tblIngredientLinkings.Find(id);
            if (tblIngredientLinking == null)
            {
                return NotFound();
            }

            db.tblIngredientLinkings.Remove(tblIngredientLinking);
            db.SaveChanges();

            return Ok(tblIngredientLinking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblIngredientLinkingExists(int id)
        {
            return db.tblIngredientLinkings.Count(e => e.INGREDIENT_LINKING_ID == id) > 0;
        }
    }
}