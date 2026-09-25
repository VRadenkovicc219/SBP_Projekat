namespace Skoslki_dnevnik
{
    public abstract record OsobaDTO(int id, string ime, string prezime, string JMBG, char Pol, string adresa);
    public record UcenikDTO(int id, string ime, string prezime, string JMBG, string adresa, string status);

    public record OcenaDTO(int vrednost, DateTime datumOcenjivanja, int polugodje);
    public record PredmetiDTO(int id, string naziv, string skolskaGodina, int razred) {
        public override string ToString() => $"{naziv} ({razred}. razred, {skolskaGodina})";
    };
}
