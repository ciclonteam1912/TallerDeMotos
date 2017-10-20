using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class AseguradorasController : ApiController
    {
        private ApplicationDbContext _context;

        public AseguradorasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerAseguradoras()
        {
            var aseguradoras = _context.Aseguradoras
                .Include(a => a.Ciudad)
                .ToList();
                //.Select(Mapper.Map<Aseguradora, AseguradoraDto>);

            return Ok(aseguradoras);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearAseguradora(AseguradoraDto aseguradoraDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var aseguradora = Mapper.Map<AseguradoraDto, Aseguradora>(aseguradoraDto);

        //    _context.Aseguradoras.Add(aseguradora);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<Aseguradora, AseguradoraDto>(aseguradora);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarAseguradora(int id)
        {
            try
            {
                var aseguradora = _context.Aseguradoras.Single(a => a.Id == id);
                _context.Aseguradoras.Remove(aseguradora);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                var exceptionMessage = "FK_dbo.Vehiculos_dbo.Aseguradoras_AseguradoraCodigo";
                if (ex.InnerException.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
            }

            return Ok(new JsonResponse { Success = true, Message = "Aseguradora eliminada con éxito" });
        }
    }
}
