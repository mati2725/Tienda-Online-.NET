using Business.UsuariosModule;
using DAO.UsuariosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        UsuariosModule UsuarioModel = new UsuariosModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdUsuarios.DataSource = UsuarioModel.GetUsuarios();
                grdUsuarios.DataBind();
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

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string Usuario = ((Label)grdUsuarios.Rows[e.RowIndex].FindControl("lblUsuario")).Text;
            bool Estado = UsuarioModel.EliminarUsuario(Usuario);

            grdUsuarios.DataSource = UsuarioModel.GetUsuarios();
            grdUsuarios.DataBind();

            if (Estado)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Se realizó la operación con exito";
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No se pudo realizar la operacion";
            }

        }

        protected void grdUsuarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["UsuarioVentas"] = ((Label)grdUsuarios.Rows[e.NewSelectedIndex].FindControl("lblUsuario")).Text;
            Response.Redirect("~/Usuario/HistorialDeCompras.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdUsuarios.DataSource = UsuarioModel.BuscarUsuarios(txtBuscar.Text);
            grdUsuarios.DataBind();
            txtBuscar.Text = "";
        }

        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsuarios.PageIndex = e.NewPageIndex;
            grdUsuarios.DataSource = UsuarioModel.BuscarUsuarios(txtBuscar.Text);
            grdUsuarios.DataBind();
        }
    }
}