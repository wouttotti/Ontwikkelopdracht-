using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Zoeken : System.Web.UI.Page
    {
        public Classes.Administratie administratie = new Classes.Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
        }  
 
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            BoundField bfield1 = new BoundField();
            bfield1.HeaderText = "Titel";
            bfield1.DataField = "Titel";
            GvItems.Columns.Add(bfield1);
            dt.Columns.Add(new DataColumn("Titel", typeof(string)));

            BoundField bfield2 = new BoundField();
            bfield2.HeaderText = "Jaar";
            bfield2.DataField = "Jaar";
            GvItems.Columns.Add(bfield2);
            dt.Columns.Add(new DataColumn("Jaar", typeof(int)));

            BoundField bfield3 = new BoundField();
            bfield3.HeaderText = "Score";
            bfield3.DataField = "Score";
            GvItems.Columns.Add(bfield3);
            dt.Columns.Add(new DataColumn("Score", typeof(double)));

            ImageField bfield4 = new ImageField();
            bfield4.DataImageUrlField = "Afbeelding";
            bfield4.ControlStyle.Width = 130;
            bfield4.ControlStyle.Height = 190;
            GvItems.Columns.Add(bfield4);
            dt.Columns.Add(new DataColumn("Afbeelding", typeof(string)));
            
            if(DdlSoort.SelectedItem.ToString() == "Anime")
            {
                BoundField bfield5 = new BoundField();
                bfield5.HeaderText = "Typen";
                bfield5.DataField = "Typen";
                GvItems.Columns.Add(bfield5);
                dt.Columns.Add(new DataColumn("Typen", typeof(string)));
                BoundField bfield6 = new BoundField();
                bfield6.HeaderText = "Afleveringen";
                bfield6.DataField = "Afleveringen";
                GvItems.Columns.Add(bfield6);
                dt.Columns.Add(new DataColumn("Afleveringen", typeof(int)));
            }
            else if(DdlSoort.SelectedItem.ToString() == "Manga")
            {
                BoundField bfield5 = new BoundField();
                bfield5.HeaderText = "Typen";
                bfield5.DataField = "Typen";
                GvItems.Columns.Add(bfield5);
                dt.Columns.Add(new DataColumn("Typen", typeof(string)));
                BoundField bfield6 = new BoundField();
                bfield6.HeaderText = "Volumes";
                bfield6.DataField = "Volumes";
                GvItems.Columns.Add(bfield6);
                dt.Columns.Add(new DataColumn("Volumes", typeof(int)));
                BoundField bfield7 = new BoundField();
                bfield7.HeaderText = "Hoofdstukken";
                bfield7.DataField = "Hoofdstukken";
                GvItems.Columns.Add(bfield7);
                dt.Columns.Add(new DataColumn("Hoofdstukken", typeof(int)));
            }
            else
            {
                BoundField bfield5 = new BoundField();
                bfield5.HeaderText = "Serie";
                bfield5.DataField = "Serie";
                GvItems.Columns.Add(bfield5);
                dt.Columns.Add(new DataColumn("Serie", typeof(string)));
                BoundField bfield6 = new BoundField();
                bfield6.HeaderText = "Manga";
                bfield6.DataField = "Manga";
                GvItems.Columns.Add(bfield6);
                dt.Columns.Add(new DataColumn("Manga", typeof(string)));
                BoundField bfield7 = new BoundField();
                bfield7.HeaderText = "Kenmerken";
                bfield7.DataField = "Kenmerken";
                GvItems.Columns.Add(bfield7);
                dt.Columns.Add(new DataColumn("Kenmerken", typeof(string)));
                BoundField bfield8 = new BoundField();
                bfield8.HeaderText = "Tags";
                bfield8.DataField = "Tags";
                GvItems.Columns.Add(bfield8);
                dt.Columns.Add(new DataColumn("Tags", typeof(string)));
            }
            return dt;
        }

        protected void btnzoeken_Click(object sender, EventArgs e)
        {
            GvItems.DataSource = null;
            GvItems.Columns.Clear();
            List<Classes.Item> items = administratie.ZoekItems(TbZoeken.Text, DdlSoort.SelectedItem.ToString());
            DataTable dt = GetData();
            foreach(Classes.Item Temp in items)
            {
                if(Temp is Classes.Manga)
                {
                    Classes.Manga Manga = Temp as Classes.Manga;
                    dt.Rows.Add(Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Manga.Type, Manga.Volumes, Manga.Hoofdstukken);
                }
                else if (Temp is Classes.Anime)
                {
                    Classes.Anime Anime = Temp as Classes.Anime;
                    dt.Rows.Add(Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Anime.Type, Anime.Afleveringen);
                }
                else
                {
                    string Anime = "";
                    string Manga = "";
                    Classes.Personage Personage = Temp as Classes.Personage;
                    List<Classes.Item> PersonageSubItem = administratie.PersonageTitel(Personage.Item_ID);
                    foreach(Classes.Item Temp2 in PersonageSubItem)
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
                    dt.Rows.Add(Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Anime, Manga, Personage.Kenmerken, Personage.Tags);
                }
            }
            GvItems.DataSource = dt;
            GvItems.DataBind();
        }
    }
}