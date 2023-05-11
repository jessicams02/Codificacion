using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class Vacante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["id"] != null && Session["id"].ToString() != "0")
                {
                    txtId.Text = Session["id"].ToString();
                    int id = Convert.ToInt32(Session["id"].ToString());
                    Conexion c = new Conexion();
                    DataTable dt = c.ListadoVacantes(id);

                    txtArea.Text = dt.Rows[0][1].ToString();
                    txtSueldo.Text = dt.Rows[0][2].ToString();
                    chbActivo.Checked = Convert.ToBoolean(dt.Rows[0][3].ToString());
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VacanteListado.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string area = txtArea.Text;
            string sld = txtSueldo.Text.Replace("$", "");
            sld = sld.Replace(",", "");
            double sueldo = Convert.ToDouble(sld);
            Boolean activo = chbActivo.Checked;
            string respuesta = "";
            Conexion c = new Conexion();

            if (id == 0)
            {
                respuesta = c.InsertVacante(area, sueldo, activo);
            }
            else
            {
                respuesta = c.UpdateVacante(id, area, sueldo, activo);
            }


            if (respuesta == "insVac" || respuesta == "updVac")
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