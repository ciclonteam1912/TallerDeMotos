using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class ProductoTipo
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Descripcion { get; set; }

        public int? PorcentajeGanancia { get; set; }

        //Para evitar una referencia circular al serializar un objeto
        [ScriptIgnore]
        public ICollection<Producto> Productos { get; set; }

        public ProductoTipo()
        {
            Productos = new HashSet<Producto>();
        }
    }
}