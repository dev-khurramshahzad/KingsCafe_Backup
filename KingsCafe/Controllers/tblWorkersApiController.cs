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
    public class tblWorkersApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblWorkersApi
        public IQueryable<tblWorker> GettblWorkers()
        {
            return db.tblWorkers;
        }

        // GET: api/tblWorkersApi/5
        [ResponseType(typeof(tblWorker))]
        public IHttpActionResult GettblWorker(int id)
        {
            tblWorker tblWorker = db.tblWorkers.Find(id);
            if (tblWorker == null)
            {
                return NotFound();
            }

            return Ok(tblWorker);
        }

        // PUT: api/tblWorkersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblWorker(int id, tblWorker tblWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblWorker.WORKER_ID)
            {
                return BadRequest();
            }

            db.Entry(tblWorker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblWorkerExists(id))
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

        // POST: api/tblWorkersApi
        [ResponseType(typeof(tblWorker))]
        public IHttpActionResult PosttblWorker(tblWorker tblWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblWorkers.Add(tblWorker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblWorker.WORKER_ID }, tblWorker);
        }

        // DELETE: api/tblWorkersApi/5
        [ResponseType(typeof(tblWorker))]
        public IHttpActionResult DeletetblWorker(int id)
        {
            tblWorker tblWorker = db.tblWorkers.Find(id);
            if (tblWorker == null)
            {
                return NotFound();
            }

            db.tblWorkers.Remove(tblWorker);
            db.SaveChanges();

            return Ok(tblWorker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblWorkerExists(int id)
        {
            return db.tblWorkers.Count(e => e.WORKER_ID == id) > 0;
        }
    }
}