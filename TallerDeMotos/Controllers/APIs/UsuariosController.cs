using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerDeMotos.Models;

namespace TallerDeMotos.Controllers.APIs
{
    public class UsuariosController : ApiController
    {
        private ApplicationDbContext _context;

        public UsuariosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerUsuarios()
        {
            var usuarios = _context.Users.Where(u => u.UserName != "admin").ToList();

            return Ok(usuarios);
        }

        [HttpDelete]
        public IHttpActionResult EliminarUsuario(string id)
        {
            try
            {
                var usuario = _context.Users.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                _context.Users.Remove(usuario);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if(ex.InnerException.InnerException.Message.Contains("FK_dbo.CajaAperturaCierres_dbo.AspNetUsers_UsuarioCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.CajaAperturaCierres_dbo.AspNetUsers_UsuarioCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Usuario eliminado con éxito" });
        }
    }
}
