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
using TutorAppBak.Models;

namespace TutorAppBak.Controllers.Api
{
    public class TutorsController : ApiController
    {
        private tutorappDBEntities2 db = new tutorappDBEntities2();

        // GET: api/Tutors
        public IQueryable<Tutor> GetTutor()
        {
            return db.Tutor;
        }

        // GET: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult GetTutor(int id)
        {
            Tutor tutor = db.Tutor.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.id)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutor.Add(tutor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tutor.id }, tutor);
        }

        // DELETE: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult DeleteTutor(int id)
        {
            Tutor tutor = db.Tutor.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            db.Tutor.Remove(tutor);
            db.SaveChanges();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return db.Tutor.Count(e => e.id == id) > 0;
        }
    }
}