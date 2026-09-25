namespace Skoslki_dnevnik.Mapiranja
{
    public class UcenikMapiranja : SubclassMap<Ucenik>
    {
        public UcenikMapiranja()
        {
            Table("UCENIK");
            KeyColumn("ID_OSOBA");
            Map(x => x.Status, "STATUS");
            Map(x => x.GodinaUpisa, "GODINA_UPISA");
            HasMany(x => x.Ocene).KeyColumn("ID_UCENIK").Inverse().Cascade.All();
            HasMany(x => x.Izostanci).KeyColumn("ID_UCENIK").Inverse().Cascade.All();

            HasManyToMany(x => x.Predmeti)
                .Table("SLUSA_PREDMET")
                .ParentKeyColumn("ID_UCENIK")
                .ChildKeyColumn("ID_PREDMET");

            HasManyToMany(x => x.Odeljenja)
                .Table("UCENIK_ODELJENJE")
                .ParentKeyColumn("ID_UCENIK")
                .ChildKeyColumn("ID_ODELJENJE")
                .Inverse();

            HasManyToMany(x => x.Roditelji)
                .Table("STARATELJSTVO")
                .ParentKeyColumn("ID_UCENIK")
                .ChildKeyColumn("ID_STARATELJ");
        }
    }
}
