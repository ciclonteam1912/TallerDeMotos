using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class FormaPago
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public ICollection<OrdenCompra> OrdenCompras { get; set; }

        public ICollection<MovimientoCajaFormaPago> MovimientosFormaPagos { get; set; }
        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Forma de Pago" : "Agregar Forma de Pago";
            }
        }

        public FormaPago()
        {
            OrdenCompras = new HashSet<OrdenCompra>();
            MovimientosFormaPagos = new HashSet<MovimientoCajaFormaPago>();
        }

        public FormaPago(FormaPago formaPago)
        {
            Id = formaPago.Id;
            Nombre = formaPago.Nombre;
            Descripcion = formaPago.Descripcion;
            OrdenCompras = new HashSet<OrdenCompra>();
            MovimientosFormaPagos = new HashSet<MovimientoCajaFormaPago>();
        }
    }
}