using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Ventas
{
    public class VentasModel
    {
        public string IdVenta { get; set; }

        public string IdUsuario { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal PrecioVenta { get; set; }

        public bool EstadoVenta { get; set; }
    }
}
