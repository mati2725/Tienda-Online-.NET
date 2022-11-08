using DAO.ProductosData;
using Entities.Productos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Business.ProductosModule
{
    public class ProductosModule
    {
        ProductosDB Datos = new ProductosDB();

        public bool EliminarProducto(int IdProducto)
        {
            return Datos.EliminarProducto(IdProducto);
        }

        public int ActualizarProducto(ProductosModel Model)
        {
            bool Estado = new ProductosDB().ExisteProducto(Model.Nombre,Convert.ToString(Model.IdProducto));

            if (Estado) return -2;

            if (new ProductosDB().ActualizarProducto(Model)) return 1;

            return -1;
        }

        public int AgregarProducto(ProductosModel Model)
        {
            bool Estado = new ProductosDB().ExisteProducto(Model.Nombre);

            if (Estado) return -2;

            if (new ProductosDB().AgregarProducto(Model)) return 1;

            return -1;

        }

        public DataTable GetProductos()
        {
            return Datos.GetProductos();
        }

        public DataTable ConsultaProductos(string consulta)
        {
            return Datos.ConsultaProductos(consulta);
        }

        public DataTable BuscarProductos(string Producto)
        {
            return Datos.BuscarProductos(Producto);
        }

        public int GetIdProducto(string nombre)
        {
            return Datos.GetIdProducto(nombre);
        }
    }
}
