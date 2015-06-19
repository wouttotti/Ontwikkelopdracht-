using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using AnimePlanet_Ontwikkelopdracht.Classes;

namespace AnimePlanet_Ontwikkelopdracht
{
    public partial class Lijsten : System.Web.UI.Page
    {
        Administratie administratie = new Administratie();
        protected void Page_Load(object sender, EventArgs e)
        {
            LbError.Visible = false;
            System.Web.UI.WebControls.ImageField DataColumn;

            try
            {
                DataColumn = GvItemsLijst.Columns[4] as System.Web.UI.WebControls.ImageField;
                DataColumn.ControlStyle.Width = 130;
                DataColumn.ControlStyle.Height = 190;
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        protected void BtnAnime_Click(object sender, EventArgs e)
        {
            GvItemsLijst.DataSource = null;
            GvItemsLijst.Columns.Clear();
            List<Item> items = administratie.GebruikerLijst("Anime", Session["Email"].ToString());
            DataTable dt = administratie.ItemsDataTable("Anime");
            if(dt.Rows.Count == 0)
            {
                LbError.Text = "Je hebt nog geen anime in je lijst.";
                LbError.ForeColor = System.Drawing.Color.Red;
                LbError.Visible = true;
            }
            foreach(DataColumn dc in dt.Columns)
            {
                if(dc.ColumnName == "Afbeelding")
                {
                    ImageField IF = new ImageField();
                    IF.ControlStyle.Height = 190;
                    IF.ControlStyle.Width = 130;
                    IF.DataImageUrlField = dc.ColumnName;
                    GvItemsLijst.Columns.Add(IF);
                }
                else if(dc.ColumnName != "ButtonID")
                {
                    BoundField BF = new BoundField();
                    BF.HeaderText = dc.ColumnName;
                    BF.DataField = dc.ColumnName;
                    GvItemsLijst.Columns.Add(BF);
                }
            }

            foreach(Item Temp in items)
            {  
                Anime Anime = Temp as Anime;
                dt.Rows.Add(Temp.Item_ID, Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Anime.Type, Anime.Afleveringen, Temp.Item_ID);
            }
            GvItemsLijst.DataSource = dt;
            GvItemsLijst.DataBind();
        }

        protected void BtnManga_Click(object sender, EventArgs e)
        {
            GvItemsLijst.DataSource = null;
            GvItemsLijst.Columns.Clear();
            List<Item> items = administratie.GebruikerLijst("Manga", Session["Email"].ToString());
            DataTable dt = administratie.ItemsDataTable("Manga");
            if (dt.Rows.Count == 0)
            {
                LbError.Text = "Je hebt nog geen manga in je lijst.";
                LbError.ForeColor = System.Drawing.Color.Red;
                LbError.Visible = true;
            }
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "Afbeelding")
                {
                    ImageField IF = new ImageField();
                    IF.ControlStyle.Height = 190;
                    IF.ControlStyle.Width = 130;
                    IF.DataImageUrlField = dc.ColumnName;
                    GvItemsLijst.Columns.Add(IF);
                }
                else if (dc.ColumnName != "ButtonID")
                {
                    BoundField BF = new BoundField();
                    BF.HeaderText = dc.ColumnName;
                    BF.DataField = dc.ColumnName;
                    GvItemsLijst.Columns.Add(BF);
                }
            }

            foreach (Item Temp in items)
            {
                Manga Manga = Temp as Manga;
                dt.Rows.Add(Temp.Item_ID, Temp.Titel, Temp.Jaar, Temp.GemiddeldeScore, Temp.Afbeelding, Manga.Type, Manga.Volumes, Manga.Hoofdstukken, Temp.Item_ID);
            }
            GvItemsLijst.DataSource = dt;
            GvItemsLijst.DataBind();
        }
    }
}