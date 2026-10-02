namespace Skoslki_dnevnik.Entiteti
{
    public class Osoba
    {
        public virtual int Id { get; protected set; }
        public virtual required String Ime { get; set; }
        public virtual required String Prezime { get; set; }
        public virtual required String JMBG { get; set; }
        public virtual required String Adresa { get; set; }
        public virtual char Pol { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual required String Email { get; set; }
        public virtual required String Telefon { get; set; }
        public virtual String? Komentar { get; set; }
        public Osoba() { }
    }
}
