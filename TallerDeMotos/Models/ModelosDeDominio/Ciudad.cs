using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Ciudad
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Aseguradora> Aseguradoras { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public Ciudad()
        {
            Aseguradoras = new HashSet<Aseguradora>();
            Clientes = new HashSet<Cliente>();
        }
    }
}