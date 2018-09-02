using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.AtributosDeValidacion;

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
        [RestriccionUnicaEnAseguradora]
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

        public Ciudad Ciudad { get; set; }

        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }        

        public Aseguradora()
        {
            Vehiculos = new HashSet<Vehiculo>();            
        }
    }
}