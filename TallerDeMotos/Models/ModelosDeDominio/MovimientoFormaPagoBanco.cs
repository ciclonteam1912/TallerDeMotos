namespace TallerDeMotos.Models.ModelosDeDominio
{
    public class MovimientoFormaPagoBanco
    {
        public int Id { get; set; }
        public MovimientoCajaFormaPago MovimientoCajaFormaPago { get; set; }
        public int MovimientoCajaFormaPagoId { get; set; }
        public Banco Banco { get; set; }
        public int? BancoId { get; set; }
        public int? NroCheque { get; set; }
        public int? NroAutorizacion { get; set; }
    }
}