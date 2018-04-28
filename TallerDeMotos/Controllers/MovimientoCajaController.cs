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

        public MovimientoCajaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MovimientoCaja
        public ActionResult Index()
        {
            MovimientoCajaViewModel viewModel = new MovimientoCajaViewModel();
            ConexionBD conexionBD = new ConexionBD();
            DataSet dsDatos = new DataSet();
            string usuarioId = User.Identity.GetUserId().ToString();
            dsDatos = conexionBD.ObtenerDatosParaMovimientoCaja(usuarioId);
            if(dsDatos.Tables.Count > 0)
            {
                viewModel = new MovimientoCajaViewModel
                {
                    UsuarioCaja = dsDatos.Tables[0].Rows[0]["UserName"].ToString(),
                    Fecha = DateTime.Parse(dsDatos.Tables[0].Rows[0]["Fecha"].ToString()),
                    NombreCaja = dsDatos.Tables[0].Rows[0]["Nombre"].ToString(),
                    SaldoInicial = long.Parse(dsDatos.Tables[0].Rows[0]["SaldoInicial"].ToString()),
                    EstadoCaja = bool.Parse(dsDatos.Tables[0].Rows[0]["EstadoActivo"].ToString()) == true ? "Abierta" : "Cerrada"
                };

            }            
            return View(viewModel);
        }
    }
}