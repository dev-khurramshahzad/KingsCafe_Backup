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
    public class tblOrderApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblOrderApi
        public IQueryable<tblOrder> GettblOrders()
        {
            return db.tblOrders;
        }

        // GET: api/tblOrderApi/5
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult GettblOrder(int id)
        {
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            return Ok(tblOrder);
        }

        // PUT: api/tblOrderApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrder(int id, tblOrder tblOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrder.ORDER_ID)
            {
                return BadRequest();
            }

            db.Entry(tblOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderExists(id))
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

        // POST: api/tblOrderApi
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult PosttblOrder(tblOrder tblOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOrders.Add(tblOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOrder.ORDER_ID }, tblOrder);
        }

        // DELETE: api/tblOrderApi/5
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult DeletetblOrder(int id)
        {
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            db.tblOrders.Remove(tblOrder);
            db.SaveChanges();

            return Ok(tblOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderExists(int id)
        {
            return db.tblOrders.Count(e => e.ORDER_ID == id) > 0;
        }
    }
}