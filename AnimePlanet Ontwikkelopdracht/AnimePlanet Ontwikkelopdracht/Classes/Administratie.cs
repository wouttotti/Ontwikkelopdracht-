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
    }
}