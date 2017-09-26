using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Combustible
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Tipo de Combustible" : "Nuevo Tipo de Combustible";
            }
        }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public Combustible()
        {
            Vehiculos = new Collection<Vehiculo>();
        }

        public Combustible(Combustible combustible)
        {
            Id = combustible.Id;
            Nombre = combustible.Nombre;
            Vehiculos = new Collection<Vehiculo>();
        }
    }
}