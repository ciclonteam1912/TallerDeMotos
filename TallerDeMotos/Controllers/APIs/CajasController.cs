using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class CajasController : ApiController
    {
        private ApplicationDbContext _context;

        public CajasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCajas()
        {
            var cajas = _context.Cajas.Include(m => m.Usuario)
                .ToList();
            //.Select(Mapper.Map<Modelo, ModeloDto>);

            return Ok(cajas);
        }

        [HttpDelete]
        public IHttpActionResult EliminarCaja(int id)
        {
            try
            {
                var caja = _context.Cajas.Single(m => m.Id == id);
                _context.Cajas.Remove(caja);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.CajaAperturaCierres_dbo.Cajas_CajaCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.CajaAperturaCierres_dbo.Cajas_CajaCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Caja eliminada con éxito" });
        }
    }
}
