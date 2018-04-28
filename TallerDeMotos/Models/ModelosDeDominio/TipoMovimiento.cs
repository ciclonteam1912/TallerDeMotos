using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class TipoMovimiento
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }
        public ICollection<MovimientoCaja> MovimientoCajas { get; set; }

        public TipoMovimiento()
        {
            MovimientoCajas = new HashSet<MovimientoCaja>();
        }
    }
}