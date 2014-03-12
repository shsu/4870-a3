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
    public class OptionController : ApiController
    {
        private OptionSelectionContext db = new OptionSelectionContext();

        // GET api/Option
        public IQueryable<Option> GetOptions()
        {
            return db.Options;
        }

        // GET api/Option/5
        [ResponseType(typeof(Option))]
        public IHttpActionResult GetOption(int id)
        {
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // PUT api/Option/5
        public IHttpActionResult PutOption(int id, Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.Id)
            {
                return BadRequest();
            }

            db.Entry(option).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST api/Option
        [ResponseType(typeof(Option))]
        public IHttpActionResult PostOption(Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Options.Add(option);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = option.Id }, option);
        }

        // DELETE api/Option/5
        [ResponseType(typeof(Option))]
        public IHttpActionResult DeleteOption(int id)
        {
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }

            db.Options.Remove(option);
            db.SaveChanges();

            return Ok(option);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OptionExists(int id)
        {
            return db.Options.Count(e => e.Id == id) > 0;
        }
    }
}