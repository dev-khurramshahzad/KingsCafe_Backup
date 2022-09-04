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
    public class tblOrderPurchaseDetailApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblOrderPurchaseDetailApi
        public IQueryable<tblOrderPurchaseDetail> GettblOrderPurchaseDetails()
        {
            return db.tblOrderPurchaseDetails;
        }

        // GET: api/tblOrderPurchaseDetailApi/5
        [ResponseType(typeof(tblOrderPurchaseDetail))]
        public IHttpActionResult GettblOrderPurchaseDetail(int id)
        {
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            if (tblOrderPurchaseDetail == null)
            {
                return NotFound();
            }

            return Ok(tblOrderPurchaseDetail);
        }

        // PUT: api/tblOrderPurchaseDetailApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrderPurchaseDetail(int id, tblOrderPurchaseDetail tblOrderPurchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrderPurchaseDetail.ORDER_PURCHASE_DETAIL_ID)
            {
                return BadRequest();
            }

            db.Entry(tblOrderPurchaseDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderPurchaseDetailExists(id))
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

        // POST: api/tblOrderPurchaseDetailApi
        [ResponseType(typeof(tblOrderPurchaseDetail))]
        public IHttpActionResult PosttblOrderPurchaseDetail(tblOrderPurchaseDetail tblOrderPurchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOrderPurchaseDetails.Add(tblOrderPurchaseDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOrderPurchaseDetail.ORDER_PURCHASE_DETAIL_ID }, tblOrderPurchaseDetail);
        }

        // DELETE: api/tblOrderPurchaseDetailApi/5
        [ResponseType(typeof(tblOrderPurchaseDetail))]
        public IHttpActionResult DeletetblOrderPurchaseDetail(int id)
        {
            tblOrderPurchaseDetail tblOrderPurchaseDetail = db.tblOrderPurchaseDetails.Find(id);
            if (tblOrderPurchaseDetail == null)
            {
                return NotFound();
            }

            db.tblOrderPurchaseDetails.Remove(tblOrderPurchaseDetail);
            db.SaveChanges();

            return Ok(tblOrderPurchaseDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderPurchaseDetailExists(int id)
        {
            return db.tblOrderPurchaseDetails.Count(e => e.ORDER_PURCHASE_DETAIL_ID == id) > 0;
        }
    }
}