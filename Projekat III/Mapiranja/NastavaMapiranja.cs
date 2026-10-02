namespace Skoslki_dnevnik.Mapiranja
{
    public class NastavaMapiranja : ClassMap<Nastava>
    {
        public NastavaMapiranja()
        {
            Table("NASTAVA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            References(x => x.Odeljenje, "ID_ODELJENJE").Not.Nullable();
            References(x => x.predajePredmet, "ID_PREDAJE").Not.Nullable();
            HasMany(x => x.Ocene).KeyColumn("ID_NASTAVA").Inverse();
            HasMany(x => x.Izostanci).KeyColumn("ID_NASTAVA").Inverse();

        }
    }
}
