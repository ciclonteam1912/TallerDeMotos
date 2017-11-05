using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Marca { get; set; }

        [Display(Name = "Precio Costo")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio de costo debe ser mayor o igual a {1}")]
        public int PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio de venta debe ser mayor o igual a {1}")]
        [PrecioVentaMayorPrecioCosto]
        public int PrecioVenta { get; set; }

        [Display(Name = "Existencia Inicial")]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia inicial debe ser mayor o igual a {1}")]
        public int? ExistenciaInicial { get; set; }

        public int? ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia mínima debe ser mayor o igual a {1}")]
        [ExistenciaMinMenorExistenciaInicial]
        public int? ExistenciaMinima { get; set; }

        public byte Iva { get; set; }

        public ICollection<Proveedor> Proveedores { get; set; }

        public ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }

        public ICollection<FacturaCompraDetalle> FacturaCompraDetalles { get; set; }

        public ICollection<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        public Producto()
        {
            Proveedores = new HashSet<Proveedor>();
            OrdenCompraDetalles = new HashSet<OrdenCompraDetalle>();
            FacturaCompraDetalles = new HashSet<FacturaCompraDetalle>();
            PresupuestoDetalles = new HashSet<PresupuestoDetalle>();
        }
    }
}