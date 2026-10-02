namespace Skoslki_dnevnik.Mapiranja
{
    public class RoditeljMapiranja : SubclassMap<RoditeljStaratelj>
    {
        public RoditeljMapiranja()
        {
            Table("RODITELJ_STARATELJ");
            KeyColumn("ID_OSOBA");
            Map(x => x.RadnoMesto, "RADNO_MESTO");
            Map(x => x.Zanimanje, "ZANIMANJE");
            HasManyToMany(x => x.Deca)
                .Table("STARATELJSTVO")
                .ParentKeyColumn("ID_STARATELJ")
                .ChildKeyColumn("ID_UCENIK")
                .Inverse();
        }
    }
}
