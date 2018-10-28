using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;
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

        [Required]
        [StringLength(255)]
        [Display(Name = "Características")]
        public string Caracteristicas { get; set; }

        public Marca Marca { get; set; }

        [NotMapped]
        [Display(Name = "Marca")]
        public byte? MarcaId { get; set; }

        [Display(Name = "Precio Costo")]
        public int? PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]        
        [PrecioVentaMayorPrecioCosto]
        public int? PrecioVenta { get; set; }

        public int? ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        [ExistenciaMinMenorExistenciaActual]
        public int? ExistenciaMinima { get; set; }

        [RegularExpression(@"[a-zA-Z]?\d?\d", ErrorMessage = "Longitud válida para Tipo de Impuesto hasta 2 dígitos.")]
        public byte? TipoImpuesto { get; set; }

        public ProductoTipo ProductoTipo { get; set; }

        [Display(Name = "Tipo de Producto")]
        public byte ProductoTipoId { get; set; }

        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
        public ICollection<FacturaCompraDetalle> FacturaCompraDetalles { get; set; }

        //Para evistar una referencia circular al serializar un objeto de tipo
        [ScriptIgnore]
        public ICollection<PresupuestoDetalle> PresupuestoDetalles { get; set; }
        public ICollection<FacturaVentaDetalle> FacturaVentaDetalles { get; set; }

        public Producto()
        {
            Proveedores = new HashSet<Proveedor>();
            OrdenCompraDetalles = new HashSet<OrdenCompraDetalle>();
            FacturaCompraDetalles = new HashSet<FacturaCompraDetalle>();
            PresupuestoDetalles = new HashSet<PresupuestoDetalle>();
            FacturaVentaDetalles = new HashSet<FacturaVentaDetalle>();
        }
    }
}