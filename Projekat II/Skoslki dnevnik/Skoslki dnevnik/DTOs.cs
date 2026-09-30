namespace Skoslki_dnevnik
{
    public abstract record OsobaDTO(int id, string ime, string prezime, string JMBG, char Pol, string adresa);
    public record UcenikDTO(int id, string ime, string prezime, string JMBG, string adresa, string status);

    public record OcenaDTO(int vrednost, DateTime datumOcenjivanja, int polugodje);
    public record PredmetiDTO(int id, string naziv, string skolskaGodina, int razred) {
        public override string ToString() => $"{naziv} ({razred}. razred, {skolskaGodina})";
    };
    public record IzostanakDTO(string predmet, int cas, DateTime datum, string tip, string opravdao);

    public record RoditeljDTO(int id, string ime, string prezime, string jmbg, string adresa,
                           string email, string telefon, string zanimanje, string? radnoMesto);

    public record OcenaStatistikaDTO(string ucenik, string predmet, int vrednost, DateTime datum, TipOcene tip, int polugodje);
    public record IzostanakStatistikaDTO(string ucenik, string predmet, string skolskaGodina, DateTime datum, int redniBrojCasa, TipIzostanka tip);
}
