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
    public class tblOrderPurchaseApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblOrderPurchaseApi
        public IQueryable<tblOrderPurchase> GettblOrderPurchases()
        {
            return db.tblOrderPurchases;
        }

        // GET: api/tblOrderPurchaseApi/5
        [ResponseType(typeof(tblOrderPurchase))]
        public IHttpActionResult GettblOrderPurchase(int id)
        {
            tblOrderPurchase tblOrderPurchase = db.tblOrderPurchases.Find(id);
            if (tblOrderPurchase == null)
            {
                return NotFound();
            }

            return Ok(tblOrderPurchase);
        }

        // PUT: api/tblOrderPurchaseApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrderPurchase(int id, tblOrderPurchase tblOrderPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrderPurchase.ORDER_PURCHASE_ID)
            {
                return BadRequest();
            }

            db.Entry(tblOrderPurchase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderPurchaseExists(id))
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

        // POST: api/tblOrderPurchaseApi
        [ResponseType(typeof(tblOrderPurchase))]
        public IHttpActionResult PosttblOrderPurchase(tblOrderPurchase tblOrderPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOrderPurchases.Add(tblOrderPurchase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOrderPurchase.ORDER_PURCHASE_ID }, tblOrderPurchase);
        }

        // DELETE: api/tblOrderPurchaseApi/5
        [ResponseType(typeof(tblOrderPurchase))]
        public IHttpActionResult DeletetblOrderPurchase(int id)
        {
            tblOrderPurchase tblOrderPurchase = db.tblOrderPurchases.Find(id);
            if (tblOrderPurchase == null)
            {
                return NotFound();
            }

            db.tblOrderPurchases.Remove(tblOrderPurchase);
            db.SaveChanges();

            return Ok(tblOrderPurchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderPurchaseExists(int id)
        {
            return db.tblOrderPurchases.Count(e => e.ORDER_PURCHASE_ID == id) > 0;
        }
    }
}