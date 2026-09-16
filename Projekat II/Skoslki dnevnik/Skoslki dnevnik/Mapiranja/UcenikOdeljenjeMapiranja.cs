using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class UcenikOdeljenjeMapiranja : ClassMap<UcenikOdeljenje>
    {
        public UcenikOdeljenjeMapiranja()
        {
            Table("UCENIK_ODELJENJE");
            Id(x => x.Id, "ID").GeneratedBy.Identity();
            References(x => x.Ucenik, "ID_UCENIK").Not.Nullable();
            References(x => x.Odeljenje, "ID_ODELJENJE").Not.Nullable();
        }
    }
}
