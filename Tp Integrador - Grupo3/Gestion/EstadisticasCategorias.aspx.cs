using Business.VentasDetalleModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3.Gestion
{
    public partial class ReportesVentas : System.Web.UI.Page
    {
        private VentasDetalleModule Tabla = new VentasDetalleModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = Tabla.GetEstadisticaCategorias();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["NombreCategoria"] = (((Label)(GridView1.Rows[e.NewSelectedIndex].FindControl("lblNombreCategoria"))).Text);
            Session["NombreMarca"] = null;
            Response.Redirect("Productos.aspx");
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource=Tabla.BuscarEstadisticaCategoriasxNombre(txtBuscar.Text);
            GridView1.DataBind();
        }
    }
}