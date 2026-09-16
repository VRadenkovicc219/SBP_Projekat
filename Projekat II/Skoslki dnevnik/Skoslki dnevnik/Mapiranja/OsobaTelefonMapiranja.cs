using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class OsobaTelefonMapiranja : ClassMap<OsobaTelefon>
    {
        public OsobaTelefonMapiranja()
        {
            Table("TELEFON");
            CompositeId(x => x.Id)
                .KeyReference(x => x.OsobaTelefon, "ID_OSOBA")
                .KeyProperty(x => x.BrojTelefona, "BROJ_TELEFONA");
        }
    }
}
