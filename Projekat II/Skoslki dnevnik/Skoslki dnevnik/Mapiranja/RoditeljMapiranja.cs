using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class RoditeljMapiranja : SubclassMap<RoditeljStaratelj>
    {
        public RoditeljMapiranja()
        {
            Table("RODITELJ_STARATELJ");
            KeyColumn("ID_OSOBA");
            Map(x => x.RadnoMesto, "RADNO_MESTO");
            Map(x => x.Zanimanje, "ZANIMANJE");
        }
    }
}
