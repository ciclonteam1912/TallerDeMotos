using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TallerDeMotos.Dtos;

namespace TallerDeMotos.Models
{
    public class ConexionBD
    {
        public DataSet ObtenerDatosParaMovimientoCaja(string usuarioId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TallerDeMotos"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {                                
                cmd = new SqlCommand("ObtenerConsultaParaMovimientoCaja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ds;
        }

        public DataSet ObtenerDatosClientePorFacturas(int facturaId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TallerDeMotos"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("ObtenerDatosClientePorFactura", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacturaId", facturaId);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return ds;
        }

        public string CrearRelacionFormaPagoYBancos(int movFormaPagoCodigo, int? bancoCodigo, int? nroCheque, int? nroAutorizacion)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TallerDeMotos"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            string respuesta = "";
            try
            {
                cmd = new SqlCommand("CrearRelacionFormaPagoYBancos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MovFormaPagoCod", movFormaPagoCodigo);
                cmd.Parameters.AddWithValue("@BancoCod", bancoCodigo);
                cmd.Parameters.AddWithValue("@NroCheque", nroCheque == null ? 0 : nroCheque);
                cmd.Parameters.AddWithValue("@NroAutorizacion", nroAutorizacion == null ? 0 : nroAutorizacion);
                cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                respuesta = cmd.Parameters["@resultado"].Value.ToString();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return respuesta;
        }

        public int CrearFacturaVentas(NuevaFacturaVentaDto facturaVenta, string usuarioId, int estadoId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TallerDeMotos"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            int respuesta = 0;
            try
            {
                cmd = new SqlCommand("CrearFacturaVentas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", facturaVenta.FacturaVentaDto.Id);
                cmd.Parameters.AddWithValue("@PresupuestoId", facturaVenta.PresupuestoCodigo);
                cmd.Parameters.AddWithValue("@NumeroFactura", facturaVenta.FacturaVentaDto.NumeroFactura);
                cmd.Parameters.AddWithValue("@TalonarioId", facturaVenta.FacturaVentaDto.TalonarioId);
                cmd.Parameters.AddWithValue("@FechaFactura", facturaVenta.FacturaVentaDto.FechaFacturaVenta);
                cmd.Parameters.AddWithValue("@SubTotal", facturaVenta.FacturaVentaDto.SubTotal);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@EstadoId", estadoId);
                cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                respuesta = int.Parse(cmd.Parameters["@resultado"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return respuesta;
        }

        public void CrearFacturaVentaDetalles(int facturaVentaId, int productoId, long precio, int cantidad, long total)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TallerDeMotos"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            int respuesta = 0;
            try
            {
                cmd = new SqlCommand("CrearFacturaVentaDetalles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FacturaVentaId", facturaVentaId);
                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.Add("@resultado", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                respuesta = int.Parse(cmd.Parameters["@resultado"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}