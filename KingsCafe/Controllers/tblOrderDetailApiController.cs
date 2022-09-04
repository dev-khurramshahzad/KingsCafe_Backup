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
    public class tblOrderDetailApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblOrderDetailApi
        public IQueryable<tblOrderDetail> GettblOrderDetails()
        {
            return db.tblOrderDetails;
        }

        // GET: api/tblOrderDetailApi/5
        [ResponseType(typeof(tblOrderDetail))]
        public IHttpActionResult GettblOrderDetail(int id)
        {
            tblOrderDetail tblOrderDetail = db.tblOrderDetails.Find(id);
            if (tblOrderDetail == null)
            {
                return NotFound();
            }

            return Ok(tblOrderDetail);
        }

        // PUT: api/tblOrderDetailApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrderDetail(int id, tblOrderDetail tblOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrderDetail.ORDER_DETAILS_ID)
            {
                return BadRequest();
            }

            db.Entry(tblOrderDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderDetailExists(id))
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

        // POST: api/tblOrderDetailApi
        [ResponseType(typeof(tblOrderDetail))]
        public IHttpActionResult PosttblOrderDetail(tblOrderDetail tblOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblOrderDetails.Add(tblOrderDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOrderDetail.ORDER_DETAILS_ID }, tblOrderDetail);
        }

        // DELETE: api/tblOrderDetailApi/5
        [ResponseType(typeof(tblOrderDetail))]
        public IHttpActionResult DeletetblOrderDetail(int id)
        {
            tblOrderDetail tblOrderDetail = db.tblOrderDetails.Find(id);
            if (tblOrderDetail == null)
            {
                return NotFound();
            }

            db.tblOrderDetails.Remove(tblOrderDetail);
            db.SaveChanges();

            return Ok(tblOrderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderDetailExists(int id)
        {
            return db.tblOrderDetails.Count(e => e.ORDER_DETAILS_ID == id) > 0;
        }
    }
}