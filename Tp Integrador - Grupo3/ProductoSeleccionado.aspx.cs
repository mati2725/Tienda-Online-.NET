using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class MostrarProducto : System.Web.UI.Page
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

            if (Session["tabla"] != null)
            {
                string nombre = Session["NombreProducto"].ToString();
                SqlDataSource1.SelectCommand = "Select [Nombre_P], [Imagen_P], [Nombre_M], [PrecioUnitario_P], [Stock_P], [Detalle_P] FROM Productos INNER JOIN Marcas ON IdMarca_p = IdMarca_M WHERE [Nombre_P] = '" + nombre +"'" ;            
            }
            if (Session["Stock"].ToString() == "0")
            {
                lblNoStock.Text = "No hay stock disponible de este producto";
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
            Session["nombreProducto"] = null;
            Response.Redirect("~/MostrarProductos.aspx");
        }




        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            if (Session["UsuarioLogin"] != null)
            {

                if (Convert.ToInt32(Session["Stock"]) >= 1)
                {
                    Session["NombreProductoCarrito"] = Session["NombreProducto"];
                    Session["PrecioUnitarioCarrito"] = Session["PrecioUnitario"];
                    Session["nombreProducto"] = null;
                    Session["Comprando"] = 1;

                    foreach (ListViewItem item in ListView1.Items)
                    {
                        DropDownList st = (DropDownList)item.FindControl("ddlCantidad");
                        Session["CantStock"] = st.SelectedItem.Text;
                    }
                    Response.Redirect("~/Usuario/Carrito.aspx");
                }

                else
                {
                    Response.Redirect("~/Usuario/Carrito.aspx");
                }
            }
            else
            {
                lblNoIniciaSesion.Text = "No se puede agregar productos al carrito sin haber iniciado sesion."; 
                Response.AddHeader("REFRESH","4;URL=IniciarSesion.aspx");
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList stockddl = (DropDownList)e.Item.FindControl("ddlCantidad");
            int stock = Convert.ToInt32(Session["Stock"]);
            if (stock == 0)
            {
                stockddl.Items.Add("0");
            }
            else
            {
                for (int i = 1; i <= stock; i++)
                {
                    stockddl.Items.Add(i.ToString());
                }
            }
            
        }

        
    }
}