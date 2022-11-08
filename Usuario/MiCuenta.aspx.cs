using Business.VentasModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class MiCuenta1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["UsuarioLogin"].ToString();
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["UsuarioLogin"] = null;
            Response.Redirect("~/IniciarSesion.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Configuraciones.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialDeCompras.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarProductos.aspx");
        }
    }
}