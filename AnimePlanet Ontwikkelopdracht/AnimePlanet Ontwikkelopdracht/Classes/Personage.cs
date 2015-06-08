using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class Personage : Item
    {
        public int AnimeID { get; set; }
        public int MangaID { get; set; }
        public string Kenmerken { get; set; }
        public string Tags { get; set; }
        public Personage(string titel, int jaar, double gemiddeldeScore, string soort, int item_ID, int animeId, int mangaId, string kenmerken, string tags, string afbeelding)
            : base(titel, jaar, gemiddeldeScore, soort, item_ID, afbeelding)
        {
            this.AnimeID = animeId;
            this.MangaID = mangaId;
            this.Kenmerken = kenmerken;
            this.Tags = tags;
        }
    }
}