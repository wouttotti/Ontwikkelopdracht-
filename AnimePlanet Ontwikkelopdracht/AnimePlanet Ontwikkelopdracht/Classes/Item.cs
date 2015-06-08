using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public abstract class Item
    {
        public string Titel { get; set; }
        public int Jaar { get; set; }
        public double GemiddeldeScore { get; set; }
        public string Soort { get; set; }
        public int Item_ID { get; set; }
        public string Afbeelding { get; set; }

        public Item(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID, string afbeelding)
        {
            this.Titel = titel;
            this.Jaar = jaar;
            this.GemiddeldeScore = gemiddeldeScore;
            this.Soort = soort;
            this.Item_ID = item_ID;
            this.Afbeelding = afbeelding;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}