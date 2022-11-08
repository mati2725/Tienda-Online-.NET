using Business.MarcasModule;
using Entities.Marcas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Integrador___Grupo3
{
    public partial class GestionMarca : System.Web.UI.Page
    {

        private MarcasModule marcasModule = new MarcasModule();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                grdGestionMarcas.DataSource = marcasModule.GetMarcas();
                grdGestionMarcas.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }

        protected void btnMarca_Click(object sender, EventArgs e)
        {
            var Marca = new MarcasModel();
            Marca.NombreMarca = txtNombre.Text.Trim();
            var estado = marcasModule.AgregarMarca(Marca);

            lblMensaje.Text = "";
            if (estado == 1)
            {
                lblNuevaMarca.ForeColor = Color.Green;
                lblNuevaMarca.Text = "Operacion Realizada";
                LimpiarCampos();
                grdGestionMarcas.DataSource = marcasModule.GetMarcas();
                grdGestionMarcas.DataBind();
            }
            else
            {
                if(estado == -1)
                {
                    lblNuevaMarca.ForeColor = Color.Red;
                    lblNuevaMarca.Text = "No se pudo realizar la operacion";
                    LimpiarCampos();
                }
                else
                {
                    lblNuevaMarca.ForeColor = Color.Red;
                    lblNuevaMarca.Text = "Marca existente";
                    LimpiarCampos();
                }
            }
        }

        public void LimpiarCampos()
        {
            txtNombre.Text = "";
        }

        protected void grdGestionMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdGestionMarcas.EditIndex = e.NewEditIndex;
            grdGestionMarcas.DataSource = marcasModule.GetMarcas();
            grdGestionMarcas.DataBind();
        }

        protected void grdGestionMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdGestionMarcas.EditIndex = -1;
            grdGestionMarcas.DataSource = marcasModule.GetMarcas();
            grdGestionMarcas.DataBind();
        }

        protected void grdGestionMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var Marca = new MarcasModel();
            Marca.IdMarca = Convert.ToInt32(((Label)grdGestionMarcas.Rows[e.RowIndex].FindControl("lblIdMarca")).Text);
            Marca.NombreMarca = ((TextBox)grdGestionMarcas.Rows[e.RowIndex].FindControl("txtNombreMarca")).Text.TrimStart().TrimEnd();

            int Estado = marcasModule.ActualizarMarca(Marca);

            grdGestionMarcas.EditIndex = -1;
            grdGestionMarcas.DataSource = marcasModule.GetMarcas();
            grdGestionMarcas.DataBind();

            lblNuevaMarca.Text = "";

            if (Estado==1)
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Operacion Realizada";
                LimpiarCampos();
            } else if(Estado == -2)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Nombre de marca ya existente";
                LimpiarCampos();
            } else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "No se puede realizar la operacion";
                LimpiarCampos();
            }
        }
        protected void grdGestionMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdCategoria = Convert.ToInt32(((Label)grdGestionMarcas.Rows[e.RowIndex].FindControl("lblIdMarca")).Text);
            bool Estado = marcasModule.EliminarMarca(IdCategoria);

            grdGestionMarcas.DataSource = marcasModule.GetMarcas();
            grdGestionMarcas.DataBind();         

            if (Estado)
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Operacion Realizada";

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdGestionMarcas.DataSource =marcasModule.BuscarMarcas(txtBuscar.Text);
            grdGestionMarcas.DataBind();
            txtBuscar.Text = "";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["NombreProducto"] = TextBox2.Text;
            Response.Redirect("~/MostrarProductos.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/MostrarCategorias.aspx");
        }
    }
}