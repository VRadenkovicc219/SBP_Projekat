using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class StrucniSaradnikMapiranja : SubclassMap<StrucniSaradnik>
    {
        public StrucniSaradnikMapiranja()
        {
            Table("STRUCNI_SARADNIK");
            KeyColumn("ID_NASTAVNIK");
            Map(x => x.Licenca, "LICENCA").Not.Nullable();
            Map(x => x.StrucnaOblast, "STRUCNA_OBLAST").CustomType<StrucnaOblast>().CustomSqlType("VARCHAR2(50)").Not.Nullable();
            Map(x => x.BrojOdrzanihRadionica, "BROJ_ODRZANIH_RADIONICA").Not.Nullable();
            Map(x => x.BrojSprovedenihRazgovora, "BROJ_SPROVEDENIH_RAZGOVORA");
        }
    }
}
