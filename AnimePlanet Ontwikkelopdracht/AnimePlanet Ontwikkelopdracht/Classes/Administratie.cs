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

        /// <summary>
        /// In deze methode wordt er een gebruiker toegevoegd aan de website.
        /// </summary>
        /// <param name="email">De email/gebruikersnaam van de persoon.</param>
        /// <param name="naam">De naam van de persoon.</param>
        /// <param name="wachtwoord">Het wachtwoord dat de persoonw wil gebruiken.</param>
        /// <returns>Hij returned true als het toevoegen gelukt is.</returns>
        public bool GebruikersToevoegen(string email, string naam, string wachtwoord)
        {
            
            if (email == "")
            {
                throw new NoDataException("Vul een email in.");
            }
            else if (wachtwoord == "")
            {
                throw new NoDataException("Vul een wachtwoord in.");
            }
            else if(naam == "")
            {
                throw new NoDataException("Vul een naam in.");
            }
            else
            {
                string GebruikerCheckSql = "SELECT * FROM GEBRUIKER";
                List<Gebruiker> Gebruiker = Connectie.GetGebruikers(GebruikerCheckSql);
                if(Gebruiker.Count != 0)
                {
                    foreach(Gebruiker Temp in Gebruiker)
                    {
                        if(Temp.Email == email)
                        {
                            throw new NoDataException("Deze gebruiker bestaat al.");
                        }
                    }
                    string InsertSql = "INSERT INTO GEBRUIKER VALUES(SEQ_GEBRUIKER.NEXTVAL, '" + naam + "', '" + email + "', '" + wachtwoord + "')";
                    Connectie.Insert(InsertSql);
                   
                }
                return true;
            }
        }
        
        /// <summary>
        /// Als er gezocht wordt naar een item moet er een datatable aangemaakt worden.
        /// Deze datable bevat columns aan de hand van de gekozen soort waarnaar je zoekt.
        /// </summary>
        /// <param name="soort">Dit kan manga, anime of personage zijn.</param>
        /// <returns>Hij returned de datatable met de gekozen columns.</returns>
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

        /// <summary>
        /// De gebruiker gaat hier inloggen op de website.
        /// </summary>
        /// <param name="Email">De email van de gebruiker</param>
        /// <param name="Wachtwoord">Het wachtwoord van de gebruiker</param>
        /// <returns>Als het gelukt is returned die true.</returns>
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
                            throw new NoDataException("Wachtwoord is niet correct.");
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

        /// <summary>
        /// De gebruiker kan zoeken naar een item dat in de database zit.
        /// </summary>
        /// <param name="naam">De naam van het item waar je naar zoekt.</param>
        /// <param name="soort">De soort van het item kan manga, anime of personage zijn.</param>
        /// <returns>Hij returned een lijst met alle gevonden items.</returns>
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

        /// <summary>
        /// Als je naar een personage zoekt moet van dat personage ook de titels van bijbehorend manga of anime.
        /// </summary>
        /// <param name="id">Het id van het personage wordt meegegeven</param>
        /// <returns>Hij returned een lijst met de manga of anime waar het personage bij hoort.</returns>
        public List<Item> PersonageTitel(int id)
        {
            string sqlItem = "SELECT * FROM ITEM WHERE ITEM_ID = (SELECT MANGA FROM PERSONAGE WHERE ITEM_ID = " + id + ") or Item_ID = (SELECT SERIE FROM PERSONAGE WHERE ITEM_ID = " + id + ")";           
            return Connectie.GetItems(sqlItem);
        }

        /// <summary>
        /// Haalt van een gebruiker een lijst op met al zijn toegevoegde anime en manga.
        /// </summary>
        /// <param name="soort">De soort lijst die je wilt zien kan Manga of Anime zijn.</param>
        /// <param name="email">De email van de gebruiker waar de lijst van geladen moet worden.</param>
        /// <returns>Alle lijst items worden gereturned van de gebruiker en bijbehorende soort.</returns>
        public List<Item> GebruikerLijst(string soort, string email)
        {
            string LijstItemSql = "SELECT * FROM ITEM WHERE ITEM_ID IN (SELECT ITEM_ID FROM LIJST_ITEM WHERE LIJST_ID IN (SELECT LIJST_ID FROM LIJST WHERE GEBRUIKER_ID = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + email + "') AND NAAM = '" + soort + "'))";
            List<Item> LijstItems = Connectie.GetItems(LijstItemSql);
            return LijstItems;
        }

        /// <summary>
        /// Hier wordt een item aan een lijst toegevoegd van de gebruiker.
        /// </summary>
        /// <param name="Item_ID">Het id van de item die je wilt toevoegen.</param>
        /// <param name="email">Het email van de gebruiker waar het item moet toegevoegd worden.</param>
        /// <returns>Als het item succesvol is toegevoegd returned hij true.</returns>
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
                        if (Temp2.Item_ID == Temp.Item_ID)
                        {
                            return false;
                        }
                    }
                }
                string InsertSql = "INSERT INTO LIJST_ITEM VALUES (SEQ_LIJST_ITEM.NEXTVAL, (SELECT LIJST_ID FROM LIJST WHERE NAAM = '" + Temp.Soort + "' AND GEBRUIKER_ID = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + email + "')), " + Item_ID + ")";
                Connectie.Insert(InsertSql);
            }
            return true;
        }

        /// <summary>
        /// Hier wordt er bij de gebruiker een volger toegevoegd aan zijn lijst.
        /// </summary>
        /// <param name="Volger_ID">Het id van de persoon die je wilt gaan volgen.</param>
        /// <param name="email">Het email van de waar de volger aan toegevoegd wordt.</param>
        /// <returns>Als de gebruiker succesvol een volger heeft toegevoegd returned hij true.</returns>
        public bool VolgerToevoegen(int Volger_ID, string email)
        {
            string SelectedGebruikerSql = "SELECT * FROM GEBRUIKER WHERE GEBRUIKER_ID = '" + Volger_ID + "'";
            List<Gebruiker> GebruikerCheck = Connectie.GetGebruikers(SelectedGebruikerSql);
            string VolgerLijstSql = "SELECT * FROM GEBRUIKER WHERE GEBRUIKER_ID IN (SELECT Volger FROM VOLGER WHERE GEBRUIKER = (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + email + "'))";
            List<Gebruiker> LijstVolgers = Connectie.GetGebruikers(VolgerLijstSql);
            foreach(Gebruiker Temp in GebruikerCheck)
            {
                foreach(Gebruiker Temp2 in LijstVolgers)
                {
                    if(Temp.Gebruiker_ID == Temp2.Gebruiker_ID)
                    {
                        return false;
                    }
                }
                string InsertSql = "INSERT INTO VOLGER VALUES(SEQ_VOLGERS.nextval, (SELECT GEBRUIKER_ID FROM GEBRUIKER WHERE EMAIL = '" + email + "'), " + Volger_ID + ")";
                Connectie.Insert(InsertSql);
            }
            return true;
        }

        /// <summary>
        /// Hier wordt er gezocht naar gebruikers. Dit kan doormiddel van naam of email.
        /// </summary>
        /// <param name="NaamEmail">Dit is de email of de naam van de persoon.</param>
        /// <returns>Hij geeft een datatable terug met alle gebruikers die er gevonden zijn.</returns>
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

        /// <summary>
        /// Er wordt gezocht naar alle gebruikers de een persoon volgt.
        /// </summary>
        /// <param name="Email">De email van de persoon waarvan alle volgers gezocht moeten worden</param>
        /// <returns>Hij geeft een datatable terug met alle volgers die er gevonden zijn.</returns>
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