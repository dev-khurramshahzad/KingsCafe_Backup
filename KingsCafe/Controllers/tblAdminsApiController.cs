﻿using System;
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
    public class tblAdminsApiController : ApiController
    {
        private dbKingsCafeEntities db = new dbKingsCafeEntities();

        // GET: api/tblAdminsApi
        public IQueryable<tblAdmin> GettblAdmins()
        {
            return db.tblAdmins;
        }

        // GET: api/tblAdminsApi/5
        [ResponseType(typeof(tblAdmin))]
        public IHttpActionResult GettblAdmin(int id)
        {
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            if (tblAdmin == null)
            {
                return NotFound();
            }

            return Ok(tblAdmin);
        }

        // PUT: api/tblAdminsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAdmin(int id, tblAdmin tblAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAdmin.ADMIN_ID)
            {
                return BadRequest();
            }

            db.Entry(tblAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblAdmin);
        }

        // POST: api/tblAdminsApi
        [ResponseType(typeof(tblAdmin))]
        public IHttpActionResult PosttblAdmin(tblAdmin tblAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblAdmins.Add(tblAdmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAdmin.ADMIN_ID }, tblAdmin);
        }

        // DELETE: api/tblAdminsApi/5
        [ResponseType(typeof(tblAdmin))]
        public IHttpActionResult DeletetblAdmin(int id)
        {
            tblAdmin tblAdmin = db.tblAdmins.Find(id);
            if (tblAdmin == null)
            {
                return NotFound();
            }

            db.tblAdmins.Remove(tblAdmin);
            db.SaveChanges();

            return Ok(tblAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAdminExists(int id)
        {
            return db.tblAdmins.Count(e => e.ADMIN_ID == id) > 0;
        }
    }
}