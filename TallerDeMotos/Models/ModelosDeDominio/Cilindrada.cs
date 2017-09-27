using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Cilindrada
    {
        public byte Id { get; set; }

        public int NumeroCilindrada { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public Cilindrada()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }
    }
}