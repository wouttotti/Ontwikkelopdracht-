using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AnimePlanet_Ontwikkelopdracht.Classes;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Gegevens : System.Web.UI.Page
    {
        public Administratie administratie = new Classes.Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["EMAIL"] != null)
            {
                GvVolgen.DataSource = administratie.GebruikerVolger(Convert.ToString(Session["Email"]));
                GvVolgen.DataBind();
            }
        }

        protected void btnzoeken_Click(object sender, EventArgs e)
        {
            DataTable dt = administratie.ZoekenNaarGebruikers(TbZoeken.Text);
            ButtonField BTF = new ButtonField();
            if(dt.Rows.Count < 1)
            {
                LbError1.Visible = true;
                LbError1.Text = "Geen gebruikers gevonden.";
                LbError1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                BTF.ButtonType = new ButtonType();
                BTF.CommandName = "Add";
                BTF.Text = "Add";
                GvGebruikers.Columns.Add(BTF);

                GvGebruikers.DataSource = dt;
                GvGebruikers.DataBind();
            }
        }

        public void gvGebruiker_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int Item_ID = Convert.ToInt32(GvGebruikers.Rows[index].Cells[0].Text);

                if (administratie.ToevoegenAanLijst(Item_ID, Convert.ToString(Session["EMAIL"])) == true)
                {
                    LbError2.Text = "Item is toegevoegd.";
                    LbError2.ForeColor = System.Drawing.Color.Green;
                    LbError2.Visible = true;
                }
                else
                {
                    LbError2.Text = "Item is al in je lijst aanwezig.";
                    LbError2.ForeColor = System.Drawing.Color.Red;
                    LbError2.Visible = true;
                }
            }
        }
    }
}