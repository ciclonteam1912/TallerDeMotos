using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class AperturaCierresController : ApiController
    {
        private ApplicationDbContext _context;

        public AperturaCierresController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerAperturaCierres()
        {
            var aperturaCierres = _context.CajaAperturaCierres
                .Include(m => m.Caja.Sucursal.Ciudad)
                .Include(m => m.Usuario)
                .ToList()
                .OrderByDescending(m => m.Fecha);

            return Ok(aperturaCierres);
        }

        [HttpDelete]
        public IHttpActionResult EliminarAperturaCierres(int id)
        {
            try
            {
                var aperturaCierre = _context.CajaAperturaCierres.Single(m => m.Id == id);
                _context.CajaAperturaCierres.Remove(aperturaCierre);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.Vehiculos_dbo.Modelos_ModeloCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.Vehiculos_dbo.Modelos_ModeloCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Apertura/Cierre de Caja eliminada con éxito" });
        }
    }
}
