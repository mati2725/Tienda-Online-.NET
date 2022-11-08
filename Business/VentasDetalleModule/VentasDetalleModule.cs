using DataAccess.VentasDetalleData;
using Entities.VentasDetalle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.VentasDetalleModule
{
    public class VentasDetalleModule
    {

        public bool AgregarVentaDetalle(VentasDetalle Model)
        {
            bool estado = new VentasDetalleDB().AgregarVentaDetalle(Model);
            return estado;
        }

        public DataTable GetVentaDetalles()
        {
            throw new NotImplementedException();
        }

        public DataTable GetEstadisticaCategorias()
        {
            return new VentasDetalleDB().GetEstadisticaCategorias();
        }
        public DataTable GetEstadisticaMarcas()
        {
            return new VentasDetalleDB().GetEstadisticaMarcas();
        }

        public DataTable GetVentaDetalles(string IdVenta)
        {
            return new VentasDetalleDB().GetVentaDetalles(IdVenta);
        }

        public DataTable BuscarEstadisticaMarcasxNombre(string Marca)
        {
            return new VentasDetalleDB().BuscarEstadisticaMarcasxNombre(Marca);
        }

        public DataTable BuscarEstadisticaCategoriasxNombre(string Categoria)
        {
            return new VentasDetalleDB().BuscarEstadisticaCategoriasxNombre(Categoria);
        }
    }
}
