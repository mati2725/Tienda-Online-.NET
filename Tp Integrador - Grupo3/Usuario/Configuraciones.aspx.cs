using Business.UsuariosModule;
using Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class Configuraciones : System.Web.UI.Page
    {

        private readonly UsuariosModule _usuariosModule;
        public Configuraciones()
        {
            _usuariosModule = new UsuariosModule();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblUsuario.Text = Session["UsuarioLogin"].ToString();

                int i, n, m;
                DateTime fechasys = DateTime.Now.Date;
                int aniosys = fechasys.Year;
                for (i = 1; i < 32; i++)
                {
                    String Item = Convert.ToString(i);

                    ddlDia.Items.Add(Item);
                }

                for (n = 1; n < 13; n++)
                {
                    String Item = Convert.ToString(n);

                    ddlMes.Items.Add(Item);
                }

                for (m = 1900; m < aniosys+1; m++)
                {
                    String Item = Convert.ToString(m);

                    ddlAño.Items.Add(Item);
                }

                LlenarCampos();
            }
        }

        int Validar_fecha(int dia, int mes, int anio)
        {

            bool bisiesto = false;
            if (anio % 4 == 0 && anio % 100 != 100 && anio % 400 == 0)
            {
                bisiesto = true;
            }
            if (dia > 0 && dia < 32 && mes > 0 && mes < 13 && anio > 0 && anio <= Convert.ToInt32(DateTime.Now.Year) + 1)
            {
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    return 1;
                }
                else
                {
                    if (mes == 2 && dia < 30 && bisiesto)
                    {
                        return 1;
                    }
                    else if (mes == 2 && dia < 29 && !bisiesto)
                    {
                        return 1;
                    }
                    else if (mes != 2 && dia < 31)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -1;

            }
        }
        public void LlenarCampos()
        {
            string idUsuario = Session["UsuarioLogin"].ToString();
            var usuario = _usuariosModule.GetUsuarioLogin(idUsuario);
            txtId.Text = usuario.Usuario;
            txtNombre.Text = usuario.NombreUsuario;
            xtApellido.Text = usuario.ApellidoUsuario;
            txtTel.Text = usuario.Telefono.ToString();
            txtDireccion.Text = usuario.Direccion;
            txtEmail.Text = usuario.Email;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string usuarioLog = Session["UsuarioLogin"].ToString();
            var pass = _usuariosModule.GetUsuarioLogin(usuarioLog);
            if (txtContraseñaVal.Text == pass.Contraseña.Trim())
            {
                string dia = ddlDia.SelectedItem.Text;
                string mes = ddlMes.SelectedItem.Text;
                string anio = ddlAño.SelectedItem.Text;
                string fechaNueva = dia + "/" + mes + "/" + anio;
                DateTime fecha = Convert.ToDateTime(fechaNueva);
                var usuario = new UsuariosModel();
                usuario.UsuarioNuevo = txtId.Text;
                usuario.Usuario = usuarioLog;
                usuario.NombreUsuario = txtNombre.Text;
                usuario.ApellidoUsuario = xtApellido.Text;
                usuario.FechaNacimiento = fecha;
                usuario.Telefono = Convert.ToInt32(txtTel.Text);
                usuario.Direccion = txtDireccion.Text;
                usuario.Email = txtEmail.Text;
                var filas = _usuariosModule.ModificarUs(usuario);
                if (filas == 1)
                {
                    lblConfiguracion.ForeColor = Color.Green;
                    lblConfiguracion.Text = "Se realizó el cambio con éxito.";
                    limpiarCampos();
                }
                else
                {
                    lblConfiguracion.ForeColor = Color.Red;
                    lblConfiguracion.Text = "No se pudo realizar el cambio.";
                }

            }
            else
            {
                lblCambiarPass.Text = "Contraseña incorrecta";
            }
        }

        public void limpiarCampos()
        {
            txtId.Text = " ";
            txtNombre.Text = " ";
            xtApellido.Text = " ";
            txtDireccion.Text = " ";
            txtContraseñaVal.Text = " ";
            txtEmail.Text = " ";
            txtTel.Text = " ";
            ddlDia.SelectedIndex = 0;
            ddlMes.SelectedIndex = 0;
            ddlAño.SelectedIndex = 0;
        }

        protected void btnCambiarContra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contraseña.aspx");
        }
    }
}