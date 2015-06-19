using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnimePlanet_Ontwikkelopdracht.Classes;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Login : System.Web.UI.Page
    {
        public Administratie Administratie = new Administratie();
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
                    Response.Redirect("Index.aspx");
                }
            }
            catch(NoDataException ex)
            {
                LbInlogError.Text = ex.Message;
                LbInlogError.ForeColor = System.Drawing.Color.Red;
                LbInlogError.Visible = true;
            }
            if(CbCookies.Checked == true)
            {
                Response.Cookies["Gebruikersnaam"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Wachtwoord"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
               Response.Cookies["Gebruikersnaam"].Value = TbInGebruikersnaam.Text.Trim();
               Response.Cookies["Wachtwoord"].Value = TbInWachtwoord.Text.Trim();
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(Administratie.GebruikersToevoegen(TbRegEmail.Text, TbRegNaam.Text, TbRegWachtwoord.Text) == true)
                {
                    LbRegistreerError.Text = "Registratie voltooid.";
                    LbRegistreerError.ForeColor = System.Drawing.Color.Green;
                    LbRegistreerError.Visible = true;
                    Session["EMAIL"] = TbRegEmail.Text;
                    Response.Redirect("Index.aspx");
                }
            }
            catch(NoDataException ex)
            {
                LbRegistreerError.Text = ex.Message;
                LbRegistreerError.ForeColor = System.Drawing.Color.Red;
                LbRegistreerError.Visible = true;
            }
        }
    }
}