namespace Skoslki_dnevnik.Mapiranja
{
    public class RukovodeceOsobljeMapiranja : SubclassMap<RukovodeceOsoblje>
    {
        public RukovodeceOsobljeMapiranja()
        {
            Table("RUKOVODECE_OSOBLJE");
            KeyColumn("ID_NASTAVNIK");
            Map(x => x.OblastOdgovornosti, "OBLAST_ODGOVORNOSTI")
                .CustomType<OblastOdgovornosti>()
                .CustomSqlType("VARCHAR2(50)")
                .Not.Nullable();
            Map(x => x.Pozicija, "POZICIJA")
               .CustomType<RukovodecaPozicija>()
               .CustomSqlType("VARCHAR2(50)")
               .Not.Nullable();
            Map(x => x.BrojGodinaRukovodecegStaza, "GODINE_STAZA");
            Map(x => x.DatumPreuzimanjaFunkcije, "DATUM_PREUZIMANJA_FUNKCIJE");
        }
    }
}
