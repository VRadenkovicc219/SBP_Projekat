using NHibernate.Mapping;

namespace Skoslki_dnevnik.Mapiranja
{
    public class JeRoditeljMapiranja : ClassMap<JeRoditelj>
    {
        public JeRoditeljMapiranja()
        {
            Table("STARATELJSTVO");
            Id(x => x.Id, "ID").GeneratedBy.Identity();
            References(x => x.RoditeljStaratelj, "ID_STARATELJ").Not.Nullable();
            References(x => x.Ucenik, "ID_UCENIK").Not.Nullable();
        }
    }
}
