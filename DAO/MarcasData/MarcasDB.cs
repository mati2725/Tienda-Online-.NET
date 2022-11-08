using Entities.Marcas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.MarcasData
{
    public class MarcasDB
    {
        private readonly string _connectionString;

        public MarcasDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool ExisteMarca(string marca)
        {
            string query = "Select * From Marcas Where Nombre_M='" + marca + "'And Estado_M= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ExisteMarca(string marca,string IdMarcas)
        {
            string query = "Select * From Marcas Where Nombre_M='" + marca + "'And Estado_M= 'True' AND IdMarca_M != "+ IdMarcas;
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ActualizarMarca(MarcasModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "ModificarMarca";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Model.IdMarca);
                cmd.Parameters.AddWithValue("@Nombre", Model.NombreMarca);

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

        public bool AgregarMarca(MarcasModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "AgregarMarca";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Model.NombreMarca);


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

        public DataTable BuscarMarcas(string Marcas)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdMarca_M, Nombre_M FROM Marcas WHERE Estado_M = 1 AND Nombre_M LIKE '" + Marcas + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionMarca");
            cn.Close();
            return ds.Tables["GestionMarca"];
        }

        public bool EliminarMarca(int IdMarca)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "EliminarMarca";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", IdMarca);


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

        public DataTable GetMarcas()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdMarca_M, Nombre_M FROM Marcas WHERE Estado_M = 1";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionMarcas");
            return ds.Tables["GestionMarcas"];
        }
    }
}
