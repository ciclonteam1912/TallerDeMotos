using System;

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
    }
}