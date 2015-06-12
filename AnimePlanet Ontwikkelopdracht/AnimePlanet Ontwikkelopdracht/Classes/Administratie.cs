using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Administratie
    {

        Database Connectie = new Database();
        public Administratie()
        {

        }

        public DataTable ItemsDataTable(string soort)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Item_ID", typeof(int)));

            dt.Columns.Add(new DataColumn("Titel", typeof(string)));

            dt.Columns.Add(new DataColumn("Jaar", typeof(int)));

            dt.Columns.Add(new DataColumn("Score", typeof(double)));

            dt.Columns.Add(new DataColumn("Afbeelding", typeof(string)));

            if (soort == "Anime")
            {
                dt.Columns.Add(new DataColumn("Typen", typeof(string)));
                
                dt.Columns.Add(new DataColumn("Afleveringen", typeof(int)));
            }
            else if (soort == "Manga")
            {
                dt.Columns.Add(new DataColumn("Typen", typeof(string)));
               
                dt.Columns.Add(new DataColumn("Volumes", typeof(int)));
             
                dt.Columns.Add(new DataColumn("Hoofdstukken", typeof(int)));
            }
            else
            {
                dt.Columns.Add(new DataColumn("Serie", typeof(string)));
                
                dt.Columns.Add(new DataColumn("Manga", typeof(string)));
                
                dt.Columns.Add(new DataColumn("Kenmerken", typeof(string)));
                
                dt.Columns.Add(new DataColumn("Tags", typeof(string)));
            }

            dt.Columns.Add(new DataColumn("ButtonID", typeof(int)));
            return dt;
        }

        public bool Inloggen(string Email, string Wachtwoord)
        {
            if(Email == "")
            {
                throw new NoDataException("Vul een email in.");
            }
            else if(Wachtwoord == "")
            {
                throw new NoDataException("Vul een wachtwoord in.");
            }
            else
            {
                string sql = "select * from gebruiker where email = '" + Email + "'";
                List<Gebruiker> Gebruiker = new List<Gebruiker>();
                Gebruiker = Connectie.GetGebruikers(sql);
                if(Gebruiker.Count != 0)
                {
                    foreach(Gebruiker Temp in Gebruiker)
                    {
                        if(Temp.Wachtwoord == Wachtwoord)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    throw new NoDataException("Gebruikersnaam bestaat niet.");
                }
            }
            return false;
        }

        public List<Item> ZoekItems(string naam, string soort)
        {
            List<Item> Item = new List<Item>();
            if (naam == "")
            {
                string sqlItem = "SELECT * FROM ITEM WHERE SOORT = '" + soort + "'";
                Item = Connectie.GetItems(sqlItem);
            }
            else
            {
                if (soort == "Manga")
                {
                    
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL LIKE '%" + naam + "%' AND SOORT = 'Manga'";
                    Item = Connectie.GetItems(sqlItem);
                }
                else if(soort == "Anime")
                {
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL LIKE '%" + naam + "%' AND SOORT = 'Anime'";
                    Item = Connectie.GetItems(sqlItem);
                }
                else
                {
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL LIKE '%" + naam + "%' AND SOORT = 'Personage'";
                    Item = Connectie.GetItems(sqlItem);
                }
            }
            return Item;
        }
        public List<Item> PersonageTitel(int id)
        {
            string sqlItem = "SELECT * FROM ITEM WHERE ITEM_ID = (SELECT MANGA FROM PERSONAGE WHERE ITEM_ID = " + id + ") or Item_ID = (SELECT SERIE FROM PERSONAGE WHERE ITEM_ID = " + id + ")";
            return Connectie.GetItems(sqlItem);
        }
        public bool ToevoegenAanLijst(int Item_ID)
        {
            return true;
        }
    }
}