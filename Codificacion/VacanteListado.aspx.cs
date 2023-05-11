using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class VacanteListado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion c = new Conexion();
                DataTable dt = c.ListadoVacantes(0);
                if (dt.Rows.Count > 0)
                {
                    gvVacantes.DataSource = dt;
                    gvVacantes.DataBind();
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
                        "text: 'Aún no hay vacantes registradas, por favor da de alta alguna'})" +
                    ".then((result) => {" +
                        "window.location.href = 'Vacante.aspx';" +
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
            Response.Redirect("Vacante.aspx");
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

        protected void btnEditaVacante_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Session["id"] = id;
            Response.Redirect("Vacante.aspx");
        }

        protected void btnEliminaVacante_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Conexion c = new Conexion();

            string respuesta = c.DeleteVacante(id);
            if (respuesta == "delVac")
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'success'," +
                        "title: 'Excelente'," +
                        "text: 'Vacante eliminada correctamente'})" +
                    ".then((result) => {" +
                        "window.location.href = 'VacanteListado.aspx';" +
                    "});"
                        ,
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