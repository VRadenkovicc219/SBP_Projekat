using NHibernate.Mapping.ByCode.Impl.CustomizersImpl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class UcenikMapiranja : SubclassMap<Ucenik>
    {
        public UcenikMapiranja()
        {
            Table("UCENIK");
            KeyColumn("ID_OSOBA");
            Map(x => x.Status, "STATUS");
            Map(x => x.GodinaUpisa, "GODINA_UPISA");
            HasMany(x => x.Roditelji).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
            HasMany(x => x.Ocene).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
            HasMany(x => x.Izostanci).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
            HasMany(x => x.Predmeti).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
            HasMany(x => x.Odeljenja).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
        }
    }
}
