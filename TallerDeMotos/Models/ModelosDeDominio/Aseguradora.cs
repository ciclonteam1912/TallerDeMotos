using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Aseguradora
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(10)]
        public string Ruc { get; set; }

        [StringLength(255)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Aseguradora" : "Nueva Aseguradora";
            }
        }

        public ICollection<Vehiculo> Vehiculos { get; set; }        

        public Aseguradora()
        {
            Vehiculos = new HashSet<Vehiculo>();            
        }

        public Aseguradora(Aseguradora aseguradora)
        {
            Id = aseguradora.Id;
            Nombre = aseguradora.Nombre;
            Contacto = aseguradora.Contacto;
            Ruc = aseguradora.Ruc;
            Direccion = aseguradora.Direccion;
            Telefono = aseguradora.Telefono;
            CorreoElectronico = aseguradora.CorreoElectronico;
            Vehiculos = new HashSet<Vehiculo>();        }
    }
}