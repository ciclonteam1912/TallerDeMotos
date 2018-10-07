using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.Controllers.APIs
{
    public class ProveedoresController : ApiController
    {
        private ApplicationDbContext _context;

        public ProveedoresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedores()
        {
            var proveedores = _context.Proveedores
                .Include(a => a.Ciudad)
                .ToList();
                //.Select(Mapper.Map<Proveedor, ProveedorDto>);

            return Ok(proveedores);
        }

        [Authorize(Roles = RoleName.Administrador)]
        [HttpPost]
        public IHttpActionResult CrearProveedor(NuevoProveedorDto nuevoProveedorDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Agregar nuevo proveedor
                    if(nuevoProveedorDto.ProveedorDto.Id == 0)
                    {
                        var proveedorDto = new ProveedorDto
                        {
                            RazonSocial = nuevoProveedorDto.ProveedorDto.RazonSocial,
                            Ruc = nuevoProveedorDto.ProveedorDto.Ruc,
                            Propietario = nuevoProveedorDto.ProveedorDto.Propietario,
                            Direccion = nuevoProveedorDto.ProveedorDto.Direccion,
                            CorreoElectronico = nuevoProveedorDto.ProveedorDto.CorreoElectronico,
                            Telefono = nuevoProveedorDto.ProveedorDto.Telefono,
                            CiudadId = nuevoProveedorDto.ProveedorDto.CiudadId
                        };

                        var proveedor = Mapper.Map<ProveedorDto, Proveedor>(proveedorDto);
                        _context.Proveedores.Add(proveedor);

                        foreach (var contacto in nuevoProveedorDto.ProveedorContactos)
                        {
                            var proveedorContactoDto = new ProveedorContactoDto
                            {
                                ContactoId = contacto.ContactoId,
                                Descripcion = contacto.Descripcion
                            };

                            var proveedorContacto = Mapper.Map<ProveedorContactoDto, ProveedorContacto>(proveedorContactoDto);
                            _context.ProveedorContactos.Add(proveedorContacto);
                        }
                    }
                    else
                    {
                        //editar proveedor existente
                        var proveedorBD = _context.Proveedores.Single(p => p.Id == nuevoProveedorDto.ProveedorDto.Id);
                        Mapper.Map<ProveedorDto, Proveedor>(nuevoProveedorDto.ProveedorDto, proveedorBD);

                        var proveedorContactosExistentes = _context.ProveedorContactos
                            .Where(pc => pc.ProveedorId == nuevoProveedorDto.ProveedorDto.Id)
                            .ToList();

                        var contactosAgregados = nuevoProveedorDto.ProveedorContactos
                            .Where(pc => !proveedorContactosExistentes.Any(pc2 => pc2.Id == pc.Id))
                            .ToList();

                        var contactosEliminados = proveedorContactosExistentes
                            .Where(pc => !nuevoProveedorDto.ProveedorContactos.Any(pc2 => pc2.Id == pc.Id))
                            .ToList();

                        foreach (var item in contactosAgregados)
                        {
                            var proveedorContacto = Mapper.Map<ProveedorContactoDto, ProveedorContacto>(item);

                            _context.ProveedorContactos.Add(proveedorContacto);
                        }

                        if (contactosEliminados.Count > 0)
                        {
                            foreach (var item in contactosEliminados)
                            {
                                var proveedorContacto = Mapper.Map<ProveedorContacto, ProveedorContactoDto>(item);
                                contactosEliminados.ForEach(c => _context.ProveedorContactos.Remove(item));
                            }

                        }
                    }                    

                    _context.SaveChanges();                     
                }
                catch (Exception ex)
                {
                    var exceptionMessage = "PK_dbo.FacturaVentas";
                    if (ex.InnerException.Message.Contains(exceptionMessage))
                        return Json(new JsonResponse { Success = false, Message = exceptionMessage });
                }

                return Ok(new JsonResponse { Success = true, Message = "Proveedor registrado con éxito" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            try
            {
                var proveedor = _context.Proveedores.Single(a => a.Id == id);
                _context.Proveedores.Remove(proveedor);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("FK_dbo.OrdenCompras_dbo.Proveedores_ProveedorCodigo"))
                    return Json(new JsonResponse { Success = false, Message = "FK_dbo.OrdenCompras_dbo.Proveedores_ProveedorCodigo" });
            }

            return Ok(new JsonResponse { Success = true, Message = "Proveedor eliminado con éxito" });
        }
    }
}
