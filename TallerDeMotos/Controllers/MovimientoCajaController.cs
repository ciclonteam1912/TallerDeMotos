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

        // GET: MovimientoCaja
        public ActionResult Index()
        {            
            DataSet dsDatos = new DataSet();
            string usuarioId = User.Identity.GetUserId().ToString();
            dsDatos = conexionBD.ObtenerDatosParaMovimientoCaja(usuarioId);
            if(dsDatos.Tables.Count > 0)
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
                    EstadoCaja = bool.Parse(dsDatos.Tables[0].Rows[0]["EstadoActivo"].ToString()) == true ? "Abierta" : "Cerrada",
                    FacturaVentas = facturasPendientes,
                    Bancos = _context.Bancos.ToList(),
                    TipoMovimientos = _context.TipoMovimientos.ToList()
                };

                if (viewModel.EstadoCaja == "Abierta")
                    ViewBag.style = "label label-success";
                else
                    ViewBag.style = "label label-danger";
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
                        EstadoCaja = bool.Parse(dsDatos.Tables[0].Rows[0]["EstadoActivo"].ToString()) == true ? "Abierta" : "Cerrada",
                        TipoMovimientos = _context.TipoMovimientos.ToList(),
                        FacturaVentas = facturasPendientes,
                        Bancos = _context.Bancos.ToList()
                    };
                }
                if (model.EstadoCaja == "Abierta")
                    ViewBag.style = "label label-success";
                else
                    ViewBag.style = "label label-danger";

                return View("Index", model);
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

                #region Inserción de las de las distinatas Formas de Pago para un Movimiento
                List<byte> formasDePago = new List<byte>();
                byte formaPagoId = 0;
                if (viewModel.FormaPagoEfectivo)
                {
                    var queryFormaPagoEfectivo = _context.FormasPago.Where(fp => fp.Nombre.Contains("Efectivo")).FirstOrDefault();
                    if(queryFormaPagoEfectivo != null)
                    {
                        formaPagoId = queryFormaPagoEfectivo.Id;
                        formasDePago.Add(formaPagoId);
                    }
                }

                if (viewModel.FormaPagoCheque)
                {
                    var queryFormaPagoCheque = _context.FormasPago.Where(fp => fp.Nombre.Contains("Cheque")).FirstOrDefault();
                    formaPagoId = queryFormaPagoCheque.Id;
                    formasDePago.Add(formaPagoId);
                }

                if (viewModel.FormaPagoTarjeta)
                {
                    var queryFormaPagoTarjeta = _context.FormasPago.Where(fp => fp.Nombre.Contains("Tarjeta")).FirstOrDefault();
                    formaPagoId = queryFormaPagoTarjeta.Id;
                    formasDePago.Add(formaPagoId);
                }

                foreach (var lista in formasDePago)
                {
                    var movimientosFormaPago = new MovimientoCajaFormaPago
                    {
                        FormaPagoId = lista
                    };
                    _context.MovimientosFormaPagos.Add(movimientosFormaPago);
                }
                #endregion



                if (formasDePago.Count > 0)
                    _context.SaveChanges();
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