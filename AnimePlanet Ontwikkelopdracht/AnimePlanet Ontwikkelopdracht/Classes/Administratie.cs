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

        public bool ToevoegenAanLijst(int Item_ID, string email)
        {
            string SelectedItemSql = "SELECT * FROM ITEM WHERE ITEM_ID = " + Item_ID;
            List<Item> ItemCheck = Connectie.GetItems(SelectedItemSql);
            string LijstItemSql = "SELECT * FROM ITEM WHERE ITEM_ID IN (SELECT ITEM_ID FROM LIJST_ITEM WHERE LIJST_ID IN (SELECT LIJST_ID FROM LIJST WHERE GEBRUIKER_ID = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '"+email+"')))";
            List<Item> LijstItems = Connectie.GetItems(LijstItemSql);
            foreach (Item Temp in ItemCheck)
            {
                if (Temp.Soort != "Personage")
                {
                    foreach (Item Temp2 in LijstItems)
                    {
                        if (Temp2.Item_ID != Temp.Item_ID)
                        {
                            string sql = "INSERT INTO LIJST_ITEM (LIJSTITEM_ID, LIJST_ID, ITEM_ID) VALUES (SEQ_LIJST_ITEM.NEXTVAL, (SELECT LIJST_ID FROM LIJST WHERE NAAM = '" + Temp2.Soort + "' AND GEBRUIKER_ID = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + email + "')), " + Item_ID + ")";
                            Connectie.Insert(sql);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool VolgerToevoegen(int Gebruiker_ID, string email)
        {
            return true;
        }

        public DataTable ZoekenNaarGebruikers(string NaamEmail)
        {
            List<Gebruiker> Gebruikers = new List<Gebruiker>();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Naam", typeof(string)));
            string sqlEmail = "SELECT * FROM GEBRUIKER WHERE EMAIL LIKE '%" + NaamEmail + "%'";
            string sqlNaam = "SELECT * FROM GEBRUIKER WHERE NAAM LIKE '%" + NaamEmail + "%'";
            if((Gebruikers = Connectie.GetGebruikers(sqlEmail)).Count > 0)
            {
                foreach(Gebruiker Temp in Gebruikers)
                {
                    dt.Rows.Add(Temp.Gebruiker_ID, Temp.Email, Temp.Naam);
                }
            }
            else if((Gebruikers = Connectie.GetGebruikers(sqlNaam)).Count > 0)
            {
                foreach (Gebruiker Temp in Gebruikers)
                {
                    dt.Rows.Add(Temp.Gebruiker_ID, Temp.Email, Temp.Naam);
                }
            }
            return dt;
        }

        public DataTable GebruikerVolger(string Email)
        {
            List<Gebruiker> Volgers = new List<Gebruiker>();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Naam", typeof(string)));
            string sqlEmail = "SELECT * FROM GEBRUIKER WHERE GEBRUIKER_ID IN (SELECT Volger FROM VOLGER WHERE GEBRUIKER = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + Email + "'))";
            if((Volgers = Connectie.GetGebruikers(sqlEmail)).Count > 0)
            {
                foreach(Gebruiker Temp in Volgers)
                {
                    dt.Rows.Add(Temp.Email, Temp.Naam);
                }
            }
            return dt;
        }
    }
}