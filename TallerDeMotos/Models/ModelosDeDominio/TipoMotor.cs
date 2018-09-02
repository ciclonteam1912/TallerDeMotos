using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class TipoMotor
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        public ICollection<Modelo> Modelos { get; set; }

        public TipoMotor()
        {
            Modelos = new HashSet<Modelo>();
        }
    }
}