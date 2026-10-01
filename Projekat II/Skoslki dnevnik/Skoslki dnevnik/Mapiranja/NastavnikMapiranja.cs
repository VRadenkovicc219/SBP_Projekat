namespace Skoslki_dnevnik.Mapiranja
{
    public class NastavnikMapiranja : SubclassMap<Nastavnik>
    {
        public NastavnikMapiranja()
        {
            Table("NASTAVNIK");
            KeyColumn("ID_OSOBA");
            Map(x => x.Status, "STATUS").Not.Nullable();
            Map(x => x.Zvanje, "ZVANJE").Not.Nullable();
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA").Not.Nullable();
            Map(x => x.DatumZaposlenja, "DATUM_ZAPOSLENJA").Not.Nullable();
            HasMany(x => x.Predaje).KeyColumn("ID_NASTAVNIK").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
