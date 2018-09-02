using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class Modelo
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        public Marca Marca { get; set; }

        [Display(Name = "Marca")]
        public byte MarcaId { get; set; }

        public Cilindrada Cilindrada { get; set; }

        [Display(Name = "Cilindrada")]
        public byte CilindradaId { get; set; }

        public TipoMotor TipoMotor { get; set; }

        [Display(Name = "Tipo de Motor")]
        public byte TipoMotorId { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public string ModeloCompleto
        {
            get
            {
                return Marca.Nombre + "-" + Nombre;
            }
        }

        public Modelo()
        {
            Vehiculos = new Collection<Vehiculo>();
        }
    }
}