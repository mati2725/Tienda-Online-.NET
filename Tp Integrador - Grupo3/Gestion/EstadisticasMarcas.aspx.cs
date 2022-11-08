using Business.VentasDetalleModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3.Gestion
{
    public partial class EstadisticasMarcas : System.Web.UI.Page
    {

        readonly VentasDetalleModule Tabla = new VentasDetalleModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = Tabla.GetEstadisticaMarcas();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["NombreMarca"] = ((Label)GridView1.Rows[e.NewSelectedIndex].FindControl("lblNombreMarca")).Text;
            Session["NombreCategoria"] = null;
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Tabla.BuscarEstadisticaMarcasxNombre(txtBuscar.Text);
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}