using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Uitlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Uitloggen_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["Gebruikersnaam"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Index.aspx");
        }
    }
}