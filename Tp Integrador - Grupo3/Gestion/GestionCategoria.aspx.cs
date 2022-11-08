using Business.CategoriasModule;
using Entities.Categorias;
using System;
using System.Web.UI.WebControls;



namespace Tp_Integrador___Grupo3
{
    public partial class GestionCategoria : System.Web.UI.Page
    {

        private readonly CategoriasModule _CategoriaModule = new CategoriasModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdCategoria.DataSource = _CategoriaModule.GetCategorias();
                grdCategoria.DataBind();
            }
        }

        protected void grdCategoria_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCategoria.EditIndex = e.NewEditIndex;
            grdCategoria.DataSource = _CategoriaModule.GetCategorias();
            grdCategoria.DataBind();

        }
        protected void grdCategoria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCategoria.EditIndex = -1;
            grdCategoria.DataSource = _CategoriaModule.GetCategorias();
            grdCategoria.DataBind();
        }

        protected void grdCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var Categoria = new CategoriasModel();
            Categoria.IdCategoria = Convert.ToInt32(((Label)grdCategoria.Rows[e.RowIndex].FindControl("lblIdCategoria")).Text);
            Categoria.NombreCategoria = ((TextBox)grdCategoria.Rows[e.RowIndex].FindControl("txtNombreCategoria")).Text.TrimStart().TrimEnd();

            int Estado = _CategoriaModule.Actualizar(Categoria);

            grdCategoria.EditIndex = -1;
            grdCategoria.DataSource = _CategoriaModule.GetCategorias();
            grdCategoria.DataBind();

            lblNuevaCategoria.Text = "";

            if (Estado ==1)
            {
                lblMensaje.Text = "Se pudo realizar la operacion";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                LimpiarCampos();
            }
            else if(Estado == -1)
            {
                lblMensaje.Text = "No se pudo realizar la operacion";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
            } else
            {
                lblMensaje.Text = "Nombre de categoria ya existente";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
            }

        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            var Categorias = new CategoriasModel();
            Categorias.NombreCategoria = txtNuevaCategoria.Text.Trim();
            var estado = _CategoriaModule.Agregar(Categorias);

            lblMensaje.Text = "";

            if (estado== 1)
            {
                grdCategoria.DataSource = _CategoriaModule.GetCategorias();
                grdCategoria.DataBind();
                lblNuevaCategoria.Text = "Se realizó la operación con exito";
                lblNuevaCategoria.ForeColor = System.Drawing.Color.Green;
                LimpiarCampos();
            }
            else
            {
                if(estado== -1)
                { 

                lblNuevaCategoria.Text = "No se pudo realizar la operacion";
                lblNuevaCategoria.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
                 }
                
                else
                {
                    lblNuevaCategoria.Text = "Categoria Existente";
                    lblNuevaCategoria.ForeColor = System.Drawing.Color.Red;
                    LimpiarCampos();
                }
            }

        }

        public void LimpiarCampos()
        {
            txtNuevaCategoria.Text = "";
        }

        protected void grdCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdCategoria = Convert.ToInt32(((Label)grdCategoria.Rows[e.RowIndex].FindControl("lblIdCategoria")).Text);
            bool estado = _CategoriaModule.Eliminar(IdCategoria);

            grdCategoria.DataSource = _CategoriaModule.GetCategorias();
            grdCategoria.DataBind();

            lblNuevaCategoria.Text= "";

            if (estado)
            {
                
                lblMensaje.Text = "Se realizó la operación con exito";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operacion";
                lblMensaje.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdCategoria.DataSource = _CategoriaModule.BuscarCategorias(txtBuscar.Text);
            grdCategoria.DataBind();
            txtBuscar.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["nombreProducto"] = TextBox2.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void grdCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategoria.PageIndex = e.NewPageIndex;
            grdCategoria.DataSource = _CategoriaModule.BuscarCategorias(txtBuscar.Text);
            grdCategoria.DataBind();
        }
    }
}