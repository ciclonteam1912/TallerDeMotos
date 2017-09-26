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
            //_context.Configuration.ProxyCreationEnabled = false;
            var marcas = _context.Marcas.ToList();
               // .Select(Mapper.Map<Marca, MarcaDto>);

            return Ok(marcas);
        }

        //[HttpPost]
        //public IHttpActionResult CrearMarca(MarcaDto marcaDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var marca = Mapper.Map<MarcaDto, Marca>(marcaDto);

        //    _context.Marcas.Add(marca);
        //    _context.SaveChanges();


        //    marca = _context.Marcas.Find(marca.Id);

        //    var resultado = Mapper.Map<Marca, MarcaDto>(marca);

        //    return Ok(resultado);
        //}

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
