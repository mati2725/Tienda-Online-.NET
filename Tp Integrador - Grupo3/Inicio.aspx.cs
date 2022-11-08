using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class Inicio : System.Web.UI.Page
    {
        
        void cargarPaginaInicio()
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM Productos WHERE Estado_P = 'TRUE' AND IdCategoria_P =" + 3 ;
            SqlDataSource2.SelectCommand = "SELECT * From Productos WHERE Estado_P = 'TRUE' AND IdCategoria_P =" + 2;
            SqlDataSource3.SelectCommand = "SELECT * FROM Productos WHERE Estado_P = 'TRUE' AND IdCategoria_P =" + 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String UsuarioL;
            if (!IsPostBack){
                if (Session["UsuarioLogin"] != null)
                {
                    lblUsuario.Text = Session["UsuarioLogin"].ToString();

                    if(Session["UsuarioLogin"].ToString() == "admin")
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
            cargarPaginaInicio();
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

       
        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EventoSeleccionarImagen_InicioNotebook") 
            {
                SeleccionarProducto(sender, e);
            }
        }

        protected void ImageButton1_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EventoSeleccionarImagen_InicioCelular")
            {
                SeleccionarProducto(sender, e);
            }
        }

        protected void ImageButton1_Command2(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EventoSeleccionarImagen_InicioAuri")
            {
                SeleccionarProducto(sender, e);
            }
        }

        protected void ImageButton2_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "EventoSeleccionarImagen_InicioHeladera")
            {
                SeleccionarProducto(sender, e);
            }
        }


        public void SeleccionarProducto(object sender, CommandEventArgs e)
        {
            ImageButton ibtn = (sender as ImageButton);
            string[] comando = ibtn.CommandArgument.Split(';');
            Session["tabla"] = null;

            if (Session["tabla"] == null)
            {
                Session["tabla"] = crearTabla();
            }

            ((DataTable)Session["tabla"]).Rows.Add(comando[0], comando[1], comando[2], comando[3], comando[4], comando[5]);
            Session["NombreProducto"] = comando[0];
            Session["PrecioUnitario"] = comando[4];
            Session["Stock"] = comando[5];
            Response.Redirect("~/ProductoSeleccionado.aspx");
        }

        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre_P");
            dt.Columns.Add("Imagen_P");
            dt.Columns.Add("Detalle_P");
            dt.Columns.Add("Marca_P");
            dt.Columns.Add("PrecioUnitario_P");
            dt.Columns.Add("Stock_P");

            return dt;
        }

        
    }
}