using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class ListadoProspectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion c = new Conexion();
                DataTable dt = c.ListadoProspectos(0);
                if (dt.Rows.Count > 0)
                {
                    gvProspectos.DataSource = dt;
                    gvProspectos.DataBind();
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
                        "text: 'Aún no hay prospectos registrados, por favor da de alta alguno'})" +
                    ".then((result) => {" +
                        "window.location.href = 'Prospecto.aspx';" +
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
            Response.Redirect("Prospecto.aspx");
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

        protected void btnEditaProspectos_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Session["id"] = id;
            Response.Redirect("Prospecto.aspx");
        }

        protected void btnEliminaProspecto_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Conexion c = new Conexion();

            string respuesta = c.DeleteProspecto(id);
            if (respuesta == "delPro")
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'success'," +
                        "title: 'Excelente'," +
                        "text: 'Prospecto eliminado correctamente'})" +
                    ".then((result) => {" +
                        "window.location.href = 'ProspectoListado.aspx';" +
                    "});"
                        ,
                    true);
            }
            else
            {
                if (respuesta.Contains("FK"))
                {
                    ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'error'," +
                        "title: 'Error'," +
                        "text: 'Para eliminar este prospecto debe eliminar las entrevistas vinculadas a este'})"+
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
}