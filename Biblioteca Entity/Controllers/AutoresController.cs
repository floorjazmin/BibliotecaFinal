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
    public class AutoresController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Autores
        public IQueryable<autores> Getautores()
        {
            return db.autores;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(autores))]
        public IHttpActionResult Getautores(int id)
        {
            autores autores = db.autores.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            return Ok(autores);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putautores(int id, autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autores.id_autor)
            {
                return BadRequest();
            }

            db.Entry(autores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!autoresExists(id))
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

        // POST: api/Autores
        [ResponseType(typeof(autores))]
        public IHttpActionResult Postautores(autores autores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.autores.Add(autores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (autoresExists(autores.id_autor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autores.id_autor }, autores);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(autores))]
        public IHttpActionResult Deleteautores(int id)
        {
            autores autores = db.autores.Find(id);
            if (autores == null)
            {
                return NotFound();
            }

            db.autores.Remove(autores);
            db.SaveChanges();

            return Ok(autores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool autoresExists(int id)
        {
            return db.autores.Count(e => e.id_autor == id) > 0;
        }
    }
}