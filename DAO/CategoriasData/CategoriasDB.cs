using Entities.Categorias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.CategoriasData
{
    public class CategoriasDB
    {
        private readonly string _connectionString;

        public CategoriasDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool ExisteCategoria(string categoria)
        {
            string query = "Select * From Categorias Where Nombre_Cat='" +categoria + "'And Estado_Cat= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ExisteCategoria(string categoria, string IdCategoria)
        {
            string query = "Select * From Categorias Where Nombre_Cat='" + categoria + "'And Estado_Cat= 'True' AND IdCategoria_Cat  != " + IdCategoria;
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool AgregarCategoria(CategoriasModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "AgregarCategoria";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Model.NombreCategoria);
                


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

        public bool ActualizarCategoria(CategoriasModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "ModificarCategoria";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Model.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", Model.NombreCategoria);

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
        public DataTable BuscarCategorias(string Categoria)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdCategoria_Cat, Nombre_Cat FROM Categorias WHERE Estado_Cat = 1 AND Nombre_Cat LIKE '" + Categoria + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionCategoria");
            cn.Close();
            return ds.Tables["GestionCategoria"];
        }

        public bool EliminarCategoria(int idCategoria)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "EliminarCategoria";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idCategoria);


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
        public DataTable GetCategorias()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdCategoria_Cat, Nombre_Cat FROM Categorias WHERE Estado_Cat = 1";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionCategoria");
            Console.WriteLine(ds.Tables["GestionCategoria"].Columns.Count);
            Console.WriteLine(ds.Tables["GestionCategoria"].Rows.Count);
            return ds.Tables["GestionCategoria"];
        }
    }
}
