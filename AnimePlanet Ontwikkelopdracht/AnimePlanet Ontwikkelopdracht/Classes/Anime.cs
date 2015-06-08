using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Anime : Item
    {
        public string Type { get; set; }
        public int Afleveringen { get; set; }
        public Anime(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID, string type, int afleveringen, string afbeelding)
            : base(titel, jaar, gemiddeldeScore, soort, item_ID, afbeelding)
        {
            this.Type = type;
            this.Afleveringen = afleveringen;
        }
    }
}