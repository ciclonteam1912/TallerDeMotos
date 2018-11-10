using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;

namespace TallerDeMotos.Controllers.APIs
{
    public class TalonariosController : ApiController
    {
        private ApplicationDbContext _context;

        public TalonariosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerTalonarios()
        {
            var talonarios = _context.Talonarios
                .Include(t => t.Caja)
                .ToList();
            return Ok(talonarios);
        }

        [HttpDelete]
        public IHttpActionResult EliminarTalonario(int id)
        {
            try
            {
                var talonario = _context.Talonarios.Single(t => t.Id == id);

                _context.Talonarios.Remove(talonario);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.FacturaVentas_dbo.Talonarios_TalonarioCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.FacturaVentas_dbo.Talonarios_TalonarioCodigo" });
            }
            return Ok(new JsonResponse { Success = true, Message = "Talonario eliminado con éxito" });
        }
    }
}
