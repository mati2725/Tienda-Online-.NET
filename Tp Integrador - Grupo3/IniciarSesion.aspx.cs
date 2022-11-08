using Business.UsuariosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        private readonly UsuariosModule _usuariosModule;

        public IniciarSesion()
        {
            _usuariosModule = new UsuariosModule();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UsuarioLogin"] = null;
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

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Console.WriteLine(txtId.Text + "-" + txtContraseña.Text);
            var usuario = _usuariosModule.LoginUsuarioExist(txtId.Text, txtContraseña.Text);
            if (usuario)
            {
                Session["UsuarioLogin"] = txtId.Text;
                if(txtId.Text == "admin")
                {
                    Response.Redirect("~/GestionMenu.aspx");
                }
                else
                {
                    Response.Redirect("Usuario/MiCuenta.aspx");
                }
            }
            else
            {
                lblLogin.Text = "Usuario o Contraseña invalidos";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarProductos.aspx");
        }
    }
}