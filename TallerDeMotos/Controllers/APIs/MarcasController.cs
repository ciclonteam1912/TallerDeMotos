using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class MarcasController : ApiController
    {
        private ApplicationDbContext _context;

        public MarcasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerMarcas()
        {
            var marcas = _context.Marcas.ToList();

            return Ok(marcas);
        }

        [HttpDelete]
        public IHttpActionResult EliminarMarca(int id)
        {
            try
            {                
                var marca = _context.Marcas.Single(m => m.Id == id);

                _context.Marcas.Remove(marca);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.Modelos_dbo.Marcas_MarcaCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.Modelos_dbo.Marcas_MarcaCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Marca eliminada con éxito" });
        }
    }
}
