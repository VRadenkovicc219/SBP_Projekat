namespace Skoslki_dnevnik.Mapiranja
{
    public class OcenaMapiranja : ClassMap<Ocena>
    {
        public OcenaMapiranja()
        {
            Table("OCENA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Vrednost, "VREDNOST").Not.Nullable();
            Map(x => x.DatumOcenjivanja, "DATUM_OCENJIVANJA").Not.Nullable();
            Map(x => x.Tip, "TIP").CustomType<TipOcene>().CustomSqlType("VARCHAR2(20)").Not.Nullable();
            Map(x => x.Polugodje, "POLUGODJE").Not.Nullable();
            Map(x => x.Komentar, "KOMENTAR").Not.Nullable();
            References(x => x.Ucenik, "ID_UCENIK").Not.Nullable();
            References(x => x.Nastava, "ID_NASTAVA").Not.Nullable();
        }
    }
}
