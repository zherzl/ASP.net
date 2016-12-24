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
using Knockout.Repository.EF.Models;
using Knockout.DataService.Mapping;
using Knockout.DataService.ViewModels;
using System.Web;
using Knockout.DataService.Messaging.Response;

namespace Knockout_EF.Controllers
{
    public class GradoviController : ApiController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: api/Gradovi
        public GradoviResponse GetGradovi()
        {
            GradoviResponse gs = new GradoviResponse();
            gs.GradoviModel = db.Gradovi.ToList().ToGradViewModel();

            //foreach (var item in db.Gradovi)
            //{
            //    Grad g = new Grad();
            //    g.DrzavaID = item.DrzavaID;
            //    g.Naziv = HttpUtility.UrlEncode("http://www." + item.Naziv + ".com");
            //    g.IDGrad = item.IDGrad;
            //    gr.Add(g);
            //}
            return gs;
        }

        // GET: api/Gradovi/5
        [ResponseType(typeof(Grad))]
        public async Task<IHttpActionResult> GetGrad(int id)
        {
            Grad grad = await db.Gradovi.FindAsync(id);
            if (grad == null)
            {
                return NotFound();
            }

            return Ok(grad);
        }

        // PUT: api/Gradovi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrad(int id, Grad grad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grad.IDGrad)
            {
                return BadRequest();
            }

            db.Entry(grad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradExists(id))
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

        // POST: api/Gradovi
        [ResponseType(typeof(Grad))]
        public async Task<IHttpActionResult> PostGrad(GradoviResponse Gradovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //string drzava = HttpUtility.UrlDecode(gradovi[0].DrzavaNaziv);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = 1 }, Gradovi);
        }

        // DELETE: api/Gradovi/5
        [ResponseType(typeof(Grad))]
        public async Task<IHttpActionResult> DeleteGrad(int id)
        {
            Grad grad = await db.Gradovi.FindAsync(id);
            if (grad == null)
            {
                return NotFound();
            }

            db.Gradovi.Remove(grad);
            await db.SaveChangesAsync();

            return Ok(grad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradExists(int id)
        {
            return db.Gradovi.Count(e => e.IDGrad == id) > 0;
        }
    }
}