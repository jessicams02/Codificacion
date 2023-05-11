using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class ListadoEntrevistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion c = new Conexion();
                DataTable dt = c.ListadoEntrevistas(0);
                if (dt.Rows.Count != 0)
                {
                    gvEntrevistas.DataSource = dt;
                    gvEntrevistas.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'warning'," +
                        "title: 'Atención'," +
                        "text: 'Aún no hay entrevistas registradas, por favor da de alta alguna'})" +
                    ".then((result) => {" +
                        "window.location.href = 'Entrevista.aspx';" +
                    "});",
                    true);
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["id"] = 0;
            Response.Redirect("Entrevista.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (listado.Visible)
            {
                listado.Visible = false;
            }
            else
            {
                listado.Visible = true;
            }
        }

        protected void btnEditaEntrevista_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Session["id"] = id;
            Response.Redirect("Entrevista.aspx");
        }

        protected void btnEliminaEntrevista_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Conexion c = new Conexion();

            string respuesta = c.DeleteEntrevista(id);
            if (respuesta == "delEnt")
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'success'," +
                        "title: 'Excelente'," +
                        "text: 'Entrevista eliminada correctamente'})" +
                    ".then((result) => {" +
                        "window.location.href = 'EntrevistaListado.aspx';" +
                    "});",
                    true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'error'," +
                        "title: 'Error'," +
                        "text: '" + respuesta + "'})",
                    true);
            }
        }
    }
}