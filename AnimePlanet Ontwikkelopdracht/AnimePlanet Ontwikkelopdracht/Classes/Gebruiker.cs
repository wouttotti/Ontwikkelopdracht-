using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Gebruiker
    {
        public int Gebruiker_ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public Gebruiker(int gebruiker_ID, string naam, string email, string wachtwoord)
        {
            this.Gebruiker_ID = gebruiker_ID;
            this.Naam = naam;
            this.Email = email;
            this.Wachtwoord = wachtwoord;
        }
    }
}