using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class NastavaMapiranja : ClassMap<Nastava>
    {
        public NastavaMapiranja()
        {
            Table("NASTAVA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.Odeljenje).Not.Nullable();
            References(x => x.Nastavnik).Not.Nullable();
            References(x => x.Predmet).Not.Nullable();
            HasMany(x => x.Ocene).KeyColumn("ID_NASTAVA").Inverse();
            HasMany(x => x.Izostanci).KeyColumn("ID_NASTAVA").Inverse();

        }
    }
}
