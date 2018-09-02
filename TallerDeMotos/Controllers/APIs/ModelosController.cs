using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class ModelosController : ApiController
    {
        private ApplicationDbContext _context;

        public ModelosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerModelos()
        {
            var modelos = _context.Modelos
                .Include(m => m.Marca)
                .Include(m => m.Cilindrada)
                .Include(m => m.TipoMotor)
                .ToList();

            return Ok(modelos);
        }

        [HttpDelete]
        public IHttpActionResult EliminarModelo(int id)
        {
            try
            {                
                var modelo = _context.Modelos.Single(m => m.Id == id);
                _context.Modelos.Remove(modelo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.Vehiculos_dbo.Modelos_ModeloCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.Vehiculos_dbo.Modelos_ModeloCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Modelo eliminado con éxito" });
        }
    }
}
