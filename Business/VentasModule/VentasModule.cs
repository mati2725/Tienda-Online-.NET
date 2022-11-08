using DAO.VentasData;
using Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.VentasModule
{
    public class VentasModule
    {
        public bool Agregar(VentasModel Model)
        {
            return new VentasDB().Agregarventa(Model);
        }

        public DataTable GetVentas(string Usuario)
        {
            return new VentasDB().GetVentas(Usuario);
        }

        public int UltimoIdVenta()
        {
            return new VentasDB().UltimoIdVenta();
        }
    }
}
