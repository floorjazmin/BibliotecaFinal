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
    public class Libros_AlumnosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Libros_Alumnos
        public IQueryable<Libros_Alumnos> GetLibros_Alumnos()
        {
            return db.Libros_Alumnos;
        }

        // GET: api/Libros_Alumnos/5
        [ResponseType(typeof(Libros_Alumnos))]
        public IHttpActionResult GetLibros_Alumnos(int id)
        {
            Libros_Alumnos libros_Alumnos = db.Libros_Alumnos.Find(id);
            if (libros_Alumnos == null)
            {
                return NotFound();
            }

            return Ok(libros_Alumnos);
        }

        // PUT: api/Libros_Alumnos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLibros_Alumnos(int id, Libros_Alumnos libros_Alumnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libros_Alumnos.id_isbn)
            {
                return BadRequest();
            }

            db.Entry(libros_Alumnos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Libros_AlumnosExists(id))
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

        // POST: api/Libros_Alumnos
        [ResponseType(typeof(Libros_Alumnos))]
        public IHttpActionResult PostLibros_Alumnos(Libros_Alumnos libros_Alumnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Libros_Alumnos.Add(libros_Alumnos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Libros_AlumnosExists(libros_Alumnos.id_isbn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = libros_Alumnos.id_isbn }, libros_Alumnos);
        }

        // DELETE: api/Libros_Alumnos/5
        [ResponseType(typeof(Libros_Alumnos))]
        public IHttpActionResult DeleteLibros_Alumnos(int id)
        {
            Libros_Alumnos libros_Alumnos = db.Libros_Alumnos.Find(id);
            if (libros_Alumnos == null)
            {
                return NotFound();
            }

            db.Libros_Alumnos.Remove(libros_Alumnos);
            db.SaveChanges();

            return Ok(libros_Alumnos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Libros_AlumnosExists(int id)
        {
            return db.Libros_Alumnos.Count(e => e.id_isbn == id) > 0;
        }
    }
}