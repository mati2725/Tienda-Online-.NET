using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP_INTEGRADOR_GRUPO3
{
    public class GestionVentaDetalle
    {
        public GestionVentaDetalle()
        {

        }

        private DataTable ObtenerTabla(string nombre,string SQL)
        {
            DataSet ds = new DataSet();
            Conexion cn = new Conexion();
            SqlDataAdapter adp = cn.ObtenerAdaptador(SQL);
            adp.Fill(ds, nombre);
            return ds.Tables[nombre];
        }

        private void ArmarParametrosVentaDetalle(ref SqlCommand cm, VentaDetalle reg)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros = cm.Parameters.Add("@IdVenta_VD", SqlDbType.Int);
            Parametros.Value = reg.IdVenta;
            Parametros = cm.Parameters.Add("@IdVentaDetalle_VD", SqlDbType.Int);
            Parametros.Value = reg.IdVentaDetalle;
            Parametros = cm.Parameters.Add("@IdProducto_VD", SqlDbType.Int);
            Parametros.Value = reg.IdProducto;
            Parametros = cm.Parameters.Add("@Cantidad_VD", SqlDbType.Int);
            Parametros.Value = reg.Cantidad;
            Parametros = cm.Parameters.Add("@PrecioUnitario_VD", SqlDbType.Float);
            Parametros.Value = reg.PrecioUnitario;

        }
        private void ArmarParametrosVentaDetalleEliminar(ref SqlCommand cm, VentaDetalle reg)
        {
            SqlParameter Parametros = new SqlParameter();
            Parametros = cm.Parameters.Add("@IdVentaDetalle_VD", SqlDbType.Int);
            Parametros.Value = reg.IdVentaDetalle;
        }

        public bool AgregarVentaDetalle(VentaDetalle reg)
        {
            SqlCommand cm = new SqlCommand();
            Conexion cn = new Conexion();
            int afectados = cn.EjecutarProcedimientoAlmacenado(cm, "spAgregarProducto");
            if (afectados == 0)
            {
                return false;
            }
            else return true;
        }
        public bool EliminarVentaDetalle(VentaDetalle reg)
        {
            SqlCommand cm = new SqlCommand();
            ArmarParametrosVentaDetalleEliminar(ref cm, reg);
            Conexion cn = new Conexion();
            int afectados = cn.EjecutarProcedimientoAlmacenado(cm, "spEliminarProducto");
            if (afectados == 0)
            {
                return false;
            }
            else return true;
        }
    }
}