namespace Skoslki_dnevnik.Entiteti
{
    public class Izostanak
    {
        public virtual required IzostanakId Id { get; set; }
        public virtual TipIzostanka TipIzostanka { get; set; }
        public virtual Opravdao Opravdao { get; set; }
        public virtual string? RazlogIzostanka { get; set; }
        public virtual string? Komentar { get; set; }
        public virtual required Nastava Nastava { get; set; }

    }
}
