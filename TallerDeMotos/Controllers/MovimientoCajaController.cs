using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallerDeMotos.Models;
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