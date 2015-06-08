using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Manga : Item
    {
        public string Type { get; set; }
        public int Volumes { get; set; }
        public int Hoofdstukken { get; set; }
        public Manga(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID, string type, int volumes, int hoofdstukken, string afbeelding)
            : base(titel, jaar, gemiddeldeScore, soort, item_ID, afbeelding)
        {
            this.Type = type;
            this.Volumes = volumes;
            this.Hoofdstukken = hoofdstukken;
        }
    }
}