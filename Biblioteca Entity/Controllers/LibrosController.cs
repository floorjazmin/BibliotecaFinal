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
    public class LibrosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Libros
        public IQueryable<Libros> GetLibros()
        {
            return db.Libros;
        }

        // GET: api/Libros/5
        [ResponseType(typeof(Libros))]
        public IHttpActionResult GetLibros(int id)
        {
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return NotFound();
            }

            return Ok(libros);
        }

        // PUT: api/Libros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLibros(int id, Libros libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libros.id_isbn)
            {
                return BadRequest();
            }

            db.Entry(libros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrosExists(id))
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

        // POST: api/Libros
        [ResponseType(typeof(Libros))]
        public IHttpActionResult PostLibros(Libros libros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Libros.Add(libros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LibrosExists(libros.id_isbn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = libros.id_isbn }, libros);
        }

        // DELETE: api/Libros/5
        [ResponseType(typeof(Libros))]
        public IHttpActionResult DeleteLibros(int id)
        {
            Libros libros = db.Libros.Find(id);
            if (libros == null)
            {
                return NotFound();
            }

            db.Libros.Remove(libros);
            db.SaveChanges();

            return Ok(libros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibrosExists(int id)
        {
            return db.Libros.Count(e => e.id_isbn == id) > 0;
        }
    }
}