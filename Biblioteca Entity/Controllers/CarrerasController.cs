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
    public class CarrerasController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Carreras
        public IQueryable<Carreras> GetCarreras()
        {
            return db.Carreras;
        }

        // GET: api/Carreras/5
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult GetCarreras(int id)
        {
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return NotFound();
            }

            return Ok(carreras);
        }

        // PUT: api/Carreras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarreras(int id, Carreras carreras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carreras.id_carreras)
            {
                return BadRequest();
            }

            db.Entry(carreras).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrerasExists(id))
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

        // POST: api/Carreras
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult PostCarreras(Carreras carreras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carreras.Add(carreras);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CarrerasExists(carreras.id_carreras))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = carreras.id_carreras }, carreras);
        }

        // DELETE: api/Carreras/5
        [ResponseType(typeof(Carreras))]
        public IHttpActionResult DeleteCarreras(int id)
        {
            Carreras carreras = db.Carreras.Find(id);
            if (carreras == null)
            {
                return NotFound();
            }

            db.Carreras.Remove(carreras);
            db.SaveChanges();

            return Ok(carreras);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarrerasExists(int id)
        {
            return db.Carreras.Count(e => e.id_carreras == id) > 0;
        }
    }
}