namespace Skoslki_dnevnik.Entiteti
{
    public class Predmet
    {
        public virtual required string Naziv { get; set; }
        public virtual required string SkolskaGodina { get; set; }
        public virtual int Razred { get; set; }
        public virtual int NedeljniFond { get; set; }
        public virtual TipPredmeta Tip { get; set; }
        public virtual string? Opis { get; set; }
        public virtual string? Komentar { get; set; }
    }
}
