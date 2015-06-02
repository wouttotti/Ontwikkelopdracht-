using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Personage : Item
    {
        public string Naam { get; set; }
        public string Kenmerken { get; set; }
        public string Tags { get; set; }
        public Personage(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID, string naam, string kenmerken, string tags)
            : base(titel, jaar, gemiddeldeScore, soort, item_ID)
        {
            this.Naam = naam;
            this.Kenmerken = kenmerken;
            this.Tags = tags;
        }
    }
}