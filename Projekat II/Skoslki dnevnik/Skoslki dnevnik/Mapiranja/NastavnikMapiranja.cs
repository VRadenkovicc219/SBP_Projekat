namespace Skoslki_dnevnik.Mapiranja
{
    public class NastavnikMapiranja : SubclassMap<Nastavnik>
    {
        public NastavnikMapiranja()
        {
            Table("NASTAVNIK");
            KeyColumn("ID_OSOBA");
            Map(x => x.Status, "STATUS");
            Map(x => x.Zvanje, "ZVANJE");
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");
            Map(x => x.DatumZaposlenja, "DATUM_ZAPOSLENJA");
            HasManyToMany(x => x.Predmeti).Table("PREDAJE").ParentKeyColumn("ID_NASTAVNIK").ChildKeyColumn("ID_PREDMET");
        }
    }
}
