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

        public Item(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}