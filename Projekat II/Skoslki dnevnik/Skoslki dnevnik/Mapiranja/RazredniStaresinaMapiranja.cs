using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class RazredniStaresinaMapiranja : SubclassMap<RazredniStaresina>
    {
        public RazredniStaresinaMapiranja()
        {
            Table("RAZREDNI_STARESINA");
            KeyColumn("ID_NASTAVNIK");
            References(x => x.Odeljenje, "ID_ODELJENJE").Not.Nullable();
            Map(x => x.DatumPreuzimanjaStaresinstva, "DATUM_PREUZIMANJA_STARESINSTVA");
            Map(x => x.BrojOdrzanihSasatanaka, "BROJ_ODRZANIH_SASTNAKA").Not.Nullable();
            Map(x => x.Napomena, "NAPOMENA");
        }
    }
}
