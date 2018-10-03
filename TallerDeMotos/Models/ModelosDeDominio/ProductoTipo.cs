using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class ProductoTipo
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Descripcion { get; set; }

        public int? PorcentajeGanancia { get; set; }

        public ICollection<Producto> Productos { get; set; }

        public ProductoTipo()
        {
            Productos = new HashSet<Producto>();
        }
    }
}