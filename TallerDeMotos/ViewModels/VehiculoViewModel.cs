using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TallerDeMotos.Models.ModelosDeDominio;

namespace TallerDeMotos.ViewModels
{
    public class VehiculoViewModel
    {
        public IEnumerable<Cliente> Clientes { get; set; }

        public IEnumerable<Aseguradora> Aseguradoras { get; set; }

        public IEnumerable<Modelo> Modelos { get; set; }

        public IEnumerable<Combustible> Combustibles { get; set; }

        public int Id { get; set; }

        [Display(Name = "Matrícula")]
        [Required]
        public string Matricula { get; set; }

        public string Chasis { get; set; }

        [Display(Name = "Kilómetros")]
        public float? Kilometro { get; set; }

        public string Motor { get; set; }

        public int? Cilindrada { get; set; }

        public string Color { get; set; }

        [Display(Name = "Modelo")]
        public byte ModeloId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Combustible")]
        public byte CombustibleId { get; set; }

        [Display(Name = "Aseguradora")]
        public byte AseguradoraId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Vehículo" : "Nuevo Vehículo";
            }
        }

        public VehiculoViewModel()
        {
            Id = 0;
        }

        public VehiculoViewModel(Vehiculo vehiculo)
        {
            Id = vehiculo.Id;
            Matricula = vehiculo.Matricula;
            Chasis = vehiculo.Chasis;
            Kilometro = vehiculo.Kilometro;
            Motor = vehiculo.Motor;
            Cilindrada = vehiculo.Cilindrada;
            Color = vehiculo.Color;
            ModeloId = vehiculo.ModeloId;
            ClienteId = vehiculo.ClienteId;
            CombustibleId = vehiculo.CombustibleId;
            AseguradoraId = vehiculo.AseguradoraId;
        }
    }
}