using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class MovimientoCajaFormaPago
    {
        public int Id { get; set; }

        public MovimientoCaja MovimientoCaja { get; set; }

        public int MovimientoCajaId { get; set; }

        public FormaPago FormaPago { get; set; }

        public byte FormaPagoId { get; set; }

        public ICollection<MovimientoFormaPagoBanco> MovimientoFormaPagoBancos { get; set; }

        public MovimientoCajaFormaPago()
        {
            MovimientoFormaPagoBancos = new HashSet<MovimientoFormaPagoBanco>();
        }
    }
}