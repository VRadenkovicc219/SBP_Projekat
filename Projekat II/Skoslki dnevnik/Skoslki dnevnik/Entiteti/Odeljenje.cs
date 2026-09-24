namespace Skoslki_dnevnik.Entiteti
{
    public class Odeljenje
    {
        public virtual int Id { get; protected set; }
        public virtual required string Oznaka { get; set; }
        public virtual required string SkolskaGodina { get; set; }
        public virtual required int Razred { get; set; }
        public virtual IList<Nastava> Nastava { get; set; } = new List<Nastava>();
        public virtual IList<Ucenik> Ucenici { get; set; } = new List<Ucenik>();

    }
}
