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
using Biblioteca_Entity.Models.db;

namespace Biblioteca_Entity.Controllers
{
    public class IdiomasController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Idiomas
        public IQueryable<Idiomas> GetIdiomas()
        {
            return db.Idiomas;
        }

        // GET: api/Idiomas/5
        [ResponseType(typeof(Idiomas))]
        public IHttpActionResult GetIdiomas(int id)
        {
            Idiomas idiomas = db.Idiomas.Find(id);
            if (idiomas == null)
            {
                return NotFound();
            }

            return Ok(idiomas);
        }

        // PUT: api/Idiomas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdiomas(int id, Idiomas idiomas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idiomas.Id_idiomas)
            {
                return BadRequest();
            }

            db.Entry(idiomas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomasExists(id))
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

        // POST: api/Idiomas
        [ResponseType(typeof(Idiomas))]
        public IHttpActionResult PostIdiomas(Idiomas idiomas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Idiomas.Add(idiomas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IdiomasExists(idiomas.Id_idiomas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = idiomas.Id_idiomas }, idiomas);
        }

        // DELETE: api/Idiomas/5
        [ResponseType(typeof(Idiomas))]
        public IHttpActionResult DeleteIdiomas(int id)
        {
            Idiomas idiomas = db.Idiomas.Find(id);
            if (idiomas == null)
            {
                return NotFound();
            }

            db.Idiomas.Remove(idiomas);
            db.SaveChanges();

            return Ok(idiomas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdiomasExists(int id)
        {
            return db.Idiomas.Count(e => e.Id_idiomas == id) > 0;
        }
    }
}