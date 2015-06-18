using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;
using System.Web.Configuration;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Database
    {
        private OracleConnection connectie;
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public void ConnectieOpen()
        {
            try
            {
                connectie = new OracleConnection();
                connectie.ConnectionString = conn;
                connectie.Open();
            }
            catch
            {

                connectie.Close();
            }
        }

        public List<Gebruiker> GetGebruikers(string sql)
        {
            List<Gebruiker> Gebruiker = new List<Gebruiker>();
            int Gebruiker_ID;
            string Naam;
            string Email;
            string Wachtwoord;

            try
            {
                ConnectieOpen();
                OracleCommand Get = new OracleCommand(sql, connectie);
                OracleDataReader reader = Get.ExecuteReader();
                while (reader.Read())
                {
                    Gebruiker_ID = Convert.ToInt32(reader["GEBRUIKER_ID"]);
                    Naam = Convert.ToString(reader["NAAM"]);
                    Email = Convert.ToString(reader["EMAIL"]);
                    Wachtwoord = Convert.ToString(reader["WACHTWOORD"]);

                    Gebruiker.Add(new Gebruiker(Gebruiker_ID, Naam, Email, Wachtwoord));
                }
            }
            catch(OracleException)
            {
                connectie.Close();   
            }
            finally
            {
                connectie.Close();
            }
            return Gebruiker;
        }

        public List<Item> GetItems(string sqlItem)
        {
            
            List<Item> Items = new List<Item>();
            int Item_ID = 0;
            string Titel = "";
            int Jaar = 0;
            double Score = 0;
            string Soort = "";
            string Afbeelding = "";

            try
            {
                ConnectieOpen();
                OracleCommand GetItem = new OracleCommand(sqlItem, connectie);
                OracleDataReader readerItem = GetItem.ExecuteReader();
                OracleDataAdapter Adapter = new OracleDataAdapter(GetItem);

                while (readerItem.Read())
                {

                    Item_ID = Convert.ToInt32(readerItem["ITEM_ID"]);
                    Titel = Convert.ToString(readerItem["TITEL"]);
                    Jaar = Convert.ToInt32(readerItem["JAAR"]);
                    Score = Convert.ToDouble(readerItem["GEMIDDELDESCORE"]);
                    Soort = Convert.ToString(readerItem["SOORT"]);
                    Afbeelding = Convert.ToString(readerItem["AFBEELDING"]);

                    string sqlItemSub = "SELECT * FROM " + Soort + " WHERE ITEM_ID = (SELECT ITEM_ID FROM ITEM WHERE TITEL = '" + Titel + "' AND SOORT = '" + Soort + "')";
                    OracleCommand GetItemSub = new OracleCommand(sqlItemSub, connectie);
                    OracleDataReader readerItemSub = GetItemSub.ExecuteReader();
                    while (readerItemSub.Read())
                    {
                        if (Soort == "Manga")
                        {
                            string Type;
                            int Volumes;
                            int Hoofdstukken;
                            Type = Convert.ToString(readerItemSub["TYPEN"]);
                            Volumes = Convert.ToInt32(readerItemSub["VOLUMES"]);
                            Hoofdstukken = Convert.ToInt32(readerItemSub["HOOFDSTUKKEN"]);
                            Items.Add(new Manga(Titel, Jaar, Score, Soort, Item_ID, Type, Volumes, Hoofdstukken, Afbeelding));
                        }
                        else if (Soort == "Anime")
                        {
                            string Type;
                            int Afleveringen;
                            Type = Convert.ToString(readerItemSub["TYPEN"]);
                            Afleveringen = Convert.ToInt32(readerItemSub["AFLEVERINGEN"]);
                            Items.Add(new Anime(Titel, Jaar, Score, Soort, Item_ID, Type, Afleveringen, Afbeelding));
                        }
                        else
                        {
                            int Serie = 0;
                            int Manga = 0;
                            string Kenmerken;
                            string Tags;
                            try
                            {
                                Serie = Convert.ToInt32(readerItemSub["SERIE"]);
                            }
                            catch(InvalidCastException)
                            {
                            }
                            try
                            {
                                Manga = Convert.ToInt32(readerItemSub["MANGA"]);
                            }
                            catch(InvalidCastException)
                            {
                            }
                            Kenmerken = Convert.ToString(readerItemSub["KENMERKEN"]);
                            Tags = Convert.ToString(readerItemSub["TAGS"]);
                            Items.Add(new Personage(Titel, Jaar, Score, Soort, Item_ID, Serie, Manga, Kenmerken, Tags, Afbeelding));
                        }
                    }
                }
            }
            catch (OracleException)
            {
                connectie.Close();
            }
            finally
            {
                connectie.Close();
            }
            return Items;
        }

        public bool Insert(string sql)
        {
            try
            {
                ConnectieOpen();
                OracleDataAdapter DataAdapter = new OracleDataAdapter(sql, connectie);
                DataSet Data = new DataSet();
                DataAdapter.Fill(Data);
                return true;
            }
            catch (OracleException)
            {
                return false;
            }
            finally
            {
                connectie.Close();
            }
        }
    }
}