using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class Prospecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["id"] != null)
                {
                    txtId.Text = Session["id"].ToString();
                    int id = Convert.ToInt32(Session["id"].ToString());
                    Conexion c = new Conexion();
                    DataTable dt = c.ListadoProspectos(id);

                    txtNombre.Text = dt.Rows[0][1].ToString();
                    txtCorreo.Text = dt.Rows[0][2].ToString();
                    txtFecha.Text = Convert.ToDateTime(dt.Rows[0][3].ToString()).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProspectoListado.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string fecha = txtFecha.Text;
            string respuesta = "";
            Conexion c = new Conexion();

            if (id == 0)
            {
                respuesta = c.InsertProspecto(nombre, correo, fecha);
            }
            else
            {
                respuesta = c.UpdateProspecto(id, nombre, correo, fecha);
            }

            if (respuesta == "insPro" || respuesta == "updPro")
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "Popup",
                    "Swal.fire({" +
                        "icon: 'success'," +
                        "title: 'Excelente'," +
                        "text: 'Datos guardados correctamente'})" +
                    ".then((result) => {"+
                        "window.location.href = 'Menu.aspx';"+
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