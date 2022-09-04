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
    public class tblOrderLinkingApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblOrderLinkingApi
        public IQueryable<tblOrderLinking> GettblOrderLinkings()
        {
            return db.tblOrderLinkings;
        }

        // GET: api/tblOrderLinkingApi/5
        [ResponseType(typeof(tblOrderLinking))]
        public IHttpActionResult GettblOrderLinking(int id)
        {
            tblOrderLinking tblOrderLinking = db.tblOrderLinkings.Find(id);
            if (tblOrderLinking == null)
            {
                return NotFound();
            }

            return Ok(tblOrderLinking);
        }

        // PUT: api/tblOrderLinkingApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrderLinking(int id, tblOrderLinking tblOrderLinking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrderLinking.ORDER_LINKING_ID)
            {
                return BadRequest();
            }

            db.Entry(tblOrderLinking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderLinkingExists(id))
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

        // POST: api/tblOrderLinkingApi
        [ResponseType(typeof(tblOrderLinking))]
        public IHttpActionResult PosttblOrderLinking(tblOrderLinking tblOrderLinking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOrderLinkings.Add(tblOrderLinking);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblOrderLinkingExists(tblOrderLinking.ORDER_LINKING_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblOrderLinking.ORDER_LINKING_ID }, tblOrderLinking);
        }

        // DELETE: api/tblOrderLinkingApi/5
        [ResponseType(typeof(tblOrderLinking))]
        public IHttpActionResult DeletetblOrderLinking(int id)
        {
            tblOrderLinking tblOrderLinking = db.tblOrderLinkings.Find(id);
            if (tblOrderLinking == null)
            {
                return NotFound();
            }

            db.tblOrderLinkings.Remove(tblOrderLinking);
            db.SaveChanges();

            return Ok(tblOrderLinking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderLinkingExists(int id)
        {
            return db.tblOrderLinkings.Count(e => e.ORDER_LINKING_ID == id) > 0;
        }
    }
}