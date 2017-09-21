using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Personeria
    {
        public byte Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public Personeria()
        {
            Clientes = new Collection<Cliente>();
        }
    }
}