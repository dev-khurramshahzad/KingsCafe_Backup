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
    public class tblRiderAssigningOrderApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblRiderAssigningOrderApi
        public IQueryable<tblRiderAssigningOrder> GettblRiderAssigningOrders()
        {
            return db.tblRiderAssigningOrders;
        }

        // GET: api/tblRiderAssigningOrderApi/5
        [ResponseType(typeof(tblRiderAssigningOrder))]
        public IHttpActionResult GettblRiderAssigningOrder(int id)
        {
            tblRiderAssigningOrder tblRiderAssigningOrder = db.tblRiderAssigningOrders.Find(id);
            if (tblRiderAssigningOrder == null)
            {
                return NotFound();
            }

            return Ok(tblRiderAssigningOrder);
        }

        // PUT: api/tblRiderAssigningOrderApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblRiderAssigningOrder(int id, tblRiderAssigningOrder tblRiderAssigningOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblRiderAssigningOrder.RIDER_ASSIGNING_ORDER_ID)
            {
                return BadRequest();
            }

            db.Entry(tblRiderAssigningOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblRiderAssigningOrderExists(id))
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

        // POST: api/tblRiderAssigningOrderApi
        [ResponseType(typeof(tblRiderAssigningOrder))]
        public IHttpActionResult PosttblRiderAssigningOrder(tblRiderAssigningOrder tblRiderAssigningOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblRiderAssigningOrders.Add(tblRiderAssigningOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblRiderAssigningOrder.RIDER_ASSIGNING_ORDER_ID }, tblRiderAssigningOrder);
        }

        // DELETE: api/tblRiderAssigningOrderApi/5
        [ResponseType(typeof(tblRiderAssigningOrder))]
        public IHttpActionResult DeletetblRiderAssigningOrder(int id)
        {
            tblRiderAssigningOrder tblRiderAssigningOrder = db.tblRiderAssigningOrders.Find(id);
            if (tblRiderAssigningOrder == null)
            {
                return NotFound();
            }

            db.tblRiderAssigningOrders.Remove(tblRiderAssigningOrder);
            db.SaveChanges();

            return Ok(tblRiderAssigningOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblRiderAssigningOrderExists(int id)
        {
            return db.tblRiderAssigningOrders.Count(e => e.RIDER_ASSIGNING_ORDER_ID == id) > 0;
        }
    }
}