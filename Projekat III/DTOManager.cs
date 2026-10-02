using NHibernate;
using ISession = NHibernate.ISession;

namespace Skoslki_dnevnik
{
    public static class DTOManager
    {
        #region Pomocne metode

        private static void izvrsiUpit(Action<ISession> upit, string porukaGreske)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction t = s.BeginTransaction())
                {
                    upit(s);
                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{porukaGreske}: {ex.Message}", ex);
            }
        }

        private static T izvrsiUpit<T>(Func<ISession, T> upit, string porukaGreske)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction t = s.BeginTransaction())
                {
                    T rezultat = upit(s);
                    t.Commit();
                    return rezultat;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{porukaGreske}: {ex.Message}", ex);
            }
        }

        private static int? idOsobePoJmbg(ISession s, string jmbg)
        {
            object? r = s.CreateSQLQuery(
                    "SELECT ID FROM OSOBA WHERE JMBG = :j")
                .SetParameter("j", jmbg)
                .UniqueResult();

            return r is null ? null : Convert.ToInt32(r);
        }

        private static bool imaUlogu(ISession s, string tabela, int idOsobe)
        {
            object r = s.CreateSQLQuery(
                    $"SELECT COUNT(*) FROM {tabela} WHERE ID_OSOBA = :id")
                .SetParameter("id", idOsobe)
                .UniqueResult();

            return Convert.ToInt32(r) > 0;
        }

        private static bool imaDodatnuUlogu(ISession s, int idNastavnik)
        {
            return s.Query<RazredniStaresina>()
                       .Any(x => x.Id == idNastavnik)
                || s.Query<RukovodeceOsoblje>()
                       .Any(x => x.Id == idNastavnik)
                || s.Query<StrucniSaradnik>()
                       .Any(x => x.Id == idNastavnik);
        }

        #endregion


        #region Osoba

        public static OsobaDTO? vratiOsobuPoJmbg(string jmbg)
        {
            return izvrsiUpit(s =>
                s.Query<Osoba>()
                    .Where(x => x.JMBG == jmbg)
                    .Select(x => new OsobaDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Pol,
                        x.Adresa))
                    .FirstOrDefault(),
                "Greska prilikom pretrage osobe po JMBG-u");
        }

        #endregion


        #region Ucenik

        public static void dodajUcenika(Ucenik u)
        {
            izvrsiUpit(
                s => s.Save(u),
                "Greska prilikom dodavanja ucenika");
        }

        public static List<UcenikDTO> vratiUcenike()
        {
            return izvrsiUpit(s =>
                s.Query<Ucenik>()
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList(),
                "Greska pri preuzimanju ucenika iz baze")
                ?? new List<UcenikDTO>();
        }

        public static UcenikDTO? vratiUcenika(int id)
        {
            return izvrsiUpit(s =>
                s.Query<Ucenik>()
                    .Where(x => x.Id == id)
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .FirstOrDefault(),
                "Greska prilikom pribavljanja ucenika iz baze");
        }

        public static void izmeniUcenika(int id, Ucenik u)
        {
            izvrsiUpit(s =>
            {
                Ucenik? uc = s.Get<Ucenik>(id);

                if (uc is null)
                    throw new Exception(
                        "Ucenik sa unetim id-jem ne postoji u bazi");

                uc.Ime = u.Ime;
                uc.Prezime = u.Prezime;
                uc.JMBG = u.JMBG;
                uc.Adresa = u.Adresa;
                uc.Pol = u.Pol;
                uc.DatumRodjenja = u.DatumRodjenja;
                uc.Email = u.Email;
                uc.Komentar = u.Komentar;
                uc.Status = u.Status;
                uc.GodinaUpisa = u.GodinaUpisa;
                uc.Telefon = u.Telefon;

                s.Update(uc);

            }, "Greska prilikom izmene podataka ucenika");
        }

        public static void obrisiUcenika(int id)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(id);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                s.Delete(u);

            }, "Greska prilikom brisanja ucenika iz baze podataka");
        }

        public static void dodeliPredmetUceniku(
            int ucenikId,
            int predmetId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                Predmet? p = s.Get<Predmet>(predmetId);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                if (p is null)
                    throw new Exception("Predmet ne postoji u bazi");

                bool vecPostoji = u.Predmeti
                    .Any(x => x.Id == predmetId);

                if (!vecPostoji)
                    u.Predmeti.Add(p);

            }, "Greska prilikom dodeljivanja predmeta uceniku");
        }

        public static void izbaciUcenikaSaPredmeta(
            int ucenikId,
            int predmetId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                Predmet? p = s.Get<Predmet>(predmetId);

                if (u is null)
                    throw new Exception("Nepostojeci ucenik");

                if (p is null)
                    throw new Exception("Nepostojeci predmet");

                if (!u.Predmeti.Any(x => x.Id == predmetId))
                    throw new Exception("Ucenik ne slusa predmet");

                u.Predmeti.Remove(p);

            }, "Greska prilikom izbacivanja ucenika sa predmeta");
        }

        public static string vratiRazred(int id)
        {
            return izvrsiUpit(s =>
            {
                if (!s.Query<Ucenik>().Any(x => x.Id == id))
                    throw new Exception(
                        "Ucenik sa unetim ID-jem ne postoji u bazi podataka");

                int? rezultat = s.Query<Odeljenje>()
                    .Where(o => o.Ucenici.Any(u => u.Id == id))
                    .OrderByDescending(o => o.SkolskaGodina)
                    .Select(o => (int?)o.Razred)
                    .FirstOrDefault();

                return rezultat?.ToString()
                       ?? "Nema podataka o odeljenju";

            }, "Greska prilikom dobavljanja podataka iz baze");
        }

        public static List<PredmetiDTO> vratiPredmeteUcenika(int ucenikId)
        {
            return izvrsiUpit(s =>
            {
                if (!s.Query<Ucenik>().Any(x => x.Id == ucenikId))
                    throw new Exception(
                        "Ucenik sa unetim id-jem ne postoji u bazi podataka");

                return s.Query<Ucenik>()
                    .Where(x => x.Id == ucenikId)
                    .SelectMany(x => x.Predmeti)
                    .Select(x => new PredmetiDTO(
                        x.Id,
                        x.Naziv,
                        x.SkolskaGodina,
                        x.Razred))
                    .ToList();

            }, "Greska prilikom pribavljanja podataka iz baze");
        }

        public static List<PredmetiDTO> vratiPredmeteKojeUcenikNeSlusa(
            int ucenikId)
        {
            return izvrsiUpit(s =>
            {
                if (!s.Query<Ucenik>().Any(x => x.Id == ucenikId))
                    throw new Exception("Ucenik ne postoji u bazi");

                return s.Query<Predmet>()
                    .Where(p =>
                        !p.Polaznici.Any(u => u.Id == ucenikId))
                    .Select(p => new PredmetiDTO(
                        p.Id,
                        p.Naziv,
                        p.SkolskaGodina,
                        p.Razred))
                    .ToList();

            }, "Greska prilikom dobavljanja podataka");
        }

        public static List<UcenikDTO> vratiUcenikeKojiNisuUOdeljenju(
            int idOdeljenja)
        {
            return izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(idOdeljenja);

                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                int godina = int.Parse(
                    o.SkolskaGodina.Substring(0, 4));

                return s.Query<Ucenik>()
                    .Where(x =>
                        !x.Odeljenja.Any(od => od.Id == idOdeljenja)
                        &&
                        (
                            (
                                x.Status == StatusUcenika.AKTIVAN
                                &&
                                godina - o.Razred + 1 ==
                                int.Parse(
                                    x.GodinaUpisa.Substring(0, 4))
                            )
                            ||
                            (
                                x.Status == StatusUcenika.PONAVLJA
                                &&
                                godina - o.Razred ==
                                int.Parse(
                                    x.GodinaUpisa.Substring(0, 4))
                            )
                        ))
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList();

            }, "Greska prilikom vracanja podataka iz baze");
        }

        #endregion


        #region Odeljenje

        public static void kreirajOdeljenje(Odeljenje o)
        {
            izvrsiUpit(s =>
            {
                bool postoji = s.Query<Odeljenje>()
                    .Any(x =>
                        x.Oznaka == o.Oznaka &&
                        x.Razred == o.Razred &&
                        x.SkolskaGodina == o.SkolskaGodina);

                if (postoji)
                    throw new Exception(
                        "Odeljenje vec postoji u bazi podataka");

                s.Save(o);

            }, "Greska prilikom kreiranja novog odeljenja");
        }

        public static OdeljenjeDTO? vratiOdeljenje(int id)
        {
            return izvrsiUpit(s =>
                s.Query<Odeljenje>()
                    .Where(x => x.Id == id)
                    .Select(x => new OdeljenjeDTO(
                        x.Id,
                        x.Oznaka,
                        x.SkolskaGodina,
                        x.Razred))
                    .FirstOrDefault(),
                "Greska prilikom dobavljanja odeljenja iz baze podataka");
        }

        public static List<OdeljenjeDTO> vratiOdeljenja(
            string? oznaka = null,
            string? skolskaGodina = null,
            int razred = 0)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Odeljenje>();

                if (!string.IsNullOrWhiteSpace(oznaka))
                    upit = upit.Where(x => x.Oznaka == oznaka);

                if (razred != 0)
                    upit = upit.Where(x => x.Razred == razred);

                if (!string.IsNullOrWhiteSpace(skolskaGodina))
                    upit = upit.Where(
                        x => x.SkolskaGodina == skolskaGodina);

                return upit
                    .Select(x => new OdeljenjeDTO(
                        x.Id,
                        x.Oznaka,
                        x.SkolskaGodina,
                        x.Razred))
                    .ToList();

            }, "Greska prilikom dobavljanja odeljenja iz baze podataka")
            ?? new List<OdeljenjeDTO>();
        }

        public static void obrisiOdeljenje(int id)
        {
            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(id);

                if (o is null)
                    throw new Exception(
                        "Odeljenje sa unetim id-jem ne postoji u bazi");

                s.Delete(o);

            }, "Greska prilikom brisanja odeljenja");
        }

        public static void dodajUcenikaUOdeljenje(
            int odeljenjeId,
            int ucenikId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                Odeljenje? o = s.Get<Odeljenje>(odeljenjeId);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                if (!u.Odeljenja.Any(x => x.Id == odeljenjeId))
                    u.Odeljenja.Add(o);

                foreach (Nastava n in o.Nastava)
                {
                    Predmet p = n.predajePredmet.Predmet;

                    if (!u.Predmeti.Any(x => x.Id == p.Id))
                        u.Predmeti.Add(p);
                }

            }, "Greska prilikom dodavanja ucenika u odeljenje");
        }

        public static void dodajUcenikeUOdeljenje(
            int odeljenjeId,
            List<int> ucenikIds)
        {
            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(odeljenjeId);

                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                foreach (int id in ucenikIds)
                {
                    Ucenik? u = s.Get<Ucenik>(id);

                    if (u is null)
                        continue;

                    if (!u.Odeljenja.Any(x => x.Id == odeljenjeId))
                        u.Odeljenja.Add(o);

                    foreach (Nastava n in o.Nastava)
                    {
                        Predmet p = n.predajePredmet.Predmet;

                        if (!u.Predmeti.Any(x => x.Id == p.Id))
                            u.Predmeti.Add(p);
                    }
                }

            }, "Greska prilikom upisivanja ucenika u odeljenje");
        }

        public static void izmeniOdeljenje(
            int id,
            string? oznaka = null,
            string? skolskaGodina = null,
            int razred = 0)
        {
            if (oznaka is null &&
                skolskaGodina is null &&
                razred == 0)
                return;

            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(id);

                if (o is null)
                    throw new Exception(
                        "Odeljenje ne postoji u bazi podataka");

                string novaOznaka = oznaka ?? o.Oznaka;
                string novaGodina = skolskaGodina ?? o.SkolskaGodina;
                int noviRazred = razred == 0 ? o.Razred : razred;

                bool postoji = s.Query<Odeljenje>()
                    .Any(x =>
                        x.Id != id &&
                        x.Oznaka == novaOznaka &&
                        x.SkolskaGodina == novaGodina &&
                        x.Razred == noviRazred);

                if (postoji)
                    throw new Exception(
                        "Vec postoji odeljenje sa istim razredom, oznakom i skolskom godinom");

                o.Oznaka = novaOznaka;
                o.SkolskaGodina = novaGodina;
                o.Razred = noviRazred;

            }, "Greska prilikom azuriranja odeljenja");
        }

        public static List<NastavaDTO> vratiNastavuZaDodavanjeOdeljenju(
            int odeljenjeId)
        {
            return izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(odeljenjeId);

                if (o is null)
                    throw new Exception(
                        "Odeljenje sa unetim id-jem ne postoji u bazi");

                return s.Query<Predaje>()
                    .Where(p =>
                        p.Predmet.SkolskaGodina == o.SkolskaGodina &&
                        p.Predmet.Razred == o.Razred &&
                        !p.Nastave.Any(n =>
                            n.Odeljenje.Id == odeljenjeId))
                    .Select(p => new NastavaDTO(
                        p.Id,
                        p.Predmet.Naziv,
                        p.Predmet.Razred,
                        p.Predmet.SkolskaGodina,
                        p.Nastavnik.Ime))
                    .ToList();

            }, "Greska prilikom pribavljanja podataka iz baze")
            ?? new List<NastavaDTO>();
        }

        public static void dodeliNastavuOdeljenju(
            int odeljenjeId,
            List<NastavaDTO> nastave)
        {
            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(odeljenjeId);

                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                foreach (NastavaDTO dto in nastave)
                {
                    Predaje? p = s.Get<Predaje>(dto.id);

                    if (p is null)
                        throw new Exception(
                            "Predaje zapis sa unetim id-jem ne postoji u bazi");

                    bool postoji = s.Query<Nastava>()
                        .Any(x =>
                            x.Odeljenje.Id == odeljenjeId &&
                            x.predajePredmet.Id == p.Id);

                    if (postoji)
                        continue;

                    Nastava n = new Nastava
                    {
                        Odeljenje = o,
                        predajePredmet = p
                    };

                    s.Save(n);

                    foreach (Ucenik u in o.Ucenici)
                    {
                        if (!u.Predmeti.Any(
                            x => x.Id == p.Predmet.Id))
                        {
                            u.Predmeti.Add(p.Predmet);
                        }
                    }
                }

            }, "Greska prilikom povezivanja predmeta i nastave");
        }

        public static List<OdeljenjeDTO> vratiOdeljenjaBezRazrednog()
        {
            return izvrsiUpit(s =>
            {
                var ids = s.Query<RazredniStaresina>()
                    .Select(x => x.Odeljenje.Id);

                return s.Query<Odeljenje>()
                    .Where(x => !ids.Contains(x.Id))
                    .Select(x => new OdeljenjeDTO(
                        x.Id,
                        x.Oznaka,
                        x.SkolskaGodina,
                        x.Razred))
                    .ToList();

            }, "Greska prilikom pribavljanja odeljenja bez razrednog staresine")
            ?? new List<OdeljenjeDTO>();
        }

        #endregion


        #region Nastavnik

        public static List<NastavnikDTO> vratiNastavnike()
        {
            return izvrsiUpit(s =>
                s.Query<Nastavnik>()
                    .Select(x => new NastavnikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Email,
                        x.Telefon,
                        x.Status,
                        x.Zvanje,
                        x.StrucnaSprema,
                        x.DatumZaposlenja))
                    .ToList(),
                "Greska pri preuzimanju nastavnika iz baze")
                ?? new List<NastavnikDTO>();
        }

        public static NastavnikDTO? vratiNastavnika(int id)
        {
            return izvrsiUpit(s =>
                s.Query<Nastavnik>()
                    .Where(x => x.Id == id)
                    .Select(x => new NastavnikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Email,
                        x.Telefon,
                        x.Status,
                        x.Zvanje,
                        x.StrucnaSprema,
                        x.DatumZaposlenja))
                    .FirstOrDefault(),
                "Greska prilikom dobavljanja nastavnika");
        }

        public static void dodajNastavnika(Nastavnik nastavnik)
        {
            izvrsiUpit(s =>
            {
                int? idOsobe = idOsobePoJmbg(
                    s,
                    nastavnik.JMBG);

                if (idOsobe is null)
                {
                    s.Save(nastavnik);
                    return;
                }

                if (imaUlogu(s, "UCENIK", idOsobe.Value))
                    throw new Exception(
                        "Osoba sa ovim JMBG-om je ucenik i ne moze biti nastavnik");

                if (imaUlogu(s, "NASTAVNIK", idOsobe.Value))
                    throw new Exception(
                        "Nastavnik sa ovim JMBG-om vec postoji");

                s.CreateSQLQuery(
                    "INSERT INTO NASTAVNIK " +
                    "(ID_OSOBA, STRUCNA_SPREMA, STATUS, ZVANJE, DATUM_ZAPOSLENJA) " +
                    "VALUES (:id, :sprema, :status, :zvanje, :datum)")
                    .SetParameter("id", idOsobe.Value)
                    .SetParameter("sprema", nastavnik.StrucnaSprema)
                    .SetParameter("status", nastavnik.Status.ToString())
                    .SetParameter("zvanje", nastavnik.Zvanje)
                    .SetParameter("datum", nastavnik.DatumZaposlenja)
                    .ExecuteUpdate();

            }, "Greska pri dodavanju novog nastavnika");
        }

        public static void izmeniNastavnika(
            int id,
            Nastavnik nastavnik)
        {
            izvrsiUpit(s =>
            {
                if (s.Query<Osoba>().Any(
                    x => x.Email == nastavnik.Email && x.Id != id))
                    throw new Exception(
                        "Osoba sa ovim emailom vec postoji u bazi podataka");

                if (s.Query<Osoba>().Any(
                    x => x.JMBG == nastavnik.JMBG && x.Id != id))
                    throw new Exception(
                        "Osoba sa ovim JMBG-om vec postoji u bazi podataka");

                Nastavnik? n = s.Get<Nastavnik>(id);

                if (n is null)
                    throw new Exception(
                        "Nastavnik ne postoji u bazi podataka");

                n.Ime = nastavnik.Ime;
                n.Prezime = nastavnik.Prezime;
                n.JMBG = nastavnik.JMBG;
                n.Adresa = nastavnik.Adresa;
                n.Pol = nastavnik.Pol;
                n.DatumRodjenja = nastavnik.DatumRodjenja;
                n.Telefon = nastavnik.Telefon;
                n.Email = nastavnik.Email;
                n.Komentar = nastavnik.Komentar;
                n.Status = nastavnik.Status;
                n.Zvanje = nastavnik.Zvanje;
                n.StrucnaSprema = nastavnik.StrucnaSprema;
                n.DatumZaposlenja = nastavnik.DatumZaposlenja;

            }, "Greska prilikom izmene podataka o nastavniku");
        }

        public static void obrisiNastavnika(int id)
        {
            izvrsiUpit(s =>
            {
                Nastavnik? n = s.Get<Nastavnik>(id);

                if (n is null)
                    throw new Exception(
                        "Nastavnik ne postoji u bazi");

                s.CreateSQLQuery(
                    "DELETE FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", id)
                    .ExecuteUpdate();

                s.CreateSQLQuery(
                    "DELETE FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", id)
                    .ExecuteUpdate();

                s.CreateSQLQuery(
                    "DELETE FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", id)
                    .ExecuteUpdate();

                foreach (Predaje p in n.Predaje.ToList())
                {
                    List<Nastava> nastave = s.Query<Nastava>()
                        .Where(x => x.predajePredmet.Id == p.Id)
                        .ToList();

                    foreach (Nastava nn in nastave)
                    {
                        s.CreateSQLQuery(
                            "DELETE FROM OCENA WHERE ID_NASTAVA = :id")
                            .SetParameter("id", nn.Id)
                            .ExecuteUpdate();

                        s.CreateSQLQuery(
                            "DELETE FROM IZOSTANAK WHERE ID_NASTAVA = :id")
                            .SetParameter("id", nn.Id)
                            .ExecuteUpdate();

                        s.Delete(nn);
                    }

                    s.Delete(p);
                }

                s.Flush();
                s.Evict(n);

                if (!imaUlogu(s, "RODITELJ_STARATELJ", id))
                {
                    s.CreateSQLQuery(
                        "DELETE FROM NASTAVNIK WHERE ID_OSOBA = :id")
                        .SetParameter("id", id)
                        .ExecuteUpdate();

                    s.CreateSQLQuery(
                        "DELETE FROM OSOBA WHERE ID = :id")
                        .SetParameter("id", id)
                        .ExecuteUpdate();
                }
                else
                {
                    s.CreateSQLQuery(
                        "DELETE FROM NASTAVNIK WHERE ID_OSOBA = :id")
                        .SetParameter("id", id)
                        .ExecuteUpdate();
                }

            }, "Greska pri brisanju nastavnika iz baze");
        }

        public static List<PredmetiDTO> vratiPredmeteNastavnika(
            int id,
            string? skolskaGodina = null)
        {
            return izvrsiUpit(s =>
                s.Query<Predaje>()
                    .Where(x =>
                        x.Nastavnik.Id == id &&
                        (
                            skolskaGodina == null ||
                            x.Predmet.SkolskaGodina == skolskaGodina
                        ))
                    .Select(x => new PredmetiDTO(
                        x.Predmet.Id,
                        x.Predmet.Naziv,
                        x.Predmet.SkolskaGodina,
                        x.Predmet.Razred))
                    .Distinct()
                    .ToList(),
                "Greska prilikom dobavljanja podataka iz baze podataka");
        }

        public static List<UcenikDTO> vratiUcenikeZaPredmet(
            int odeljenjeId,
            int predmetId,
            int nastavnikId)
        {
            return izvrsiUpit(s =>
                s.Query<Nastava>()
                    .Where(x =>
                        x.Odeljenje.Id == odeljenjeId &&
                        x.predajePredmet.Predmet.Id == predmetId &&
                        x.predajePredmet.Nastavnik.Id == nastavnikId)
                    .SelectMany(x => x.Odeljenje.Ucenici)
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList(),
                "Greska pri pribavljanju podataka iz baze")
                ?? new List<UcenikDTO>();
        }

        public static List<PredmetiDTO> vratiPredmeteZaOdabir(
            int nastavnikId)
        {
            return izvrsiUpit(s =>
                s.Query<Predmet>()
                    .Where(x =>
                        !x.Predaje.Any(
                            p => p.Nastavnik.Id == nastavnikId))
                    .OrderByDescending(x => x.SkolskaGodina)
                    .ThenBy(x => x.Razred)
                    .Select(x => new PredmetiDTO(
                        x.Id,
                        x.Naziv,
                        x.SkolskaGodina,
                        x.Razred))
                    .ToList(),
                "Greska prilikom pribavljanja podataka iz baze");
        }

        public static void dodeliPredmeteNastavniku(
            int nastavnikId,
            List<int> predmetIds)
        {
            izvrsiUpit(s =>
            {
                Nastavnik? n = s.Get<Nastavnik>(nastavnikId);

                if (n is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                foreach (int predmetId in predmetIds)
                {
                    Predmet? p = s.Get<Predmet>(predmetId);

                    if (p is null)
                        throw new Exception(
                            $"Predmet {predmetId} ne postoji u bazi");

                    bool postoji = s.Query<Predaje>()
                        .Any(x =>
                            x.Nastavnik.Id == nastavnikId &&
                            x.Predmet.Id == predmetId);

                    if (!postoji)
                    {
                        s.Save(new Predaje
                        {
                            Nastavnik = n,
                            Predmet = p
                        });
                    }
                }

            }, "Greska prilikom azuriranja podataka u bazi");
        }

        #endregion


        #region Dodatne uloge nastavnika

        public static RazredniStaresinaDTO? vratiRazrednogStaresinu(
            int odeljenjeId)
        {
            return izvrsiUpit(s =>
                s.Query<RazredniStaresina>()
                    .Where(x => x.Odeljenje.Id == odeljenjeId)
                    .Select(x => new RazredniStaresinaDTO(
                        x.Id,
                        x.Ime + " " + x.Prezime,
                        x.Odeljenje.Id,
                        x.Odeljenje.Oznaka,
                        x.DatumPreuzimanjaStaresinstva,
                        x.BrojOdrzanihSasatanaka,
                        x.Napomena))
                    .FirstOrDefault(),
                "Greska prilikom pribavljanja razrednog staresine za odeljenje");
        }

        public static List<RazredniStaresinaDTO>
            vratiSveRazredneStaresine()
        {
            return izvrsiUpit(s =>
                s.Query<RazredniStaresina>()
                    .Select(x => new RazredniStaresinaDTO(
                        x.Id,
                        x.Ime + " " + x.Prezime,
                        x.Odeljenje.Id,
                        x.Odeljenje.Oznaka,
                        x.DatumPreuzimanjaStaresinstva,
                        x.BrojOdrzanihSasatanaka,
                        x.Napomena))
                    .ToList(),
                "Greska prilikom pribavljanja razrednih staresina")
                ?? new List<RazredniStaresinaDTO>();
        }

        public static List<RukovodeceOsobljeDTO>
            vratiRukovodeceOsoblje()
        {
            return izvrsiUpit(s =>
                s.Query<RukovodeceOsoblje>()
                    .Select(x => new RukovodeceOsobljeDTO(
                        x.Id,
                        x.Ime + " " + x.Prezime,
                        x.Pozicija.ToString(),
                        x.DatumPreuzimanjaFunkcije,
                        x.OblastOdgovornosti.ToString(),
                        x.BrojGodinaRukovodecegStaza))
                    .ToList(),
                "Greska prilikom pribavljanja rukovodeceg osoblja")
                ?? new List<RukovodeceOsobljeDTO>();
        }

        public static List<StrucniSaradnikDTO>
            vratiStrucneSaradnike()
        {
            return izvrsiUpit(s =>
                s.Query<StrucniSaradnik>()
                    .Select(x => new StrucniSaradnikDTO(
                        x.Id,
                        x.Ime + " " + x.Prezime,
                        x.Licenca,
                        x.StrucnaOblast.ToString(),
                        x.BrojOdrzanihRadionica,
                        x.BrojSprovedenihRazgovora))
                    .ToList(),
                "Greska prilikom pribavljanja strucnih saradnika")
                ?? new List<StrucniSaradnikDTO>();
        }

        public static void dodeliRazrednogStaresinu(
            int nastavnikId,
            RazredniStaresinaUnosDTO dto)
        {
            izvrsiUpit(s =>
            {
                if (imaDodatnuUlogu(s, nastavnikId))
                    throw new Exception(
                        "Nastavnik vec ima dodatnu ulogu");

                if (s.Query<RazredniStaresina>()
                    .Any(x => x.Odeljenje.Id == dto.idOdeljenje))
                    throw new Exception(
                        "Ovo odeljenje vec ima razrednog staresinu");

                if (s.Get<Nastavnik>(nastavnikId) is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                if (s.Get<Odeljenje>(dto.idOdeljenje) is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                s.CreateSQLQuery(
                    "INSERT INTO RAZREDNI_STARESINA " +
                    "(ID_NASTAVNIK, ID_ODELJENJE, DATUM_PREUZIMANJA_STARESINSTVA, BROJ_ODRZANIH_SASTANAKA, NAPOMENA) " +
                    "VALUES (:idN, :idO, :datum, 0, :napomena)")
                    .SetParameter("idN", nastavnikId)
                    .SetParameter("idO", dto.idOdeljenje)
                    .SetParameter("datum", dto.datumPreuzimanja)
                    .SetParameter("napomena", dto.napomena)
                    .ExecuteUpdate();

            }, "Greska prilikom dodele razrednog staresinstva");
        }

        public static void dodeliRukovodecuFunkciju(
            int nastavnikId,
            RukovodecaFunkcijaUnosDTO dto)
        {
            izvrsiUpit(s =>
            {
                if (imaDodatnuUlogu(s, nastavnikId))
                    throw new Exception(
                        "Nastavnik vec ima dodatnu ulogu");

                if (s.Get<Nastavnik>(nastavnikId) is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                s.CreateSQLQuery(
                    "INSERT INTO RUKOVODECE_OSOBLJE " +
                    "(ID_NASTAVNIK, POZICIJA, DATUM_PREUZIMANJA_FUNKCIJE, OBLAST_ODGOVORNOSTI, GODINE_STAZA) " +
                    "VALUES (:id, :pozicija, :datum, :oblast, :staz)")
                    .SetParameter("id", nastavnikId)
                    .SetParameter("pozicija", dto.pozicija)
                    .SetParameter("datum", dto.datumPreuzimanja)
                    .SetParameter("oblast", dto.oblastOdgovornosti)
                    .SetParameter("staz", dto.godineStaza)
                    .ExecuteUpdate();

            }, "Greska prilikom dodele rukovodece funkcije");
        }

        public static void dodeliStrucnogSaradnika(
            int nastavnikId,
            StrucniSaradnikUnosDTO dto)
        {
            izvrsiUpit(s =>
            {
                if (imaDodatnuUlogu(s, nastavnikId))
                    throw new Exception(
                        "Nastavnik vec ima dodatnu ulogu");

                if (s.Get<Nastavnik>(nastavnikId) is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                s.CreateSQLQuery(
                    "INSERT INTO STRUCNI_SARADNIK " +
                    "(ID_NASTAVNIK, LICENCA, STRUCNA_OBLAST, BROJ_ODRZANIH_RADIONICA, BROJ_SPROVEDENIH_RAZGOVORA) " +
                    "VALUES (:id, :licenca, :oblast, :radionice, :razgovori)")
                    .SetParameter("id", nastavnikId)
                    .SetParameter("licenca", dto.licenca)
                    .SetParameter("oblast", dto.strucnaOblast)
                    .SetParameter("radionice", dto.brojRadionica)
                    .SetParameter("razgovori", dto.brojRazgovora)
                    .ExecuteUpdate();

            }, "Greska prilikom dodele uloge strucnog saradnika");
        }

        public static void ukiniDodatnuUlogu(int nastavnikId)
        {
            izvrsiUpit(s =>
            {
                s.CreateSQLQuery(
                    "DELETE FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", nastavnikId)
                    .ExecuteUpdate();

                s.CreateSQLQuery(
                    "DELETE FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", nastavnikId)
                    .ExecuteUpdate();

                s.CreateSQLQuery(
                    "DELETE FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", nastavnikId)
                    .ExecuteUpdate();

            }, "Greska prilikom ukidanja dodatne uloge");
        }

        #endregion


        #region Predmet

        public static List<PredmetDTO> vratiPredmete(
            string? skolskaGodina = null)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Predmet>();

                if (!string.IsNullOrWhiteSpace(skolskaGodina))
                    upit = upit.Where(
                        x => x.SkolskaGodina == skolskaGodina);

                return upit
                    .Select(x => new PredmetDTO(
                        x.Id,
                        x.Naziv,
                        x.SkolskaGodina,
                        x.Razred,
                        x.NedeljniFond,
                        x.Tip.ToString(),
                        x.Opis,
                        x.Komentar))
                    .ToList();

            }, "Greska prilikom pribavljanja podataka iz baze")
            ?? new List<PredmetDTO>();
        }

        public static PredmetDTO? vratiPredmet(int id)
        {
            return izvrsiUpit(s =>
                s.Query<Predmet>()
                    .Where(x => x.Id == id)
                    .Select(x => new PredmetDTO(
                        x.Id,
                        x.Naziv,
                        x.SkolskaGodina,
                        x.Razred,
                        x.NedeljniFond,
                        x.Tip.ToString(),
                        x.Opis,
                        x.Komentar))
                    .FirstOrDefault(),
                "Greska prilikom pribavljanja predmeta iz baze");
        }

        public static void dodajPredmet(Predmet p)
        {
            izvrsiUpit(
                s => s.Save(p),
                "Greska prilikom dodavanja predmeta u bazu podataka");
        }

        public static void obrisiPredmet(int id)
        {
            izvrsiUpit(s =>
            {
                Predmet? p = s.Get<Predmet>(id);

                if (p is null)
                    throw new Exception("Predmet ne postoji u bazi");

                s.Delete(p);

            }, "Greska prilikom brisanja predmeta iz baze podataka");
        }

        public static void izmeniPredmet(
            int id,
            Predmet predmet)
        {
            izvrsiUpit(s =>
            {
                Predmet? p = s.Get<Predmet>(id);

                if (p is null)
                    throw new Exception(
                        "Predmet sa unetim id-jem ne postoji u bazi");

                p.Naziv = predmet.Naziv;
                p.SkolskaGodina = predmet.SkolskaGodina;
                p.Opis = predmet.Opis;
                p.Komentar = predmet.Komentar;
                p.NedeljniFond = predmet.NedeljniFond;
                p.Razred = predmet.Razred;
                p.Tip = predmet.Tip;

            }, "Greska prilikom izmene predmeta iz baze podataka");
        }

        public static List<UcenikDTO> vratiUcenikeKojiSlusajuPredmet(
            int predmetId)
        {
            return izvrsiUpit(s =>
                s.Query<Ucenik>()
                    .Where(x =>
                        x.Predmeti.Any(p => p.Id == predmetId))
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList(),
                "Greska prilikom pribavljanja ucenika");
        }

        #endregion


        #region Ocena

        public static List<OcenaDetaljDTO>
            vratiOceneUcenikaNaPredmetu(
                int ucenikId,
                int predmetId)
        {
            return izvrsiUpit(s =>
                s.Query<Ocena>()
                    .Where(x =>
                        x.Ucenik.Id == ucenikId &&
                        x.Nastava.predajePredmet.Predmet.Id == predmetId)
                    .Select(x => new OcenaDetaljDTO(
                        x.Id,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Polugodje,
                        x.Tip.ToString(),
                        x.Komentar,
                        x.Ucenik.Id,
                        x.Nastava.Id))
                    .ToList(),
                "Greska prilikom pribavljanja ocena")
                ?? new List<OcenaDetaljDTO>();
        }

        public static List<OcenaDetaljDTO> vratiOcenePoTipu(
            TipOcene tip)
        {
            return izvrsiUpit(s =>
                s.Query<Ocena>()
                    .Where(x => x.Tip == tip)
                    .Select(x => new OcenaDetaljDTO(
                        x.Id,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Polugodje,
                        x.Tip.ToString(),
                        x.Komentar,
                        x.Ucenik.Id,
                        x.Nastava.Id))
                    .ToList(),
                "Greska prilikom dobavljanja ocena iz baze")
                ?? new List<OcenaDetaljDTO>();
        }

        public static List<OcenaDTO> pregledajOceneUcenikaZaPredmet(
            int ucenikId,
            int predmetId)
        {
            return izvrsiUpit(s =>
                s.Query<Ocena>()
                    .Where(x =>
                        x.Ucenik.Id == ucenikId &&
                        x.Nastava.predajePredmet.Predmet.Id == predmetId)
                    .Select(x => new OcenaDTO(
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Polugodje))
                    .OrderByDescending(x => x.datumOcenjivanja)
                    .ToList(),
                "Greska prilikom pribavljanja podataka iz baze");
        }

        public static void dodeliOcenu(NovaOcenaDTO dto)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(dto.idUcenik);
                Nastava? n = s.Get<Nastava>(dto.idNastava);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                if (n is null)
                    throw new Exception("Nastava ne postoji u bazi");

                s.Save(new Ocena
                {
                    Ucenik = u,
                    Nastava = n,
                    Tip = Enum.Parse<TipOcene>(dto.tip),
                    Vrednost = dto.vrednost,
                    Polugodje = dto.polugodje,
                    DatumOcenjivanja = dto.datumOcenjivanja,
                    Komentar = dto.komentar
                });

            }, "Greska prilikom dodele ocene");
        }

        public static void izmeniOcenu(
            int id,
            IzmenaOceneDTO dto)
        {
            izvrsiUpit(s =>
            {
                Ocena? o = s.Get<Ocena>(id);

                if (o is null)
                    throw new Exception("Ocena ne postoji u bazi");

                o.Tip = Enum.Parse<TipOcene>(dto.tip);
                o.Vrednost = dto.vrednost;
                o.Polugodje = dto.polugodje;
                o.DatumOcenjivanja = dto.datumOcenjivanja;
                o.Komentar = dto.komentar;

            }, "Greska prilikom izmene ocene");
        }

        public static void obrisiOcenu(int id)
        {
            izvrsiUpit(s =>
            {
                Ocena? o = s.Get<Ocena>(id);

                if (o is null)
                    throw new Exception("Ocena ne postoji u bazi");

                s.Delete(o);

            }, "Greska prilikom brisanja ocene");
        }

        #endregion


        #region Izostanak

        public static void dodajIzostanak(NoviIzostanakDTO dto)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(dto.idUcenik);
                Nastava? n = s.Get<Nastava>(dto.idNastava);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                if (n is null)
                    throw new Exception("Nastava ne postoji u bazi");

                s.Save(new Izostanak
                {
                    Id = new IzostanakId
                    {
                        Ucenik = u,
                        Datum = dto.datum,
                        RedniBrojCasa = dto.redniBrojCasa
                    },
                    TipIzostanka =
                        Enum.Parse<TipIzostanka>(dto.tip),
                    Opravdao =
                        string.IsNullOrWhiteSpace(dto.opravdao)
                            ? null
                            : Enum.Parse<Opravdao>(dto.opravdao),
                    RazlogIzostanka = dto.razlogIzostanka,
                    Komentar = dto.komentar,
                    Nastava = n
                });

            }, "Greska prilikom dodavanja izostanka");
        }

        public static List<IzostanakDTO>
            vratiIzostankeUcenikaNaPredmetu(
                int ucenikId,
                int predmetId)
        {
            return izvrsiUpit(s =>
                s.Query<Izostanak>()
                    .Where(x =>
                        x.Id.Ucenik.Id == ucenikId &&
                        x.Nastava.predajePredmet.Predmet.Id == predmetId)
                    .Select(x => new IzostanakDTO(
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Id.RedniBrojCasa,
                        x.Id.Datum,
                        x.TipIzostanka.ToString(),
                        x.Opravdao == null
                            ? ""
                            : x.Opravdao.ToString()))
                    .ToList(),
                "Greska prilikom pribavljanja izostanaka iz baze")
                ?? new List<IzostanakDTO>();
        }

        public static List<IzostanakDTO> vratiSveIzostankeUcenika(
            int ucenikId)
        {
            return izvrsiUpit(s =>
                s.Query<Izostanak>()
                    .Where(x => x.Id.Ucenik.Id == ucenikId)
                    .OrderByDescending(x => x.Id.Datum)
                    .ThenByDescending(x => x.Id.RedniBrojCasa)
                    .Select(x => new IzostanakDTO(
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Id.RedniBrojCasa,
                        x.Id.Datum,
                        x.TipIzostanka.ToString(),
                        x.Opravdao == null
                            ? ""
                            : x.Opravdao.ToString()))
                    .ToList(),
                "Greska prilikom dobavljanja izostanaka")
                ?? new List<IzostanakDTO>();
        }

        public static void izmeniIzostanak(
            IzostanakId id,
            IzmenaIzostankaDTO dto)
        {
            izvrsiUpit(s =>
            {
                Izostanak? i = s.Get<Izostanak>(id);

                if (i is null)
                    throw new Exception(
                        "Izostanak sa unetim podacima ne postoji u bazi");

                i.TipIzostanka =
                    Enum.Parse<TipIzostanka>(dto.tip);

                i.Opravdao =
                    string.IsNullOrWhiteSpace(dto.opravdao)
                        ? null
                        : Enum.Parse<Opravdao>(dto.opravdao);

                i.RazlogIzostanka = dto.razlogIzostanka;
                i.Komentar = dto.komentar;

            }, "Greska prilikom izmene izostanka");
        }

        public static void obrisiIzostanak(IzostanakId id)
        {
            izvrsiUpit(s =>
            {
                Izostanak? i = s.Get<Izostanak>(id);

                if (i is null)
                    throw new Exception("Izostanak ne postoji u bazi");

                s.Delete(i);

            }, "Greska prilikom brisanja izostanka");
        }

        #endregion


        #region Roditelj

        public static void dodajRoditelja(RoditeljStaratelj r)
        {
            izvrsiUpit(s =>
            {
                if (r is null)
                    throw new Exception("Roditelj nije prosledjen");

                Osoba? postojeca = s.Query<Osoba>()
                    .FirstOrDefault(x => x.JMBG == r.JMBG);

                if (postojeca is null)
                {
                    s.Save(r);
                }
                else if (postojeca is Ucenik)
                {
                    throw new Exception(
                        "Osoba sa ovim JMBG-om je ucenik i ne moze biti roditelj");
                }
                else if (postojeca is RoditeljStaratelj)
                {
                    throw new Exception(
                        "Roditelj sa ovim JMBG-om vec postoji");
                }
                else if (postojeca is Nastavnik)
                {
                    s.CreateSQLQuery(
                        "INSERT INTO RODITELJ_STARATELJ " +
                        "(ID_OSOBA, ZANIMANJE, RADNO_MESTO) " +
                        "VALUES (:id, :zanimanje, :radnoMesto)")
                        .SetParameter("id", postojeca.Id)
                        .SetParameter("zanimanje", r.Zanimanje)
                        .SetParameter("radnoMesto", r.RadnoMesto)
                        .ExecuteUpdate();
                }

            }, "Greska prilikom dodavanja roditelja");
        }

        public static RoditeljDTO? vratiRoditelja(int id)
        {
            return izvrsiUpit(s =>
                s.Query<RoditeljStaratelj>()
                    .Where(x => x.Id == id)
                    .Select(x => new RoditeljDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Email,
                        x.Telefon,
                        x.Zanimanje,
                        x.RadnoMesto))
                    .FirstOrDefault(),
                "Greska prilikom pribavljanja roditelja iz baze");
        }

        public static List<RoditeljDTO> vratiRoditelje()
        {
            return izvrsiUpit(s =>
                s.Query<RoditeljStaratelj>()
                    .Select(x => new RoditeljDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Email,
                        x.Telefon,
                        x.Zanimanje,
                        x.RadnoMesto))
                    .ToList(),
                "Greska prilikom pribavljanja roditelja iz baze")
                ?? new List<RoditeljDTO>();
        }

        public static List<UcenikDTO> vratiDecuRoditelja(
            int roditeljId)
        {
            return izvrsiUpit(s =>
                s.Query<RoditeljStaratelj>()
                    .Where(x => x.Id == roditeljId)
                    .SelectMany(x => x.Deca)
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList(),
                "Greska prilikom pribavljanja dece roditelja")
                ?? new List<UcenikDTO>();
        }

        public static List<UcenikDTO>
            vratiUcenikeKojiNisuDeteRoditelja(int roditeljId)
        {
            return izvrsiUpit(s =>
            {
                var decaIds = s.Query<RoditeljStaratelj>()
                    .Where(x => x.Id == roditeljId)
                    .SelectMany(x => x.Deca)
                    .Select(x => x.Id);

                return s.Query<Ucenik>()
                    .Where(x => !decaIds.Contains(x.Id))
                    .Select(x => new UcenikDTO(
                        x.Id,
                        x.Ime,
                        x.Prezime,
                        x.JMBG,
                        x.Adresa,
                        x.Status.ToString()))
                    .ToList();

            }, "Greska prilikom pribavljanja ucenika za dodavanje veze")
            ?? new List<UcenikDTO>();
        }

        public static void dodajVezuRoditeljUcenik(
            int roditeljId,
            int ucenikId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                RoditeljStaratelj? r =
                    s.Get<RoditeljStaratelj>(roditeljId);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                if (r is null)
                    throw new Exception("Roditelj ne postoji u bazi");

                if (!u.Roditelji.Any(x => x.Id == roditeljId))
                    u.Roditelji.Add(r);

            }, "Greska prilikom dodavanja veze roditelj-ucenik");
        }

        public static void raskiniVezuRoditeljUcenik(
            int roditeljId,
            int ucenikId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);

                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                RoditeljStaratelj? r =
                    u.Roditelji.FirstOrDefault(
                        x => x.Id == roditeljId);

                if (r is null)
                    throw new Exception(
                        "Ova veza ne postoji u bazi");

                u.Roditelji.Remove(r);

            }, "Greska prilikom raskidanja veze roditelj-ucenik");
        }

        public static void izmeniRoditelja(
            int id,
            RoditeljStaratelj roditelj)
        {
            izvrsiUpit(s =>
            {
                if (s.Query<Osoba>().Any(
                    x => x.Email == roditelj.Email && x.Id != id))
                    throw new Exception(
                        "Osoba sa ovim emailom vec postoji");

                if (s.Query<Osoba>().Any(
                    x => x.JMBG == roditelj.JMBG && x.Id != id))
                    throw new Exception(
                        "Osoba sa ovim JMBG-om vec postoji");

                Osoba? osoba = s.Get<Osoba>(id);

                if (osoba is null)
                    throw new Exception(
                        "Roditelj ne postoji u bazi");

                osoba.Ime = roditelj.Ime;
                osoba.Prezime = roditelj.Prezime;
                osoba.JMBG = roditelj.JMBG;
                osoba.Adresa = roditelj.Adresa;
                osoba.Pol = roditelj.Pol;
                osoba.DatumRodjenja = roditelj.DatumRodjenja;
                osoba.Email = roditelj.Email;
                osoba.Telefon = roditelj.Telefon;
                osoba.Komentar = roditelj.Komentar;

                s.CreateSQLQuery(
                    "UPDATE RODITELJ_STARATELJ " +
                    "SET ZANIMANJE = :z, RADNO_MESTO = :r " +
                    "WHERE ID_OSOBA = :id")
                    .SetParameter("z", roditelj.Zanimanje)
                    .SetParameter("r", roditelj.RadnoMesto)
                    .SetParameter("id", id)
                    .ExecuteUpdate();

            }, "Greska prilikom izmene podataka o roditelju");
        }

        public static void obrisiRoditelja(int id)
        {
            izvrsiUpit(s =>
            {
                s.CreateSQLQuery(
                    "DELETE FROM STARATELJSTVO WHERE ID_STARATELJ = :id")
                    .SetParameter("id", id)
                    .ExecuteUpdate();

                if (!imaUlogu(s, "NASTAVNIK", id))
                {
                    RoditeljStaratelj? r =
                        s.Get<RoditeljStaratelj>(id);

                    if (r is null)
                        throw new Exception(
                            "Roditelj ne postoji u bazi");

                    s.Delete(r);
                }
                else
                {
                    s.CreateSQLQuery(
                        "DELETE FROM RODITELJ_STARATELJ WHERE ID_OSOBA = :id")
                        .SetParameter("id", id)
                        .ExecuteUpdate();
                }

            }, "Greska prilikom brisanja roditelja iz baze");
        }

        #endregion


        #region Statistika

        public static List<OcenaStatistikaDTO>
            vratiSveOceneZaStatistiku(int? idPredmeta = null)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Ocena>();

                if (idPredmeta.HasValue)
                    upit = upit.Where(x =>
                        x.Nastava.predajePredmet.Predmet.Id ==
                        idPredmeta.Value);

                return upit
                    .Select(x => new OcenaStatistikaDTO(
                        x.Ucenik.Ime + " " + x.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Tip,
                        x.Polugodje))
                    .ToList();

            }, "Greska prilikom pribavljanja ocena za statistiku")
            ?? new List<OcenaStatistikaDTO>();
        }

        public static List<OcenaStatistikaDTO>
            vratiSveOceneUcenika(int ucenikId)
        {
            return izvrsiUpit(s =>
                s.Query<Ocena>()
                    .Where(x => x.Ucenik.Id == ucenikId)
                    .Select(x => new OcenaStatistikaDTO(
                        x.Ucenik.Ime + " " + x.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Tip,
                        x.Polugodje))
                    .ToList(),
                "Greska prilikom pribavljanja ocena za statistiku")
                ?? new List<OcenaStatistikaDTO>();
        }

        public static List<IzostanakStatistikaDTO>
            vratiSveIzostankeZaStatistiku(
                string? skolskaGodina = null)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Izostanak>();

                if (!string.IsNullOrWhiteSpace(skolskaGodina))
                {
                    upit = upit.Where(x =>
                        x.Nastava.Odeljenje.SkolskaGodina ==
                        skolskaGodina);
                }

                return upit
                    .Select(x => new IzostanakStatistikaDTO(
                        x.Id.Ucenik.Ime + " " +
                        x.Id.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Nastava.Odeljenje.SkolskaGodina,
                        x.Id.Datum,
                        x.Id.RedniBrojCasa,
                        x.TipIzostanka))
                    .ToList();

            }, "Greska prilikom pribavljanja izostanaka za statistiku")
            ?? new List<IzostanakStatistikaDTO>();
        }

        public static List<string> vratiSkolskeGodine()
        {
            return izvrsiUpit(s =>
                s.Query<Odeljenje>()
                    .Select(x => x.SkolskaGodina)
                    .Distinct()
                    .OrderByDescending(x => x)
                    .ToList(),
                "Greska prilikom pribavljanja skolskih godina")
                ?? new List<string>();
        }

        #endregion
    }
}