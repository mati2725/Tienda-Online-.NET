using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Tp_Integrador___Grupo3
{
    public partial class Buscar : System.Web.UI.Page
    {
        string _Minimo;
        string _Maximo;

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
                        HyperLink3.Text = "";
                    }
                    else
                    {
                        HyperLink1.NavigateUrl = "~/Usuario/Carrito.aspx";
                        HyperLink1.Text = "Carrito";
                        HyperLink2.NavigateUrl = "~/Usuario/MiCuenta.aspx";
                        HyperLink2.Text = "Mi Cuenta";
                        HyperLink3.Text = "";
                    }
                }
                else
                {
                    UsuarioL = "";
                    lblUsuario.Text = UsuarioL;
                }
            }

            Session["Comprando"] = 0;

            if (Session["nombreProducto"] != null)
            {
                string nombre = Session["nombreProducto"].ToString();

                SqlDataSource1.SelectCommand = "SELECT * from Productos WHERE Nombre_P LIKE '" + nombre + "%' AND Estado_P = 'TRUE'";

                Session["nombreProducto"] = null;
            }

            else
            {
                SqlDataSource1.SelectCommand = "Select * from Productos WHERE Estado_P = 'TRUE'";
            }

            if (Session["IDMarca"] != null)
            {
                int ID = Convert.ToInt32(Session["IDMarca"]);
                SqlDataSource1.SelectCommand = "SELECT * From Productos WHERE IdCategoria_P =" + ID + " AND Estado_P = 'TRUE'";
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

        protected void btnMarca_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EventoSeleccionarMarca")
            {
                string Marca = e.CommandArgument.ToString();
                Session["Marca"] = Marca;
                int IntMarca = int.Parse(Marca);
                string consulta = "Select * FROM Productos WHERE IdMarca_P =" + IntMarca + "AND Estado_P = 'TRUE'";
                SqlDataSource1.SelectCommand = consulta;

                TextBox2.Text = TextBox3.Text = "";

            }
        }

        public void Button3_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------MINIMO--------------------------------------------------------------------
            if (string.IsNullOrEmpty(TextBox2.Text) == false && string.IsNullOrEmpty(TextBox3.Text) == true)
            {
                _Minimo = TextBox2.Text;
                System.Diagnostics.Debug.WriteLine(_Minimo);
                _Maximo = "";
                if (Session["Marca"] != null)
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE PrecioUnitario_P >" + _Minimo + "AND IdMarca_P =" + Convert.ToInt32(Session["Marca"]) + " AND Estado_P = 'TRUE'";
                }
                else
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE PrecioUnitario_P >" + _Minimo + " AND Estado_P = 'TRUE'";
                }
            }
            else
            //------------------------------------------MINIMO Y MAXIMO----------------------------------------------------------------
            if (string.IsNullOrEmpty(TextBox2.Text) == false && string.IsNullOrEmpty(TextBox3.Text) == false && Convert.ToInt32(TextBox2.Text) < Convert.ToInt32(TextBox3.Text))
            {
                lblError.Text = "";
                _Minimo = TextBox2.Text;
                _Maximo = TextBox3.Text;
                if (Session["Marca"] != null)
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM Productos WHERE PrecioUnitario_P >" + _Minimo + "AND PrecioUnitario_P <" + _Maximo + "AND IdMarca_P =" + Convert.ToInt32(Session["Marca"]) + " AND Estado_P = 'TRUE'";
                }
                else
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM Productos WHERE PrecioUnitario_P >" + _Minimo + "AND PrecioUnitario_P <" + _Maximo + " AND Estado_P = 'TRUE'";
                }
            }
            else if (string.IsNullOrEmpty(TextBox2.Text) == false && string.IsNullOrEmpty(TextBox3.Text) && Convert.ToInt32(TextBox2.Text) > Convert.ToInt32(TextBox3.Text))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "El precio minimo no puede ser mayor al precio maximo.";
            }
            else
          //-----------------------------------------------MAXIMO--------------------------------------------------------------------
          if (string.IsNullOrEmpty(TextBox2.Text) == true && string.IsNullOrEmpty(TextBox3.Text) == false)
            {
                _Maximo = TextBox3.Text;
                _Minimo = "";
                if (Session["Marca"] != null)
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE PrecioUnitario_P <" + _Maximo + "AND IdMarca_P =" + Convert.ToInt32(Session["Marca"]) + " AND Estado_P = 'TRUE'";
                }
                else
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE PrecioUnitario_P <" + _Maximo + " AND Estado_P = 'TRUE'";
                }
            }
            if (string.IsNullOrEmpty(TextBox2.Text) && string.IsNullOrEmpty(TextBox3.Text))
            {
                if (Session["Marca"] != null)
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE IdMarca_P =" + Convert.ToInt32(Session["Marca"]) + " AND Estado_P = 'TRUE'";
                }
                else
                {
                    SqlDataSource1.SelectCommand = "Select * from Productos WHERE Estado_P = 'TRUE'";
                }
            }
            System.Diagnostics.Debug.WriteLine(_Minimo);
            System.Diagnostics.Debug.WriteLine(_Maximo);
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarProductoImagen")
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

        protected void ButtonProductos_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "Select * from Productos WHERE Estado_P = 'TRUE'";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["nombreProducto"] = null;
            Session["Marca"] = null;
            Session["IdMarca"] = null;
            SqlDataSource1.SelectCommand = "Select * from Productos WHERE Estado_P = 'TRUE'";
            Response.Redirect("~/MostrarProductos.aspx");
        }
    }
}
