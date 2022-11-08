using System;
using Business.VentasDetalleModule;

namespace Tp_Integrador___Grupo3
{
    public partial class DetalleDeCompra : System.Web.UI.Page
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
                        HyperLink1.NavigateUrl = "~/Usuario/Carrito.aspx";
                        HyperLink1.Text = "Carrito";
                        HyperLink2.NavigateUrl = "~/Usuario/MiCuenta.aspx";
                        HyperLink2.Text = "Mi Cuenta";
                    }
                }
            }
            string IdVenta = Session["IdVenta"].ToString();
            GridView1.DataSource = new VentasDetalleModule().GetVentaDetalles(IdVenta);
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["NombreProducto"] = TextBox1.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }
    }
}