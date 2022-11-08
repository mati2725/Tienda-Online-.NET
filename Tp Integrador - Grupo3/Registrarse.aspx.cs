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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly UsuariosModule _usuariosModule;

        public WebForm1()
        {
            _usuariosModule = new UsuariosModule();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                CargarFechas();

            }

        }

        public void CargarFechas()
        {
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            LlenarCampos();
        }

        public void LlenarCampos()
        {
            string dia = ddlDia.SelectedItem.Text;
            string mes = ddlMes.SelectedItem.Text;
            string anio = ddlAño.SelectedItem.Text;
            string fechanac = dia + "/" + mes + "/" + anio;
            int validacion = Validar_fecha(int.Parse(dia), int.Parse(mes), int.Parse(anio));
            if (validacion == -1)
            {
                lblRegistro.Text = "Fecha incorrecta";
            }
            else
            {
                DateTime fecha = Convert.ToDateTime(fechanac);
                var usuario = new UsuariosModel();
                usuario.Usuario = txtId.Text.Trim();
                usuario.NombreUsuario = txtNombre.Text.Trim();
                usuario.ApellidoUsuario = txtApellido.Text.Trim();
                usuario.FechaNacimiento = fecha;
                usuario.Telefono = Convert.ToInt32(txtTel.Text);
                usuario.Direccion = txtDireccion.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Email = txtEmail.Text;
                usuario.Dni = txtDni.Text;
                var filas = _usuariosModule.GuardarUsuario(usuario);
                if (filas == 1)
                {
                    lblRegistro.ForeColor = Color.Green;
                    lblRegistro.Text = "Guardado correctamente";
                    limpiarCampos();
                }
                if(filas == -2)
                {
                    lblRegistro.ForeColor = Color.Red;
                    lblRegistro.Text = "Usuario ya existente";
                }

                if(filas == -3)
                {
                    lblRegistro.ForeColor = Color.Red;
                    lblRegistro.Text = "Dni ya existente";

                }
            }

        }

        public void limpiarCampos()
        {
            txtId.Text = " ";
            txtNombre.Text = " ";
            txtApellido.Text = " ";
            txtDireccion.Text = " ";
            txtContraseña.Text = " ";
            txtDni.Text = " ";
            txtEmail.Text = " ";
            txtTel.Text = " ";
            txtRepContraseña.Text = " ";
            ddlDia.SelectedIndex = 0;
            ddlMes.SelectedIndex = 0;
            ddlAño.SelectedIndex = 0;
        }

    }
}