using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [StringLength(20)]
        [RestriccionUnicaEnVehiculo]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [RestriccionUnicaEnVehiculo]
        [Required]
        [StringLength(20)]
        public string Chasis { get; set; }

        public float? Kilometro { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        [Display(Name = "Fecha de Fabricación")]
        public DateTime FechaDeFabricacion { get; set; }

        [NotMapped]
        [Display(Name = "Fecha de Fabricación")]
        public string Fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        public Modelo Modelo { get; set; }

        [Display(Name = "Modelo")]
        public byte ModeloId { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public Combustible Combustible { get; set; }

        [Display(Name = "Combustible")]
        public byte CombustibleId { get; set; }

        public Aseguradora Aseguradora { get; set; }

        [NotMapped]
        public byte? AseguradoraCodigo { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Modelo.Marca.Nombre + " " + Modelo.Nombre?.ToUpper() + "-" + Matricula?.ToUpper();
            }
        }

        public ICollection<Presupuesto> Presupuestos { get; set; }
        public ICollection<FacturaVentaCliente> FacturaVentaClientes { get; set; }

        public Vehiculo()
        {
            Presupuestos = new HashSet<Presupuesto>();
            FacturaVentaClientes = new HashSet<FacturaVentaCliente>();
        }
    }
}