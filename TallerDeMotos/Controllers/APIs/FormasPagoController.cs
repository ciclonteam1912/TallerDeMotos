using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class FormasPagoController : ApiController
    {
        private ApplicationDbContext _context;

        public FormasPagoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerFormasDePago()
        {
            var formasDePago = _context.FormasPago
                .ToList();
                //.Select(Mapper.Map<FormaPago, FormaPagoDto>);

            return Ok(formasDePago);
        }

        //[Authorize(Roles = RoleName.Administrador)]
        //[HttpPost]
        //public IHttpActionResult CrearFormasDePago(FormaPagoDto formasDePagoDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var formasDePago = Mapper.Map<FormaPagoDto, FormaPago>(formasDePagoDto);

        //    _context.FormaPagos.Add(formasDePago);
        //    _context.SaveChanges();

        //    var resultado = Mapper.Map<FormaPago, FormaPagoDto>(formasDePago);

        //    return Ok(resultado);
        //}

        [HttpDelete]
        public IHttpActionResult EliminarFormasDePago(int id)
        {
            try
            {
                var formaDePago = _context.FormasPago.Single(fp => fp.Id == id);

                _context.FormasPago.Remove(formaDePago);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok(new JsonResponse { Success = true, Message = "Forma de Pago eliminado con éxito" });
        }
    }
}
