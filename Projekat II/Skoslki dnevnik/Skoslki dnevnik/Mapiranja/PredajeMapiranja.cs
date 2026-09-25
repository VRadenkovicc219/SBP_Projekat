namespace Skoslki_dnevnik.Mapiranja
{
    public class PredajeMapiranja : ClassMap<Predaje>
    {
        public PredajeMapiranja()
        {
            Table("PREDAJE");
            Id(x => x.Id).GeneratedBy.TriggerIdentity();
            References(x => x.Nastavnik, "ID_NASTAVNIK").Not.Nullable();
            References(x => x.Predmet, "ID_PREDMET").Not.Nullable();
            HasMany(x => x.Nastave).KeyColumn("ID_ODELJENJE").Inverse();
        }
    }
}
