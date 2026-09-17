using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik.Mapiranja
{
    public class IzostanakMapiranja : ClassMap<Izostanak>
    {
        public IzostanakMapiranja()
        {
            Table("IZOSTANAK");
            CompositeId(x => x.Id)
                .KeyReference(x => x.Ucenik, "ID_UCENIK")
                .KeyProperty(x => x.Datum, "DATUM")
                .KeyProperty(x => x.RedniBrojCasa, "REDNI_BROJ_CASA");
            Map(x => x.TipIzostanka, "TIP").CustomType<TipIzostanka>().CustomSqlType("Varchar2(10)").Not.Nullable();
            Map(x => x.RazlogIzostanka, "RAZLOG_IZOSTANKA");
            Map(x => x.Opravdao, "OPRAVDAO").CustomType<Opravdao>().CustomSqlType("VARCHAR2(10)");
            Map(x => x.Komentar, "KOMENTAR");
            References(x => x.Nastava, "ID_NASTAVA").Not.Nullable();
        }
    }
}
