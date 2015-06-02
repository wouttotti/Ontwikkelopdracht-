using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Badge
    {
        public int Badge_ID { get; set; }
        public string Naam { get; set; }
        public string Informatie { get; set; }
        public string Afbeelding { get; set; }
        public Badge(int badge_ID, string naam, string informatie, string afbeelding)
        {
            this.Badge_ID = badge_ID;
            this.Naam = naam;
            this.Informatie = informatie;
            this.Afbeelding = afbeelding;
        }
    }
}