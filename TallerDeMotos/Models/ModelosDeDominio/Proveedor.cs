using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(50)]
        public string Propietario { get; set; }

        [Required]
        [StringLength(10)]
        [RestriccionUnicaEnProveedor]
        [Display(Name = "RUC")]
        public string Ruc { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        public Ciudad Ciudad { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public ICollection<OrdenCompra> OrdenCompras { get; set; }

        public Proveedor()
        {
            Productos = new HashSet<Producto>();
            OrdenCompras = new HashSet<OrdenCompra>();
        }
    }
}