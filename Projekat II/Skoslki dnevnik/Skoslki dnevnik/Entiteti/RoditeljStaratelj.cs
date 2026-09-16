using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Entiteti
{
    public class RoditeljStaratelj
    {
        public virtual required string Zanimanje { get; set; }
        public virtual string? RadnoMesto { get; set; }
    }
}
