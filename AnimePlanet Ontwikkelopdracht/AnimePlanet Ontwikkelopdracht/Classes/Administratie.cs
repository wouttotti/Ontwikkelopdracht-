using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Administratie
    {

        Database Connectie = new Database();
        public Administratie()
        {

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
                    
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL = '" + naam + "' AND SOORT = 'Manga'";
                    Item = Connectie.GetItems(sqlItem);
                }
                else if(soort == "Anime")
                {
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL = '" + naam + "' AND SOORT = 'Anime'";
                    Item = Connectie.GetItems(sqlItem);
                }
                else
                {
                    string sqlItem = "SELECT * FROM ITEM WHERE TITEL = '" + naam + "' AND SOORT = 'Personage'";
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
    }
}