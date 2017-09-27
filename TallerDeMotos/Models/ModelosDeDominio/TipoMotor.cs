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

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public TipoMotor()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
    }
}