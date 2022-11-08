using Entities.Productos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ProductosData
{
    public class ProductosDB
    {
        private readonly string _connectionString;
        private readonly DataTable dt;

        public ProductosDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            dt = new DataTable();
        }

        public bool ExisteProducto(string producto)
        {
            string query = "Select * From Productos Where Nombre_P='" + producto + "'And Estado_P= 'True'";
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ExisteProducto(string producto, string IdProducto)
        {
            string query = "Select * From Productos Where Nombre_P='" + producto + "'And Estado_P= 'True' AND IdProducto_P != " + IdProducto;
            var existe = AccesoDatos.AccesoaDatos.ExistData(query);
            return existe;
        }

        public bool ActualizarProducto(ProductosModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "ModificarProducto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Model.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", Model.Nombre);
                cmd.Parameters.AddWithValue("@Detalle", Model.Detalle);
                cmd.Parameters.AddWithValue("@IdCategoria", Model.IdCategoria);
                cmd.Parameters.AddWithValue("@IdMarca", Model.IdMarca);
                cmd.Parameters.AddWithValue("@Precio", Model.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Stock", Model.Stock);
                cmd.Parameters.AddWithValue("@Imagen", Model.URLProductos);

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

        public bool AgregarProducto(ProductosModel Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "AgregarProducto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Model.Nombre);
                cmd.Parameters.AddWithValue("@Detalle", Model.Detalle);
                cmd.Parameters.AddWithValue("@IdCategoria", Model.IdCategoria);
                cmd.Parameters.AddWithValue("@IdMarca", Model.IdMarca);
                cmd.Parameters.AddWithValue("@Precio", Model.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Stock", Model.Stock);
                cmd.Parameters.AddWithValue("@Imagen", Model.URLProductos);



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

        public bool EliminarProducto(int IdProducto)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "EliminarProducto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", IdProducto);

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

        public DataTable GetProductos()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdProducto_P,Nombre_P,Detalle_P,Nombre_Cat,Nombre_M,PrecioUnitario_P," +
                "Stock_P, Imagen_P FROM Productos " +
                "INNER JOIN Categorias ON IdCategoria_P = IdCategoria_Cat " +
                "INNER JOIN Marcas ON IdMarca_M = IdMarca_P " +
                "WHERE Estado_P = 1";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionProducto");
            return ds.Tables["GestionProducto"];
        }

        public DataTable ConsultaProductos(string consulta)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "Productos");
            cn.Close();
            return ds.Tables["Productos"];
        }

        public DataTable BuscarProductos(string Producto)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdProducto_P,Nombre_P,Detalle_P,Nombre_Cat,Nombre_M,PrecioUnitario_P," +
                "Stock_P, Imagen_P FROM Productos " +
                "INNER JOIN Categorias ON IdCategoria_P = IdCategoria_Cat " +
                "INNER JOIN Marcas ON IdMarca_M = IdMarca_P " +
                "WHERE Estado_P = 1" +
                " AND Nombre_P LIKE '" + Producto + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionProducto");
            cn.Close();
            return ds.Tables["GestionProducto"];
        }

        public int GetIdProducto(string nombre)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdProducto_P FROM Productos WHERE Nombre_P = '" + nombre + "'";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "GestionProducto");
            cn.Close();
            return ds.Tables["GestionProducto"].Rows[0].Field<int>(0);
        }
    }
}
