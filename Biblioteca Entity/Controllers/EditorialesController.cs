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
    public class EditorialesController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/Editoriales
        public IQueryable<Editoriales> GetEditoriales()
        {
            return db.Editoriales;
        }

        // GET: api/Editoriales/5
        [ResponseType(typeof(Editoriales))]
        public IHttpActionResult GetEditoriales(int id)
        {
            Editoriales editoriales = db.Editoriales.Find(id);
            if (editoriales == null)
            {
                return NotFound();
            }

            return Ok(editoriales);
        }

        // PUT: api/Editoriales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEditoriales(int id, Editoriales editoriales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editoriales.Id_Editorial)
            {
                return BadRequest();
            }

            db.Entry(editoriales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialesExists(id))
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

        // POST: api/Editoriales
        [ResponseType(typeof(Editoriales))]
        public IHttpActionResult PostEditoriales(Editoriales editoriales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Editoriales.Add(editoriales);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EditorialesExists(editoriales.Id_Editorial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = editoriales.Id_Editorial }, editoriales);
        }

        // DELETE: api/Editoriales/5
        [ResponseType(typeof(Editoriales))]
        public IHttpActionResult DeleteEditoriales(int id)
        {
            Editoriales editoriales = db.Editoriales.Find(id);
            if (editoriales == null)
            {
                return NotFound();
            }

            db.Editoriales.Remove(editoriales);
            db.SaveChanges();

            return Ok(editoriales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditorialesExists(int id)
        {
            return db.Editoriales.Count(e => e.Id_Editorial == id) > 0;
        }
    }
}