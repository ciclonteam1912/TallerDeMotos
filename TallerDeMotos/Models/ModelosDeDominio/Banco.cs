using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Banco
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public ICollection<MovimientoFormaPagoBanco> MovimientoFormaPagoBancos { get; set; }

        public Banco()
        {
            MovimientoFormaPagoBancos = new HashSet<MovimientoFormaPagoBanco>();
        }
    }
}