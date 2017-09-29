using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Marca { get; set; }

        [Display(Name = "Precio Costo")]
        public int? PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        public int? PrecioVenta { get; set; }

        [Display(Name = "Existencia Inicial")]        
        public int? ExistenciaInicial { get; set; }

        [Display(Name = "Existencia Mínima")]
        public int? ExistenciaMinima { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Producto" : "Nuevo Producto";
            }
        }

        public ProductoViewModel()
        {

        }

        public ProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            Descripcion = producto.Descripcion;
            Marca = producto.Marca;
            PrecioCosto = producto.PrecioCosto;
            PrecioVenta = producto.PrecioVenta;
            ExistenciaInicial = producto.ExistenciaInicial;
            ExistenciaMinima = producto.ExistenciaMinima;
        }
    }
}