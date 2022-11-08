using Business.CategoriasModule;
using Business.MarcasModule;
using Business.ProductosModule;
using Entities.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Tp_Integrador___Grupo3
{
    public partial class GestionProductos : System.Web.UI.Page
    {

        private ProductosModule productosModule = new ProductosModule(); 

        void LlenarCategorias(ref DropDownList ddl)
        {
           new CategoriasModule().LlenarDDL(ref ddlCategorias);

        }
        void LLenarMarcas(ref DropDownList ddl)
        {
            new MarcasModule().LlenarDropDownList(ref ddlMarcas);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdProductos.DataSource = productosModule.GetProductos();
                grdProductos.DataBind();
                LlenarCategorias(ref ddlCategorias);
                LLenarMarcas(ref ddlMarcas);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["NombreProducto"] = TextBox1.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }


        public void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDetalle.Text = "";
            txtPrecio.Text = "";
            txtImagen.Text =  "";
            txtStock.Text = "";
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var Producto = new ProductosModel();
            Producto.Nombre = txtNombre.Text.TrimEnd().TrimStart();
            Producto.Detalle = txtDetalle.Text.TrimEnd().TrimStart();
            Producto.IdCategoria = Convert.ToInt32(ddlCategorias.SelectedValue);
            Producto.IdMarca = Convert.ToInt32(ddlMarcas.SelectedValue);
            Producto.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
            Producto.Stock = Convert.ToInt32(txtStock.Text);
            Producto.URLProductos = txtImagen.Text.TrimEnd().TrimStart();

            var estado = productosModule.AgregarProducto(Producto);
            lblMensaje.Text = "";
            if (estado == 1)
            {

                grdProductos.DataSource = productosModule.GetProductos();
                grdProductos.DataBind();
                lblNueva.ForeColor = System.Drawing.Color.Green;
                lblNueva.Text = "Se realizó la operación con exito";
                LimpiarCampos();

            }
            else
            {
                if(estado == -1)
                {
                    lblNueva.ForeColor = System.Drawing.Color.Red;
                    lblNueva.Text = "No se pudo realizar la operacion";
                    LimpiarCampos();
                }
                else
                {
                    lblNueva.ForeColor = System.Drawing.Color.Red;
                    lblNueva.Text = "Producto existente";
                }

            }
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {

            grdProductos.EditIndex = e.NewEditIndex;
            grdProductos.DataSource = productosModule.GetProductos();
            grdProductos.DataBind();
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdProducto = Convert.ToInt32(((Label)grdProductos.Rows[e.RowIndex].FindControl("lblId")).Text);
            bool Estado = productosModule.EliminarProducto(IdProducto);

            grdProductos.DataSource = productosModule.GetProductos();
            grdProductos.DataBind();

       
            if (Estado)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Operacion Realizada";
            }
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            var Productos = new ProductosModel();
            Productos.IdProducto = Convert.ToInt32(((Label)grdProductos.Rows[e.RowIndex].FindControl("lblId")).Text);
            Productos.Nombre = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            Productos.Detalle = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtDetalle")).Text;
            Productos.IdCategoria = Convert.ToInt32(((DropDownList)grdProductos.Rows[e.RowIndex].FindControl("ddlCategoriasEditar")).SelectedValue);
            Productos.IdMarca = Convert.ToInt32(((DropDownList)grdProductos.Rows[e.RowIndex].FindControl("ddlMarcasEditar")).SelectedValue);
            Productos.PrecioUnitario = Convert.ToDecimal(((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtPrecio")).Text);
            Productos.Stock = Convert.ToInt32(((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtStock")).Text);
            Productos.URLProductos = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtImagen")).Text;

            var estado = productosModule.ActualizarProducto(Productos);
            lblNueva.Text = "";

            if (estado == 1)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Se realizó la operación con exito";
            }
            else
            {
                if (estado == -1)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "No se pudo realizar la operacion";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Producto existente";
                }
            }

            grdProductos.EditIndex = -1;
            grdProductos.DataSource = productosModule.GetProductos();
            grdProductos.DataBind();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProductos.EditIndex = -1;
            grdProductos.DataSource = productosModule.GetProductos();
            grdProductos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdProductos.DataSource = productosModule.BuscarProductos(txtBuscar.Text);
            grdProductos.DataBind();
            txtBuscar.Text = "";
        }


    }
}