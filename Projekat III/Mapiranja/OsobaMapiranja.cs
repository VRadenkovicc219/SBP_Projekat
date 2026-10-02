
namespace Skoslki_dnevnik.Mapiranja
{
    public class OsobaMapiranja : ClassMap<Osoba>
    {
        public OsobaMapiranja()
        {
            Table("OSOBA");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Ime, "IME").Not.Nullable();
            Map(x => x.Prezime, "PREZIME").Not.Nullable();
            Map(x => x.JMBG, "JMBG").Not.Nullable();
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Pol, "POL").Not.Nullable();
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA").Not.Nullable();
            Map(x => x.Email, "EMAIL").Not.Nullable();
            Map(x => x.Komentar, "KOMENTAR");
            Map(x => x.Telefon, "TELEFON").Not.Nullable();
        }
    }
}
