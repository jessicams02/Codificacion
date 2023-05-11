using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Codificacion
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnVacante_Click(object sender, EventArgs e)
        {
            Response.Redirect("VacanteListado.aspx");
        }

        protected void btnProspecto_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProspectoListado.aspx");
        }

        protected void btnEntrevista_Click(object sender, EventArgs e)
        {
            Response.Redirect("EntrevistaListado.aspx");
        }
    }
}