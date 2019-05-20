//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using Pmbok.DomainClasses.Models;
//using Pmbok.ModelsOld;

//namespace Pseez.UI.Pmbok.Areas.WebApi.Controllers
//{
//    public class ProjectDocumentValuesController : ApiController
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: api/ProjectDocumentValues
//        public IQueryable<ProjectDocumentValue> GetProjectDocumentValues()
//        {
//            return db.ProjectDocumentValues;
//        }

//        // GET: api/ProjectDocumentValues/5
//        [ResponseType(typeof(ProjectDocumentValue))]
//        public IHttpActionResult GetProjectDocumentValue(int id)
//        {
//            ProjectDocumentValue projectDocumentValue = db.ProjectDocumentValues.Find(id);
//            if (projectDocumentValue == null)
//            {
//                return NotFound();
//            }

//            return Ok(projectDocumentValue);
//        }

//        // PUT: api/ProjectDocumentValues/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutProjectDocumentValue(int id, ProjectDocumentValue projectDocumentValue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != projectDocumentValue.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(projectDocumentValue).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ProjectDocumentValueExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/ProjectDocumentValues
//        [ResponseType(typeof(ProjectDocumentValue))]
//        public IHttpActionResult PostProjectDocumentValue(ProjectDocumentValue projectDocumentValue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.ProjectDocumentValues.Add(projectDocumentValue);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = projectDocumentValue.Id }, projectDocumentValue);
//        }

//        // DELETE: api/ProjectDocumentValues/5
//        [ResponseType(typeof(ProjectDocumentValue))]
//        public IHttpActionResult DeleteProjectDocumentValue(int id)
//        {
//            ProjectDocumentValue projectDocumentValue = db.ProjectDocumentValues.Find(id);
//            if (projectDocumentValue == null)
//            {
//                return NotFound();
//            }

//            db.ProjectDocumentValues.Remove(projectDocumentValue);
//            db.SaveChanges();

//            return Ok(projectDocumentValue);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ProjectDocumentValueExists(int id)
//        {
//            return db.ProjectDocumentValues.Count(e => e.Id == id) > 0;
//        }
//    }
//}