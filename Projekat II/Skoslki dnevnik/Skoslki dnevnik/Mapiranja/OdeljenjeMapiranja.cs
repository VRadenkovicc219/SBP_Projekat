namespace Skoslki_dnevnik.Mapiranja
{
    public class OdeljenjeMapiranja : ClassMap<Odeljenje>
    {
        public OdeljenjeMapiranja()
        {
            Table("ODELJENJE");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Razred, "RAZRED").Not.Nullable();
            Map(x => x.SkolskaGodina, "SKOLSKA_GODINA").Not.Nullable();
            Map(x => x.Oznaka, "OZNAKA").Not.Nullable();
            HasMany(x => x.Nastava).KeyColumn("ID_ODELJENJE").Inverse();
            HasManyToMany(x => x.Ucenici)
                .Table("UCENIK_ODELJENJE")
                .ParentKeyColumn("ID_ODELJENJE")
                .ChildKeyColumn("ID_UCENIK");
        }
    }
}
