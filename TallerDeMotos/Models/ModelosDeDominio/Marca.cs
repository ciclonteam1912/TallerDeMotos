using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Marca
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public ICollection<Modelo> Modelos { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Marca" : "Nueva Marca";
            }
        }

        public Marca()
        {
            Modelos = new Collection<Modelo>();
        }

        public Marca(Marca marca)
        {
            Id = marca.Id;
            Nombre = marca.Nombre;
            Modelos = new Collection<Modelo>();
        }
    }
}