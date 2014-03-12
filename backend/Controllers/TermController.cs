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
using backend.Models;
using backend.DAL;

namespace backend.Controllers
{
    public class TermController : ApiController
    {
        private OptionSelectionContext db = new OptionSelectionContext();

        // GET api/Term
        public IQueryable<Term> GetTerms()
        {
            return db.Terms;
        }

        // GET api/Term/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult GetTerm(int id)
        {
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            return Ok(term);
        }

        // PUT api/Term/5
        public IHttpActionResult PutTerm(int id, Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != term.Code)
            {
                return BadRequest();
            }

            db.Entry(term).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermExists(id))
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

        // POST api/Term
        [ResponseType(typeof(Term))]
        public IHttpActionResult PostTerm(Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Terms.Add(term);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = term.Code }, term);
        }

        // DELETE api/Term/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult DeleteTerm(int id)
        {
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            db.Terms.Remove(term);
            db.SaveChanges();

            return Ok(term);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermExists(int id)
        {
            return db.Terms.Count(e => e.Code == id) > 0;
        }
    }
}