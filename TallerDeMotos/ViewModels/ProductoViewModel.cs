using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ProductoViewModel
    {
        #region Listas
        public IEnumerable<Marca> Marcas { get; set; }
        public IEnumerable<ProductoTipo> ProductoTipos { get; set; }
        #endregion

        #region Propiedades

        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Características")]
        public string Caracteristicas { get; set; }

        [Display(Name = "Marca")]
        public byte? MarcaId { get; set; }

        [Display(Name = "Precio Costo")]
        public int? PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        public int? PrecioVenta { get; set; }

        [Display(Name = "Existencia Actual")]        
        public int? ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        public int? ExistenciaMinima { get; set; }

        [RegularExpression(@"[a-zA-Z]?\d?\d", ErrorMessage = "Longitud válida para Tipo de Impuesto hasta 2 dígitos.")]
        [Display(Name = "Tipo de impuesto")]
        public byte? TipoImpuesto { get; set; }

        [Display(Name = "Tipo de Producto")]
        public byte ProductoTipoId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Producto o Servicio" : "Nuevo Producto o Servicio";
            }
        }
        #endregion

        #region Constructores
        public ProductoViewModel()
        {

        }

        public ProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            Descripcion = producto.Descripcion;
            MarcaId = producto.Marca?.Id;
            Caracteristicas = producto.Caracteristicas;
            PrecioCosto = producto.PrecioCosto;
            PrecioVenta = producto.PrecioVenta;
            ExistenciaActual = producto.ExistenciaActual;
            ExistenciaMinima = producto.ExistenciaMinima;
            TipoImpuesto = producto.TipoImpuesto;
            ProductoTipoId = producto.ProductoTipoId;
        }
        #endregion
    }
}