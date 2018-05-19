using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Dtos;
using TallerDeMotos.Models;
using TallerDeMotos.Models.AtributosDeAutorizacion;
using TallerDeMotos.Models.ModelosDeDominio;
using TallerDeMotos.ViewModels;

namespace TallerDeMotos.Controllers
{
    public class MovimientoCajaController : Controller
    {
        private ApplicationDbContext _context;
        private ConexionBD conexionBD;
        MovimientoCajaViewModel viewModel;


        public MovimientoCajaController()
        {
            _context = new ApplicationDbContext();
            conexionBD = new ConexionBD();
            viewModel = new MovimientoCajaViewModel();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Administrador) || User.IsInRole(RoleName.JefeDeTaller) || User.IsInRole(RoleName.Mecanico))
                return View("ListaDeMovimientos");

            return View("ListaDeMovimientosSoloLectura");
        }

        // GET: MovimientoCaja
        [AutorizacionPersonalizada(RoleName.Administrador, RoleName.JefeDeTaller, RoleName.Mecanico)]
        public ActionResult MovimientoCajaFormulario()
        {            
            DataSet dsDatos = new DataSet();
            string usuarioId = User.Identity.GetUserId().ToString();
            dsDatos = conexionBD.ObtenerDatosParaMovimientoCaja(usuarioId);
            if(dsDatos.Tables[0].Rows.Count > 0)
            {
                var facturasPendientes = _context.FacturaVentas
                    .Where(fv => fv.EstadoId == 1 && fv.UsuarioId == usuarioId)
                    .ToList();

                viewModel = new MovimientoCajaViewModel
                {
                    UsuarioCaja = dsDatos.Tables[0].Rows[0]["UserName"].ToString(),
                    AperturaCierreCajaId = int.Parse(dsDatos.Tables[0].Rows[0]["Codigo"].ToString()),
                    Fecha = DateTime.Parse(dsDatos.Tables[0].Rows[0]["Fecha"].ToString()),
                    NombreCaja = dsDatos.Tables[0].Rows[0]["Nombre"].ToString(),
                    SaldoInicial = long.Parse(dsDatos.Tables[0].Rows[0]["SaldoInicial"].ToString()),
                    EstadoCaja = bool.Parse(dsDatos.Tables[0].Rows[0]["EstaAbierta"].ToString()) == true ? "Abierta" : "Cerrada",
                    FacturaVentas = facturasPendientes,
                    Bancos = _context.Bancos.ToList(),
                    TipoMovimientos = _context.TipoMovimientos.ToList()
                };

                if (viewModel.EstadoCaja == "Abierta")
                    ViewBag.style = "label label-success";
                else
                    ViewBag.style = "label label-danger";

                viewModel.Resultado = true;
            }
            else
            {
                viewModel.MensajeError = "Primero debe realizar la apertura de la caja del día de hoy.";
                viewModel.Resultado = false;
            }            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuardarMovimiento(MovimientoCajaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                string usuarioId = User.Identity.GetUserId().ToString();

                var facturasPendientes = _context.FacturaVentas
                    .Where(fv => fv.EstadoId == 1 && fv.UsuarioId == usuarioId)
                    .ToList();

                MovimientoCajaViewModel model = new MovimientoCajaViewModel();
                DataSet dsDatos = conexionBD.ObtenerDatosParaMovimientoCaja(usuarioId);
                if (dsDatos.Tables.Count > 0)
                {
                    model = new MovimientoCajaViewModel()
                    {
                        UsuarioCaja = dsDatos.Tables[0].Rows[0]["UserName"].ToString(),
                        AperturaCierreCajaId = int.Parse(dsDatos.Tables[0].Rows[0]["Codigo"].ToString()),
                        Fecha = DateTime.Parse(dsDatos.Tables[0].Rows[0]["Fecha"].ToString()),
                        NombreCaja = dsDatos.Tables[0].Rows[0]["Nombre"].ToString(),
                        SaldoInicial = long.Parse(dsDatos.Tables[0].Rows[0]["SaldoInicial"].ToString()),
                        EstadoCaja = bool.Parse(dsDatos.Tables[0].Rows[0]["EstaAbierta"].ToString()) == true ? "Abierta" : "Cerrada",
                        TipoMovimientos = _context.TipoMovimientos.ToList(),
                        FacturaVentas = facturasPendientes,
                        Bancos = _context.Bancos.ToList()
                    };
                    if (model.EstadoCaja == "Abierta")
                        ViewBag.style = "label label-success";
                    else
                        ViewBag.style = "label label-danger";

                    model.Resultado = true;
                }else
                {
                    model.MensajeError = "Primero debe realizar la apertura de la caja del día de hoy.";
                    model.Resultado = false;
                }

                return View("MovimientoCajaFormulario", model);
            }

            //var query = (from aperturaCierre in _context.CajaAperturaCierres
            //             join caja in _context.Cajas on aperturaCierre.CajaId equals caja.Id
            //             where caja.EstadoActivo
            //             select new { ID = aperturaCierre.Id }).First();

            //int id = query.ID;
            if (viewModel.Id == 0)
            {
                //viewModel.AperturaCierreCajaId = id;
                var movimiento = Mapper.Map<MovimientoCajaViewModel, MovimientoCaja>(viewModel);
                _context.MovimientoCajas.Add(movimiento);

                #region Inserción de las de las distintas Formas de Pago para un Movimiento
                List<RelacionFormaPagoYBanco> lista = new List<RelacionFormaPagoYBanco>();
                Dictionary<byte, int?> fpb = new Dictionary<byte, int?>();

                if (viewModel.FormaPagoEfectivo)
                {
                    var queryFormaPagoEfectivo = _context.FormasPago.Where(fp => fp.Nombre.Contains("Efectivo")).FirstOrDefault();
                    if(queryFormaPagoEfectivo != null)
                    {
                        lista.Add(new RelacionFormaPagoYBanco
                        {
                            FormaPagoId = queryFormaPagoEfectivo.Id,
                            NroAutorizacion = 0,
                            NroCheque = 0
                        });
                        fpb.Add(queryFormaPagoEfectivo.Id, null);
                    }
                }

                if (viewModel.FormaPagoCheque)
                {
                    var queryFormaPagoCheque = _context.FormasPago.Where(fp => fp.Nombre.Contains("Cheque")).FirstOrDefault();
                    if(queryFormaPagoCheque != null)
                    {
                        lista.Add(new RelacionFormaPagoYBanco
                        {
                            FormaPagoId = queryFormaPagoCheque.Id,
                            NroCheque = viewModel.NroCheque,
                            NroAutorizacion = 0
                        });
                        fpb.Add(queryFormaPagoCheque.Id, viewModel.BancoIdCheque);

                    }
                }

                if (viewModel.FormaPagoTarjeta)
                {
                    var queryFormaPagoTarjeta = _context.FormasPago.Where(fp => fp.Nombre.Contains(viewModel.TipoTarjeta)).FirstOrDefault();
                    if(queryFormaPagoTarjeta != null)
                    {
                        lista.Add(new RelacionFormaPagoYBanco
                        {                            
                            FormaPagoId = queryFormaPagoTarjeta.Id,
                            NroCheque = 0,
                            NroAutorizacion = viewModel.NroAutorizacion
                        });
                        fpb.Add(queryFormaPagoTarjeta.Id, viewModel.BancoIdTarjeta);

                    }
                }

                foreach (var item in lista)
                {
                    var movimientosFormaPago = new MovimientoCajaFormaPago
                    {
                        FormaPagoId = item.FormaPagoId
                    };

                    _context.MovimientosFormaPagos.Add(movimientosFormaPago);                   
                }

                if (lista.Count > 0)
                    _context.SaveChanges();

                #endregion

                #region Relacionar las distintas Formas de Pago con los Bancos
                //Obtenemos el id del último movimiento insertado.
                int ultimoMovimiento = _context.MovimientoCajas.Max(mc => mc.Id);

                int valor = 0;
                //Recorremos el diccionario con el key value pair de formas de pago y bancos.
                foreach (KeyValuePair<byte, int?> kvp in fpb)
                {
                    if(kvp.Value != null) //id del banco
                    {
                        //Obtenemos el id
                        var movFormasPagos = _context.MovimientosFormaPagos
                            .Where(m => m.FormaPagoId == kvp.Key && 
                            m.MovimientoCajaId == ultimoMovimiento).FirstOrDefault();

                        valor = movFormasPagos.Id;
                        string respuesta = conexionBD.CrearRelacionFormaPagoYBancos(valor, kvp.Value, viewModel.NroCheque, viewModel.NroAutorizacion);

                    }
                }
                #endregion
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ClientesPorFactura(int id)
        {
            DataSet dsDatos = conexionBD.ObtenerDatosClientePorFacturas(id);
            if(dsDatos.Tables.Count > 0)
            {
                viewModel.Cliente = dsDatos.Tables[0].Rows[0]["NOMBRECLIENTE"].ToString();
                viewModel.Vehiculo = dsDatos.Tables[0].Rows[0]["VEHICULO"].ToString();
                viewModel.MontoFactura = long.Parse(dsDatos.Tables[0].Rows[0]["SUBTOTAL"].ToString());
            }
            return Json(viewModel);
        }
    }
}