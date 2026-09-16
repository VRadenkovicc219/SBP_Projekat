using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class SlusaPredmetMapiranja : ClassMap<SlusaPredmet>
    {
        public SlusaPredmetMapiranja()
        {
            Table("SLUSA_PREDMET");
            Id(x=>x.Id, "ID").GeneratedBy.Identity();
            References(x => x.Ucenik, "ID_UCENIK");
            References(x => x.Predmet, "ID_PREDMET");
        }

    }
}
