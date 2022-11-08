using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_INTEGRADOR_GRUPO3
{
    public class VentaDetalle
    {
        int i_IdVenta;
        int i_IdVentaDetalle;
        int i_IdProducto;
        int i_Cantidad;
        float f_PrecioUnitario;
        public VentaDetalle()
        {

        }
        public int IdVenta
        {
            get { return i_IdVenta; }
            set { i_IdVenta = value; }
        }
        public int IdVentaDetalle
        {
            get { return i_IdVentaDetalle; }
            set { i_IdVentaDetalle = value; }
        }
        public int IdProducto
        {
            get { return i_IdProducto; }
            set { i_IdProducto = value; }
        }
        public int Cantidad
        {
            get { return i_Cantidad; }
            set { i_Cantidad = value; }
        }
        public float PrecioUnitario
        {
            get { return f_PrecioUnitario; }
            set { f_PrecioUnitario = value; }
        }
    }
}