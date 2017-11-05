using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Estado
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        public ICollection<OrdenCompra> OrdenCompras { get; set; }
        public ICollection<Presupuesto> Presupuestos { get; set; }

        public Estado()
        {
            OrdenCompras = new HashSet<OrdenCompra>();
            Presupuestos = new HashSet<Presupuesto>();
        }
    }
}