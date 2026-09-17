namespace Skoslki_dnevnik.Mapiranja
{
    public class PredmetMapiranja : ClassMap<Predmet>
    {
        public PredmetMapiranja()
        {
            Table("PREDMET");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Naziv, "NAZIV").Not.Nullable();
            Map(x => x.Razred, "RAZRED").Not.Nullable();
            Map(x => x.SkolskaGodina, "SKOLSKA_GODINA").Not.Nullable();
            Map(x => x.Tip, "TIP").CustomType< TipPredmeta>().CustomSqlType("Varchar2(20)").Not.Nullable();
            Map(x => x.NedeljniFond, "NEDELJNI_FOND").Not.Nullable();
            Map(x => x.Opis, "OPIS");
            Map(x => x.Komentar, "KOMENTAR");
            HasMany(x => x.PredajeSe).KeyColumn("ID_PREDMET").Inverse().Cascade.All();
            HasManyToMany(x => x.Polaznici)
                .Table("SLUSA_PREDMET")
                .ParentKeyColumn("ID_PREDMET")
                .ChildKeyColumn("ID_UCENIK")
                .Inverse();
        }
    }
}

