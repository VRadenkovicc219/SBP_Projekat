namespace Skoslki_dnevnik.Mapiranja
{
    public class PredajeMapiranja : ClassMap<Predaje>
    {
        public PredajeMapiranja()
        {
            Table("PREDAJE");
            Id(x => x.Id).GeneratedBy.TriggerIdentity();
            References(x => x.Nastavnik, "NASTAVNIK").Not.Nullable();
            References(x => x.Predmet, "PREDMET").Not.Nullable();
            HasMany(x => x.Nastave).KeyColumn("ID_ODELJENJE").Inverse();
        }
    }
}
