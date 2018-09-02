using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Cilindrada
    {
        public byte Id { get; set; }
        public int NumeroCilindrada { get; set; }

        public ICollection<Modelo> Modelos { get; set; }

        public Cilindrada()
        {
            Modelos = new HashSet<Modelo>();
        }
    }
}