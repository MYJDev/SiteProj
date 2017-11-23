using FinalApi.Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinalApi.Controllers
{
    [RoutePrefix("api/curriculo")]
    public class CurriculoController : ApiController
    {

        private CurriculoDataModel db = new CurriculoDataModel();

        // GET: api/Curriculo
        [Route("")]
        public IQueryable<Curriculo> GetCurriculo()
        {
            return db.Curriculo;
        }

        // GET: api/Curriculo/5
        [Route("{id}")]
        public IHttpActionResult GetCurriculo(int id)
        {
            Curriculo curriculo = db.Curriculo.Find(id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return Ok(curriculo);
        }

        // PUT: api/Curriculo/5
        [Route("{id}")]
        public IHttpActionResult PutCurriculo(int id, Curriculo curriculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curriculo.Id)
            {
                return BadRequest();
            }

            db.Entry(curriculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculoExists(id))
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

        // POST: api/Curriculo
        [Route("")]
        public async Task<IHttpActionResult> PostCurriculosAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var httpRequest = HttpContext.Current.Request;

          
            var json = httpRequest.Form.GetValues("curriculos").First();

         
            var total = httpRequest.Files.Count;

            
            var s = new Newtonsoft.Json.JsonSerializer();
            var curriculos = s.Deserialize<Curriculo>(new JsonTextReader(new StringReader(json)));


           
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(httpRequest.Files[0].InputStream))
            {
                fileData = binaryReader.ReadBytes(httpRequest.Files[0].ContentLength);
            }

            
            curriculos.File = fileData;

            Guid g;
            g = Guid.NewGuid();
            curriculos.IdFile = g;

            db.Curriculo.Add(curriculos);
            db.SaveChanges();

            return Ok(curriculos);
        }

        // DELETE: api/Curriculo/5
        [Route("{id}")]
        public IHttpActionResult DeleteCurriculo(int id)
        {
            Curriculo curriculo = db.Curriculo.Find(id);
            if (curriculo == null)
            {
                return NotFound();
            }

            db.Curriculo.Remove(curriculo);
            db.SaveChanges();

            return Ok(curriculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurriculoExists(int id)
        {
            return db.Curriculo.Count(e => e.Id == id) > 0;
        }
    }
}