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
    public class DetallesLibrosController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/DetallesLibros
        public IQueryable<DetallesLibros> GetDetallesLibros()
        {
            return db.DetallesLibros;
        }

        // GET: api/DetallesLibros/5
        [ResponseType(typeof(DetallesLibros))]
        public IHttpActionResult GetDetallesLibros(int id)
        {
            DetallesLibros detallesLibros = db.DetallesLibros.Find(id);
            if (detallesLibros == null)
            {
                return NotFound();
            }

            return Ok(detallesLibros);
        }

        // PUT: api/DetallesLibros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetallesLibros(int id, DetallesLibros detallesLibros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallesLibros.Id_Detalle_Libro)
            {
                return BadRequest();
            }

            db.Entry(detallesLibros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesLibrosExists(id))
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

        // POST: api/DetallesLibros
        [ResponseType(typeof(DetallesLibros))]
        public IHttpActionResult PostDetallesLibros(DetallesLibros detallesLibros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallesLibros.Add(detallesLibros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DetallesLibrosExists(detallesLibros.Id_Detalle_Libro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detallesLibros.Id_Detalle_Libro }, detallesLibros);
        }

        // DELETE: api/DetallesLibros/5
        [ResponseType(typeof(DetallesLibros))]
        public IHttpActionResult DeleteDetallesLibros(int id)
        {
            DetallesLibros detallesLibros = db.DetallesLibros.Find(id);
            if (detallesLibros == null)
            {
                return NotFound();
            }

            db.DetallesLibros.Remove(detallesLibros);
            db.SaveChanges();

            return Ok(detallesLibros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallesLibrosExists(int id)
        {
            return db.DetallesLibros.Count(e => e.Id_Detalle_Libro == id) > 0;
        }
    }
}