using Business.ProductosModule;
using DAO.ProductosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3.Gestion
{
    public partial class EstadisticasProductos : System.Web.UI.Page
    {

        private readonly ProductosModule _ProductosModule = new ProductosModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["NombreMarca"] != null)
            {
                string consulta = "SELECT Nombre_P[Nombre],PrecioUnitario_P[Precio unitario],Stock_P[Stock],Nombre_Cat[Categoria],Nombre_M[Marca],ISNULL(SUM(Cantidad_VD),0)[Cantidad productos vendidos] FROM Productos" +
                " LEFT JOIN Categorias ON IdCategoria_Cat=IdCategoria_P" +
                " LEFT JOIN Marcas ON IdMarca_M=IdMarca_P" +
                " LEFT JOIN VentaDetalle ON IdProducto_P=IdProducto_VD" +
                " WHERE Nombre_M = '" + (string)Session["NombreMarca"] +
                "' GROUP BY Nombre_P,PrecioUnitario_P,Stock_P,Nombre_Cat,Nombre_M";

                GridView1.DataSource = _ProductosModule.ConsultaProductos(consulta);
                GridView1.DataBind();


            }
            else
            {
                string consulta = "SELECT Nombre_P[Nombre],PrecioUnitario_P[Precio unitario],Stock_P[Stock],Nombre_Cat[Categoria],Nombre_M[Marca],ISNULL(SUM(Cantidad_VD),0)[Cantidad productos vendidos] FROM Productos" +
                " LEFT JOIN Categorias ON IdCategoria_Cat=IdCategoria_P" +
                " LEFT JOIN Marcas ON IdMarca_M=IdMarca_P" +
                " LEFT JOIN VentaDetalle ON IdProducto_P=IdProducto_VD" +
                " WHERE Nombre_Cat = '" + (string)Session["NombreCategoria"] +
                "' GROUP BY Nombre_P,PrecioUnitario_P,Stock_P,Nombre_Cat,Nombre_M";

                GridView1.DataSource = _ProductosModule.ConsultaProductos(consulta);
                GridView1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["NombreProducto"] = TextBox1.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["NombreMarca"] != null)
            {
                string consulta = "SELECT Nombre_P[Nombre],PrecioUnitario_P[Precio unitario],Stock_P[Stock],Nombre_Cat[Categoria],Nombre_M[Marca],ISNULL(SUM(Cantidad_VD),0)[Cantidad productos vendidos] FROM Productos" +
                " LEFT JOIN Categorias ON IdCategoria_Cat=IdCategoria_P" +
                " LEFT JOIN Marcas ON IdMarca_M=IdMarca_P" +
                " LEFT JOIN VentaDetalle ON IdProducto_P=IdProducto_VD" +
                " WHERE Nombre_M = '" + (string)Session["NombreMarca"] + "' AND Nombre_P LIKE '%" + TextBox2.Text + "%'" +
                " GROUP BY Nombre_P,PrecioUnitario_P,Stock_P,Nombre_Cat,Nombre_M";

                GridView1.DataSource = _ProductosModule.ConsultaProductos(consulta);
                GridView1.DataBind();

            }
            else
            {
                string consulta = "SELECT Nombre_P[Nombre],PrecioUnitario_P[Precio unitario],Stock_P[Stock],Nombre_Cat[Categoria],Nombre_M[Marca],ISNULL(SUM(Cantidad_VD),0)[Cantidad productos vendidos] FROM Productos" +
                " LEFT JOIN Categorias ON IdCategoria_Cat=IdCategoria_P" +
                " LEFT JOIN Marcas ON IdMarca_M=IdMarca_P" +
                " LEFT JOIN VentaDetalle ON IdProducto_P=IdProducto_VD" +
                " WHERE Nombre_Cat = '" + (string)Session["NombreCategoria"] + "' AND Nombre_P LIKE '%" + TextBox2.Text + "%'" +
                " GROUP BY Nombre_P,PrecioUnitario_P,Stock_P,Nombre_Cat,Nombre_M";

                GridView1.DataSource = _ProductosModule.ConsultaProductos(consulta);
                GridView1.DataBind();
            }
        }
    }
}