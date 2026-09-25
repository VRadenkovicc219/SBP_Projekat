namespace Skoslki_dnevnik.Entiteti
{
    public class Predaje
    {
        public virtual int Id { get; protected set; }
        public virtual required Predmet Predmet { get; set; }
        public virtual required Nastavnik Nastavnik { get; set; }
        public virtual IList<Nastava> Nastave { get; set; } = new List<Nastava>();
    }
}
