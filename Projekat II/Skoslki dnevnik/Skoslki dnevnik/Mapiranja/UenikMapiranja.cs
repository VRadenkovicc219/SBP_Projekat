using NHibernate.Mapping.ByCode.Impl.CustomizersImpl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class UenikMapiranja : SubclassMap<Ucenik>
    {
        public UenikMapiranja()
        {
            Table("Vojnik");
            KeyColumn("ID_OSOBA");
            Map(x => x.Status, "STATUS");
            Map(x => x.GodinaUpisa, "GODINA_UPISA");
        }
    }
}
