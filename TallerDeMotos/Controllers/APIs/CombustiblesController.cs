using System;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class CombustiblesController : ApiController
    {
        private ApplicationDbContext _context;

        public CombustiblesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult ObtenerCombustibles()
        {
            var combustibles = _context.Combustibles.ToList();
                //.Select(Mapper.Map<Combustible, CombustibleDto>);

            return Ok(combustibles);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearCombustible(CombustibleDto combustibleDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var combustible = Mapper.Map<CombustibleDto, Combustible>(combustibleDto);

        //    _context.Combustibles.Add(combustible);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<Combustible, CombustibleDto>(combustible);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarCombustibles(int id)
        {
            try
            {                
                var combustible = _context.Combustibles.Single(p => p.Id == id);
                _context.Combustibles.Remove(combustible);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var exceptionMessage = "FK_dbo.Vehiculos_dbo.Combustibles_CombustibleCodigo";
                if (ex.InnerException.InnerException.Message.Contains(exceptionMessage))
                    return Json(new JsonResponse { Success = false, Message = exceptionMessage });
            }

            return Ok(new JsonResponse { Success = true, Message = "Tipo de Combustible eliminado con éxito" });
        }
    }
}
