using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioL;
            if (!IsPostBack)
            {
                if (Session["UsuarioLogin"] != null)
                {

                    lblUsuario.Text = Session["UsuarioLogin"].ToString();

                    if (Session["UsuarioLogin"].ToString() == "admin")
                    {
                        HyperLink1.NavigateUrl = "GestionMenu.aspx";
                        HyperLink1.Text = "Administrar página";
                        HyperLink2.NavigateUrl = "IniciarSesion.aspx";
                        HyperLink2.Text = "Cerrar Sesión";
                        HyperLink8.Text = "";
                    }
                    else
                    {
                        HyperLink1.NavigateUrl = "~/Usuario/Carrito.aspx";
                        HyperLink1.Text = "Carrito";
                        HyperLink2.NavigateUrl = "~/Usuario/MiCuenta.aspx";
                        HyperLink2.Text = "Mi Cuenta";
                        HyperLink8.Text = "";
                    }
                }
                else
                {
                    UsuarioL = " ";
                    lblUsuario.Text = UsuarioL;
                }
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarProductos.aspx");
        }

        
        protected void btnMarca_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "EventoSeleccionar")
            {
                Session["IDMarca"] = e.CommandArgument.ToString();
                Response.Redirect("~/MostrarProductos.aspx");
            }
            
            
        }

        
    }
}