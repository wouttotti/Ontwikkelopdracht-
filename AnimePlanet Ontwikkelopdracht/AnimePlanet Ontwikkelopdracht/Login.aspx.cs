using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Login : System.Web.UI.Page
    {
        public Classes.Administratie Administratie = new Classes.Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            LbInlogError.Visible = false;
            LbRegistreerError.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(Administratie.Inloggen(TbInGebruikersnaam.Text, TbInWachtwoord.Text) == true)
                {
                    Session["EMAIL"] = TbInGebruikersnaam.Text;
                    Response.Redirect("Home.aspx");
                }
            }
            catch(Classes.NoDataException ex)
            {
                LbInlogError.Text = ex.Message;
                LbInlogError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}