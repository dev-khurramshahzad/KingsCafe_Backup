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
    public class tblWorkerDetailApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblWorkerDetailApi
        public IQueryable<tblWorkerDetail> GettblWorkerDetails()
        {
            return db.tblWorkerDetails;
        }

        // GET: api/tblWorkerDetailApi/5
        [ResponseType(typeof(tblWorkerDetail))]
        public IHttpActionResult GettblWorkerDetail(int id)
        {
            tblWorkerDetail tblWorkerDetail = db.tblWorkerDetails.Find(id);
            if (tblWorkerDetail == null)
            {
                return NotFound();
            }

            return Ok(tblWorkerDetail);
        }

        // PUT: api/tblWorkerDetailApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblWorkerDetail(int id, tblWorkerDetail tblWorkerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblWorkerDetail.WORKER_DETAIL_ID)
            {
                return BadRequest();
            }

            db.Entry(tblWorkerDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblWorkerDetailExists(id))
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

        // POST: api/tblWorkerDetailApi
        [ResponseType(typeof(tblWorkerDetail))]
        public IHttpActionResult PosttblWorkerDetail(tblWorkerDetail tblWorkerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblWorkerDetails.Add(tblWorkerDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblWorkerDetail.WORKER_DETAIL_ID }, tblWorkerDetail);
        }

        // DELETE: api/tblWorkerDetailApi/5
        [ResponseType(typeof(tblWorkerDetail))]
        public IHttpActionResult DeletetblWorkerDetail(int id)
        {
            tblWorkerDetail tblWorkerDetail = db.tblWorkerDetails.Find(id);
            if (tblWorkerDetail == null)
            {
                return NotFound();
            }

            db.tblWorkerDetails.Remove(tblWorkerDetail);
            db.SaveChanges();

            return Ok(tblWorkerDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblWorkerDetailExists(int id)
        {
            return db.tblWorkerDetails.Count(e => e.WORKER_DETAIL_ID == id) > 0;
        }
    }
}