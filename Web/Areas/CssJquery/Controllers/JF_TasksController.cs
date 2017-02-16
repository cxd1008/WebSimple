using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Model;

namespace Web.Areas.CssJquery.Controllers
{
    public class JF_TasksController : ApiController
    {
        private WebMvcEntities db = new WebMvcEntities();

        // GET: api/JF_Tasks
        public IQueryable<JF_Tasks> GetJF_Tasks()
        {
            return db.JF_Tasks;
        }

        // GET: api/JF_Tasks/5
        [ResponseType(typeof(JF_Tasks))]
        public async Task< JF_Tasks> GetJF_Tasks(Guid id)
        {
            JF_Tasks jF_Tasks = await db.JF_Tasks.FindAsync(id);            
            return jF_Tasks;
        }

        // PUT: api/JF_Tasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJF_Tasks(Guid id, JF_Tasks jF_Tasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jF_Tasks.TasksID)
            {
                return BadRequest();
            }

            db.Entry(jF_Tasks).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JF_TasksExists(id))
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

        // POST: api/JF_Tasks
        [ResponseType(typeof(JF_Tasks))]
        public async Task<IHttpActionResult> PostJF_Tasks(JF_Tasks jF_Tasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JF_Tasks.Add(jF_Tasks);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JF_TasksExists(jF_Tasks.TasksID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jF_Tasks.TasksID }, jF_Tasks);
        }

        // DELETE: api/JF_Tasks/5
        [ResponseType(typeof(JF_Tasks))]
        public async Task<IHttpActionResult> DeleteJF_Tasks(Guid id)
        {
            JF_Tasks jF_Tasks = await db.JF_Tasks.FindAsync(id);
            if (jF_Tasks == null)
            {
                return NotFound();
            }

            db.JF_Tasks.Remove(jF_Tasks);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JF_TasksExists(Guid id)
        {
            return db.JF_Tasks.Count(e => e.TasksID == id) > 0;
        }
    }
}