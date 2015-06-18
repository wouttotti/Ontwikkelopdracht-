using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Gegevens : System.Web.UI.Page
    {
        public Classes.Administratie administratie = new Classes.Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnzoeken_Click(object sender, EventArgs e)
        {
            DataTable dt = administratie.ZoekenNaarGebruikers(TbZoeken.Text);
            if(dt.Rows.Count < 1)
            {
                LbError1.Visible = true;
                LbError1.Text = "Geen gebruikers gevonden.";
                LbError1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                GvGebruikers.DataSource = dt;
                GvGebruikers.DataBind();
            }
        }
    }
}