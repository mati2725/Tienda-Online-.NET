using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.VentasModule;

namespace Tp_Integrador___Grupo3
{
    public partial class HistorialDeCompras : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                

                if (Session["UsuarioLogin"] != null)
                {
                    if (Session["UsuarioLogin"].ToString() == "admin")
                    {
                        HyperLink1.NavigateUrl = "GestionMenu.aspx";
                        HyperLink1.Text = "Administrar página";
                        HyperLink2.NavigateUrl = "IniciarSesion.aspx";
                        HyperLink2.Text = "Cerrar Sesión";
                    }
                    else
                    {
                        Session["UsuarioVentas"] = Session["UsuarioLogin"].ToString();
                        HyperLink1.NavigateUrl = "~/Usuario/Carrito.aspx";
                        HyperLink1.Text = "Carrito";
                        HyperLink2.NavigateUrl = "~/Usuario/MiCuenta.aspx";
                        HyperLink2.Text = "Mi Cuenta";
                        lblHistCompras.Text = Session["UsuarioVentas"].ToString();
                    }
                }
                gdVentas.DataSource = new VentasModule().GetVentas((string)Session["UsuarioVentas"]);
                gdVentas.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["nombreProducto"] = TextBox1.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void gdVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["IdVenta"] = ((Label)gdVentas.Rows[e.NewSelectedIndex].FindControl("lblCodigo")).Text;
            Response.Redirect("DetalleDeCompra.aspx");
        }
    }
}