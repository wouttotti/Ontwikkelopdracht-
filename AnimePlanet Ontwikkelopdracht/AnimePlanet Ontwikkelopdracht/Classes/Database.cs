using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Web.Configuration;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Database
    {
        private OracleConnection connectie;
        private string conn = WebConfigurationManager.ConnectionStrings["Constring"].ConnectionString;

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
    }
}