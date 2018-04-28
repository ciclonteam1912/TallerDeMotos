using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
    }
}