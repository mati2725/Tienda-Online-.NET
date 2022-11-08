using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entities.VentasDetalle;

namespace DataAccess.VentasDetalleData
{
    public class VentasDetalleDB
    {
        private readonly string _connectionString;

        public VentasDetalleDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool ActualizarVentaDetalle(int IdVentaDetalle)
        {
            throw new NotImplementedException();
        }

        public bool AgregarVentaDetalle(VentasDetalle Model)
        {
            bool estado;
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            try
            {
                string query = "AgregarVentaDetalle";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDVENTA", Model.IdVenta);
                cmd.Parameters.AddWithValue("@IDPRODUCTO", Model.IdProducto);
                cmd.Parameters.AddWithValue("@CANTIDAD", Model.Cantidad);
                cmd.Parameters.AddWithValue("@PRECIO", Model.PrecioUnitario);


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

        public DataTable GetVentaDetalles()
        {
            throw new NotImplementedException();
        }

        public DataTable GetEstadisticaCategorias()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Nombre_Cat [Categoria],COUNT(IdCategoria_P)[Cantidad de Productos],ISNULL(SUM(Stock_P),0)[Stock Total]," +
                "ISNULL(SUM(Cantidad_VD),0)[Cantidad de Productos Vendidos], " +
                "(ISNULL(SUM(Cantidad_VD),0)*100/(SELECT SUM(Cantidad_VD) FROM VentaDetalle)) [Porcentaje de Ventas] FROM Categorias " +
                "LEFT JOIN Productos ON IdCategoria_Cat = IdCategoria_P " +
                "LEFT JOIN VentaDetalle ON IdProducto_VD = IdProducto_P " +
                "GROUP BY Nombre_Cat";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "VentaDetalle");
            return ds.Tables["VentaDetalle"];
        }
        public DataTable GetEstadisticaMarcas()
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Nombre_M [Marca],COUNT(IdMarca_P)[Cantidad de Productos],ISNULL(SUM(Stock_P),0)[Stock Total]," +
                "ISNULL(SUM(Cantidad_VD),0)[Cantidad de Productos Vendidos]," +
                "(ISNULL(SUM(Cantidad_VD),0)*100/(SELECT SUM(Cantidad_VD) FROM VentaDetalle)) [Porcentaje de Ventas] FROM Marcas " +
                "LEFT JOIN Productos ON IdMarca_M = IdMarca_P " +
                "LEFT JOIN VentaDetalle ON IdProducto_VD = IdProducto_P " +
                "GROUP BY Nombre_M";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "VentaDetalle");
            return ds.Tables["VentaDetalle"];
        }

        public DataTable GetVentaDetalles(string IdVenta)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT IdProducto_VD[Codigo de producto]," +
                "Nombre_P[Producto],Cantidad_VD[Cantidad Comprada],PrecioUnitario_VD[Precio Unitario] from VentaDetalle " +
                "INNER JOIN Productos ON IdProducto_P = IdProducto_VD " + "WHERE IdVentaDetalle_VD = " + IdVenta;
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "VentaDetalle");
            return ds.Tables["VentaDetalle"];
        }

        public DataTable BuscarEstadisticaMarcasxNombre(string Marca)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Nombre_M [Marca],COUNT(IdMarca_P)[Cantidad de Productos],ISNULL(SUM(Stock_P),0)[Stock Total]," +
                "ISNULL(SUM(Cantidad_VD),0)[Cantidad de Productos Vendidos] FROM Marcas " +
                "LEFT JOIN Productos ON IdMarca_M = IdMarca_P " +
                "LEFT JOIN VentaDetalle ON IdProducto_VD = IdProducto_P " +
                "WHERE Nombre_M LIKE '" + Marca + "%'" +
                "GROUP BY Nombre_M";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "VentaDetalle");
            return ds.Tables["VentaDetalle"];
        }

        public DataTable BuscarEstadisticaCategoriasxNombre(string Categoria)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            string consulta = "SELECT Nombre_Cat [Categoria],COUNT(IdCategoria_P)[Cantidad de Productos],ISNULL(SUM(Stock_P),0)[Stock Total]," +
                "ISNULL(SUM(Cantidad_VD),0)[Cantidad de Productos Vendidos] FROM Categorias " +
                "LEFT JOIN Productos ON IdCategoria_Cat = IdCategoria_P " +
                "LEFT JOIN VentaDetalle ON IdProducto_VD = IdProducto_P " +
                "WHERE Nombre_Cat LIKE '" + Categoria + "%'" +
                "GROUP BY Nombre_Cat";
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            adp.Fill(ds, "VentaDetalle");
            return ds.Tables["VentaDetalle"];
        }
    }
}
