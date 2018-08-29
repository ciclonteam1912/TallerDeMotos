using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Cargo
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

        public Cargo()
        {
            Empleados = new Collection<Empleado>();
        }
    }
}