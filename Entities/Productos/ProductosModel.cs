using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Productos
{
    public class ProductosModel
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Detalle { get; set; }

        public int IdCategoria { get; set; }

        public int IdMarca { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }

        public bool EstadoProducto { get; set; }

        public string URLProductos { get; set; }
    }
}
