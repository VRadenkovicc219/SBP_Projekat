namespace Skoslki_dnevnik
{
    public record OsobaDTO(int id, string ime, string prezime, string JMBG, char Pol, string adresa);
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
    public record NastavaDTO(int id, string predmet, int razred, string skolskaGodina, string profesor);
    public record PredmetDTO(int id, string naziv, string skolskaGodina, int razred, int nedeljniFond, string tip, string? opis, string? komentar);
    public record NastavnikDTO(int id, string ime, string prezime, string jmbg, string adresa, string email, string telefon, StatusNastavnika status, string zvanje, string strucna_sprema, DateTime datum_zaposlenja);
    public record OdeljenjeDTO(int id, string oznaka, string skolskaGodina, int razred);
    public record OcenaDetaljDTO(int id, int vrednost, DateTime datumOcenjivanja, int polugodje, string tip, string? komentar, int idUcenik, int idNastava);
    public record NovaOcenaDTO(int idUcenik, int idNastava, string tip, int vrednost, int polugodje, DateTime datumOcenjivanja, string? komentar);
    public record NoviIzostanakDTO(int idUcenik, DateTime datum, int redniBrojCasa, int idNastava, string tip, string? opravdao, string? razlogIzostanka, string? komentar);
    public record RazredniStaresinaDTO(int idNastavnik, string imeNastavnika, int idOdeljenje, string oznakaOdeljenja, DateTime datumPreuzimanja, int brojSastanaka, string? napomena);
    public record RukovodeceOsobljeDTO(int idNastavnik, string imeNastavnika, string pozicija, DateTime? datumPreuzimanja, string oblastOdgovornosti, int? godineStaza);
    public record StrucniSaradnikDTO(int idNastavnik, string imeNastavnika, string licenca, string strucnaOblast, int? brojRadionica, int? brojRazgovora);
    public record RazredniStaresinaUnosDTO(int idOdeljenje, DateTime datumPreuzimanja, string? napomena);
    public record RukovodecaFunkcijaUnosDTO(string pozicija, string oblastOdgovornosti, DateTime? datumPreuzimanja, int? godineStaza);
    public record StrucniSaradnikUnosDTO(string licenca, string strucnaOblast, int brojRadionica, int? brojRazgovora);
    public record OdeljenjeIzmenaDTO(string? oznaka, string? skolskaGodina, int? razred);

    public record IzmenaOceneDTO(string tip, int vrednost, int polugodje, DateTime datumOcenjivanja, string? komentar);

    public record IzmenaIzostankaDTO(string tip, string? opravdao, string? razlogIzostanka, string? komentar);

    public record DodelaPredmetaUcenikuDTO(int ucenikId,int predmetId);

    public record DodelaUcenikaOdeljenjuDTO(int ucenikId);

    public record DodelaUcenikaRoditeljuDTO(int ucenikId);

    public record DodelaPredmetaNastavnikuDTO(List<int> predmetIds);

    public record DodelaUcenikaOdeljenjuGrupnoDTO(List<int> ucenikIds);

    public record OpravdajIzostanakDTO(int UcenikId, DateTime Datum, int Cas, int RazredniId, Opravdao opravdao, string? Razlog, string? Komentar);


}
