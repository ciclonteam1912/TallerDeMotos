using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class TipoDocumento
    {
        public byte Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public TipoDocumento()
        {
            Clientes = new Collection<Cliente>();
        }
    }
}