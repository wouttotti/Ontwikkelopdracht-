using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Lijst
    {
        public int Lijst_ID { get; set; }
        public string Soort { get; set; }
        public int Gebruiker { get; set; }
        public Lijst(int lijst_ID, string soort, int gebruiker)
        {
            this.Lijst_ID = lijst_ID;
            this.Gebruiker = gebruiker;
            this.Soort = soort;
        }
    }
}