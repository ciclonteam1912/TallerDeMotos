using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(50)]
        public string Propietario { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "RUC")]
        public string Ruc { get; set; }

        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        public ICollection<OrdenCompra> OrdenCompras { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Proveedor" : "Nuevo Proveedor";
            }
        }

        public Proveedor()
        {
            OrdenCompras = new HashSet<OrdenCompra>();
        }

        public Proveedor(Proveedor proveedor)
        {
            Id = proveedor.Id;
            RazonSocial = proveedor.RazonSocial;
            Contacto = proveedor.Contacto;
            Propietario = proveedor.Propietario;
            Ruc = proveedor.Ruc;
            Direccion = proveedor.Direccion;
            Telefono = proveedor.Telefono;
            CorreoElectronico = proveedor.CorreoElectronico;
        }
    }
}