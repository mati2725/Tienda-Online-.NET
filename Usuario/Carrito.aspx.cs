using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3.Usuario
{
    public partial class Carrito : System.Web.UI.Page
    {
        int repetido = 0;
        decimal total;
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
                    }
                    else
                    {
                        HyperLink1.NavigateUrl = "~/Usuario/Carrito.aspx";
                        HyperLink1.Text = "Carrito";
                        HyperLink2.NavigateUrl = "~/Usuario/MiCuenta.aspx";
                        HyperLink2.Text = "Mi Cuenta";
                    }
                }
                else
                {
                    UsuarioL = "";
                    lblUsuario.Text = UsuarioL;
                }
            }
            
            if (Application["Total"] == null)
            {
                Application["Total"] = 0;
            }

            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = CrearCarrito();
            }

            agregarFila((DataTable)(Session["Carrito"]));

            GridView1.DataSource = (DataTable)Session["Carrito"];
            GridView1.DataBind();
            //no se repitan productos
            foreach (GridViewRow row in GridView1.Rows)
            {
                DataTable carrito = (DataTable)Session["Carrito"];
                if (Session["NombreProductoCarrito"].ToString() == row.Cells[0].Text.ToString())
                {
                    repetido++;
                }

                if (repetido == 2)
                {
                    carrito.Rows.RemoveAt(row.RowIndex);
                }
                //no se repitan productos
                //Sumar total; precio = row 2, cant = row 3.
                else
                {
                    int cant;
                    decimal precio;

                    precio = Convert.ToDecimal(row.Cells[2].Text);
                    cant = Convert.ToInt32(row.Cells[3].Text);

                    total += (precio * cant);

                }
            }

            Application["Total"] = total;

            lblTotal.Text = Application["Total"].ToString();

            if (Convert.ToInt32(Session["Comprando"]) == 1)
            {
                Session["Comprando"] = 0;
                Response.Redirect("~/Inicio.aspx");
            }
        }



        public DataTable CrearCarrito()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("Nombre", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("Precio", System.Type.GetType("System.Double"));
            dt.Columns.Add(columna);
            columna = new DataColumn("Cantidad", System.Type.GetType("System.Int32"));
            dt.Columns.Add(columna);
            return dt;
        }

        public void agregarFila(DataTable carrito)
        {
            DataRow dr = carrito.NewRow();

            if (Convert.ToInt32(Session["Comprando"]) == 1)
            {
                dr["Nombre"] = Session["NombreProductoCarrito"].ToString();
                dr["Precio"] = Convert.ToDouble(Session["PrecioUnitarioCarrito"]);
                dr["Cantidad"] = Convert.ToInt32(Session["CantStock"]);
                carrito.Rows.Add(dr);
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cant;
            decimal precio;
            DataTable dt = (DataTable)Session["Carrito"];
            dt.Rows.RemoveAt(e.RowIndex);

            Session["Carrito"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            total = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                precio = Convert.ToDecimal(row.Cells[2].Text);
                cant = Convert.ToInt32(row.Cells[3].Text);
                total += (precio * cant);
            }
            Application["Total"] = total;
            lblTotal.Text = Application["Total"].ToString();
            if (total == 0)
            {
                Session["Comprando"] = null;
            }
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            
        }
    }
}                   