using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AnimePlanet_Ontwikkelopdracht.Classes;
using AnimePlanet_Ontwikkelopdracht;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Zoeken : System.Web.UI.Page
    {
        public Administratie administratie = new Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ImageField DataColumn;

            try
            {
                DataColumn = GvItems.Columns[4] as System.Web.UI.WebControls.ImageField;
                DataColumn.ControlStyle.Width = 130;
                DataColumn.ControlStyle.Height = 190;
            }
            catch (ArgumentOutOfRangeException)
            { }
            
        }  


        protected void btnzoeken_Click(object sender, EventArgs e)
        {
            LbError.Visible = false;
            GvItems.DataSource = null;
            ButtonField BTF = new ButtonField();
            GvItems.Columns.Clear();
            List<Item> items = administratie.ZoekItems(TbZoeken.Text, DdlSoort.SelectedItem.ToString());
            DataTable dt = administratie.ItemsDataTable(DdlSoort.SelectedItem.ToString());
            foreach(DataColumn dc in dt.Columns)
            {
                if(dc.ColumnName == "Afbeelding")
                {
                    ImageField IF = new ImageField();
                    IF.ControlStyle.Height = 190;
                    IF.ControlStyle.Width = 130;
                    IF.DataImageUrlField = dc.ColumnName;
                    GvItems.Columns.Add(IF);
                }
                else if(dc.ColumnName != "ButtonID")
                {
                    BoundField BF = new BoundField();
                    BF.HeaderText = dc.ColumnName;
                    BF.DataField = dc.ColumnName;
                    GvItems.Columns.Add(BF);
                }
            }


            if (DdlSoort.SelectedItem.ToString() == "Anime" || DdlSoort.SelectedItem.ToString() == "Manga")
            {
                BTF.ButtonType = new ButtonType();
                BTF.CommandName = "Add";
                BTF.Text = "Add";
                GvItems.Columns.Add(BTF);
            }

            foreach(Item Temp in items)
            {
                if(Temp is Manga)
                {
                    Manga Manga = Temp as Manga;
                    dt.Rows.Add(Temp.Item_ID, Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Manga.Type, Manga.Volumes, Manga.Hoofdstukken, Temp.Item_ID);

                }
                else if (Temp is Anime)
                {
                    
                    Anime Anime = Temp as Anime;
                    dt.Rows.Add(Temp.Item_ID, Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Anime.Type, Anime.Afleveringen, Temp.Item_ID);
                    
                }
                else
                {
                    string Anime = "";
                    string Manga = "";
                    Personage Personage = Temp as Personage;
                    List<Item> PersonageSubItem = administratie.PersonageTitel(Personage.Item_ID);
                    foreach(Item Temp2 in PersonageSubItem)
                    {
                        if(Temp2.Soort == "Anime")
                        {
                            Anime = Temp2.Titel;
                        }
                        else
                        {
                            Manga = Temp2.Titel;
                        }
                    }
                    dt.Rows.Add(Temp.Item_ID, Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Anime, Manga, Personage.Kenmerken, Personage.Tags);
                }
            }
            GvItems.DataSource = dt;
            GvItems.DataBind();
        }
        public void gv_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Add"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int Item_ID = Convert.ToInt32(GvItems.Rows[index].Cells[0].Text);
              
                if (administratie.ToevoegenAanLijst(Item_ID, Convert.ToString(Session["EMAIL"])) == true)
                {
                    LbError.Text = "Item is toegevoegd.";
                    LbError.ForeColor = System.Drawing.Color.Green;
                    LbError.Visible = true;
                }
                else
                {
                    LbError.Text = "Item is al in je lijst aanwezig.";
                    LbError.ForeColor = System.Drawing.Color.Red;
                    LbError.Visible = true;
                }
            }
        }
    }
}