using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class Entrevista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion c = new Conexion();
                DataTable dv = c.ListadoVacantes(0);
                DataTable dp = c.ListadoProspectos(0);

                if (dv.Rows.Count > 0 && dp.Rows.Count > 0)
                {
                    ddlVacante.DataSource = dv;
                    ddlVacante.DataBind();
                    ddlVacante.DataTextField = "area";
                    ddlVacante.DataValueField = "id";
                    ddlVacante.DataBind();
                    ddlVacante.Items.Insert(0, new ListItem("Seleccionar", ""));

                    ddlProspecto.DataSource = dp;
                    ddlProspecto.DataBind();
                    ddlProspecto.DataTextField = "nombre";
                    ddlProspecto.DataValueField = "id";
                    ddlProspecto.DataBind();
                    ddlProspecto.Items.Insert(0, new ListItem("Seleccionar", ""));
                }
                else
                {
                    if (dv.Rows.Count <= 0)
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
                    else if (dp.Rows.Count <= 0)
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

                if (Session["id"] != null && Session["id"].ToString() != "0")
                {
                    txtId.Text = Session["id"].ToString();
                    int id = Convert.ToInt32(Session["id"].ToString());
                    DataTable dt = c.ListadoEntrevistas(id);

                    ddlVacante.SelectedValue = dt.Rows[0][1].ToString();
                    ddlProspecto.SelectedValue = dt.Rows[0][2].ToString();
                    txtFecha.Text = Convert.ToDateTime(dt.Rows[0][3].ToString()).ToString("yyyy-MM-dd");
                    txtNotas.Text = dt.Rows[0][4].ToString();
                    chbReclutado.Checked = Convert.ToBoolean(dt.Rows[0][5].ToString());
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EntrevistaListado.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int idVacante = Convert.ToInt32(ddlVacante.SelectedValue);
            int idProspecto = Convert.ToInt32(ddlProspecto.SelectedValue);
            string fecha = txtFecha.Text;
            string notas = txtNotas.Text;
            Boolean reclutado = chbReclutado.Checked;
            string respuesta = "";
            Conexion c = new Conexion();

            if (id == 0)
            {
                respuesta = c.InsertEntrevista(idVacante, idProspecto, fecha, notas, reclutado);
            }
            else
            {
                respuesta = c.UpdateEntrevista(id, idVacante, idProspecto, fecha, notas, reclutado);
            }

            if (respuesta == "insEnt" || respuesta == "updEnt")
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'success'," +
                        "title: 'Excelente'," +
                        "text: 'Datos guardados correctamente'})" +
                    ".then((result) => {" +
                        "window.location.href = 'Menu.aspx';" +
                    "});"
                        ,
                    true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(
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