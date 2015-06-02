using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Lijst
    {
        public int Lijst_ID { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Lijst(int lijst_ID, Gebruiker gebruiker)
        {
            this.Lijst_ID = lijst_ID;
            this.Gebruiker = gebruiker;
        }
    }
}