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
    public class tblfeedbackApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblfeedbackApi
        public IQueryable<tblfeedback> Gettblfeedbacks()
        {
            return db.tblfeedbacks;
        }

        // GET: api/tblfeedbackApi/5
        [ResponseType(typeof(tblfeedback))]
        public IHttpActionResult Gettblfeedback(int id)
        {
            tblfeedback tblfeedback = db.tblfeedbacks.Find(id);
            if (tblfeedback == null)
            {
                return NotFound();
            }

            return Ok(tblfeedback);
        }

        // PUT: api/tblfeedbackApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttblfeedback(int id, tblfeedback tblfeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblfeedback.FEEDBACK_ID)
            {
                return BadRequest();
            }

            db.Entry(tblfeedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblfeedbackExists(id))
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

        // POST: api/tblfeedbackApi
        [ResponseType(typeof(tblfeedback))]
        public IHttpActionResult Posttblfeedback(tblfeedback tblfeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblfeedbacks.Add(tblfeedback);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblfeedback.FEEDBACK_ID }, tblfeedback);
        }

        // DELETE: api/tblfeedbackApi/5
        [ResponseType(typeof(tblfeedback))]
        public IHttpActionResult Deletetblfeedback(int id)
        {
            tblfeedback tblfeedback = db.tblfeedbacks.Find(id);
            if (tblfeedback == null)
            {
                return NotFound();
            }

            db.tblfeedbacks.Remove(tblfeedback);
            db.SaveChanges();

            return Ok(tblfeedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblfeedbackExists(int id)
        {
            return db.tblfeedbacks.Count(e => e.FEEDBACK_ID == id) > 0;
        }
    }
}