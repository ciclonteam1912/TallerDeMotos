using System;
using System.Collections.Generic;

namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class AperturaCierreCaja
    {
        public int Id { get; set; }
        public Caja Caja { get; set; }
        public int CajaId { get; set; }
        public DateTime Fecha { get; set; }
        public long SaldoInicial { get; set; }
        public long? SaldoFinal { get; set; }
        public bool EstaAbierta { get; set; }     

        public ICollection<MovimientoCaja> MovimientoCajas { get; set; }

        public AperturaCierreCaja()
        {
            MovimientoCajas = new HashSet<MovimientoCaja>();
        }
    }
}