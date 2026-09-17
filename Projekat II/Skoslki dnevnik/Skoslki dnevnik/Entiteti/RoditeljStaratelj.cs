using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class RoditeljStaratelj : Osoba
    {
        public virtual required string Zanimanje { get; set; }
        public virtual string? RadnoMesto { get; set; }
        public virtual IList<Ucenik> Deca { get; set; }  = new List<Ucenik>();
    }
}
