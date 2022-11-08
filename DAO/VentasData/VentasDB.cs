using Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VentasData
{
    public class VentasDB
    {
        private readonly string _connectionString;

        public VentasDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool Agregarventa(VentasModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "AgregarVenta";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USUARIO", Model.IdUsuario);
                cmd.Parameters.AddWithValue("@FECHA", Model.FechaVenta);
                cmd.Parameters.AddWithValue("@PRECIO", Model.PrecioVenta);


                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas == 0)
                {
                    estado = false;
                }
                else
                {
                    estado = true;
                }

            }
            catch (Exception e)
            {
                estado = false;
            }

            finally
            {
                con.Close();
            }
            return estado;
        }

        public DataTable GetVentas(string Usuario)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            try
            {
                string query = "Select IdVenta_V, PrecioTotal_V, Fecha_V from Venta Where Usuario_V='" + Usuario + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }

        public int UltimoIdVenta()
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            try
            {
                string query = "Select MAX(IdVenta_V) from Venta";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
            }
            catch (Exception e)
            {

            }
            finally
            {
                cn.Close();
            }

            return dt.Rows[0].Field<int>(0);
        }
    }
}
