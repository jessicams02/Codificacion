using System;
using System.Collections.Generic;
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

        }

        protected void gvEntrevistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int id = Convert.ToInt32(gvEntrevistas.DataKeys[index].Value.ToString());
                string deltequer = "delete from yourtablename where id='" + id + "'";
            }
        }
    }
}