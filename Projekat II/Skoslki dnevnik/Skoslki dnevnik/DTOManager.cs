using NHibernate.Util;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Security.Policy;

namespace Skoslki_dnevnik
{
    public static class DTOManager
    {

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
                MessageBox.Show($"{porukaGreske}");
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
                MessageBox.Show($"{porukaGreske}");
                return default!;
            }
        }

        #region Osoba

        private static int? idOsobePoJmbg(ISession s, string jmbg)
        {
            object? r = s.CreateSQLQuery("SELECT ID FROM OSOBA WHERE JMBG = :j")
                         .SetParameter("j", jmbg)
                         .UniqueResult();
            return r is null ? null : Convert.ToInt32(r);
        }

        private static bool imaUlogu(ISession s, string tabela, int idOsobe)
        {
            object r = s.CreateSQLQuery($"SELECT COUNT(*) FROM {tabela} WHERE ID_OSOBA = :id")
                        .SetParameter("id", idOsobe)
                        .UniqueResult();
            return Convert.ToInt32(r) > 0;
        }
        public static Osoba? vratiOsobuPoJmbg(string jmbg)
        {
            return izvrsiUpit<Osoba?>(s =>
                s.Query<Osoba>().FirstOrDefault(x => x.JMBG == jmbg),
                "Greska prilikom pretrage osobe po JMBG-u");
        }

        #endregion

        #region Ucenik
        public static void dodajUcenika(Ucenik u)
        {
            izvrsiUpit(s => s.Save(u), "Greska prilikom dodavanja ucenika");
        }

        public static List<Ucenik> vratiUcenike()
        {
            return izvrsiUpit(s => s.Query<Ucenik>()
                             .ToList(), "Greska pri preuzimanju ucenika iz baze") ?? new List<Ucenik>();
        }

        public static Ucenik vratiUcenika(int id)
        {
            return izvrsiUpit(s => s.Query<Ucenik>().Where(x => x.Id == id).FirstOrDefault(), "Greska prilikom pribavljanja ucenika iz baze")!;
        }
        public static void izmeniUcenika(int id, Ucenik u)
        {
            izvrsiUpit(s =>
            {
                Ucenik? uc = s.Query<Ucenik>().Where(x => x.Id == id).FirstOrDefault();
                if (uc is null) throw new Exception("Ucenik sa unetim idjem ne postoji u bazi");
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

        public static void obrisiUcenika(Ucenik u)
        {
            izvrsiUpit(s => s.Delete(u), "Greska prilikom brisanja ucenika iz baze podataka");
        }

        public static void dodeliPredmetUceniku(int uId, int pId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(uId);

                Predmet? p = s.Get<Predmet>(pId);

                if (u is null && p is null)
                    throw new Exception("Ucenik i predmet ne postoje u bazi podataka");

                if (u is null)
                {
                    throw new Exception("Ucenik ne postoji u bazi podataka");
                }
                if (p is null)
                {
                    throw new Exception("Predmet ne postoji u bazi podataka");
                }
                bool vecPostoji = s.Query<Ucenik>()
                             .Where(x => x.Id == uId)
                             .SelectMany(x => x.Predmeti)
                             .Any(x => x.Id == pId);

                if (!vecPostoji)
                    u.Predmeti.Add(p);

                s.Update(u);
            }, "Greska prilikom dobavljanja iz baze podataka");
        }

        public static string vratiRazred(int id)
        {
            return izvrsiUpit(s =>
            {
                bool postoji = s.Query<Ucenik>().Any(x => x.Id == id);
                if (!postoji)
                    throw new Exception("Ucenik sa unetim ID-jem ne postoji u bazi podataka");

                var rezultat = s.Query<Odeljenje>()
                    .Where(o => o.Ucenici.Any(u => u.Id == id))
                    .OrderByDescending(o => o.SkolskaGodina)
                    .Select(o => (int?)o.Razred)
                    .FirstOrDefault();

                return rezultat?.ToString() ?? "Nema podataka o odeljenju";
            }, "Greska prilikom dobavljanja podataka iz baze");
        }

        public static List<Predmet> vratiPredmeteUcenika(int ucenikId)
        {
            return izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                if (u is null)
                    throw new Exception("Ucenik sa unetim id-jem ne postoji u bazi podataka");

                return u.Predmeti.ToList();
            }, "Greska prilikom pribavljanja podataka iz baze") ?? new List<Predmet>();
        }

        #endregion

        #region Odeljenje
        public static void kreirajOdeljenje(Odeljenje o)
        {
            izvrsiUpit(s =>
            {
                if (s.Query<Odeljenje>().Any(x => x.Oznaka == o.Oznaka && x.Razred == o.Razred && x.SkolskaGodina == o.SkolskaGodina))
                {
                    throw new Exception("Odeljenje vec postoji u bazi podataka");
                }

                s.Save(o);
            }, "Greska prilikom kreiranja novog odeljenja");
        }

        public static Odeljenje vratiOdeljenje(int id)
        {
            return izvrsiUpit(s =>
            {
                Odeljenje o = s.Get<Odeljenje>(id);
                if (o is null) throw new Exception("Odeljenje ne postoji u bazi podataka");
                return o;
            }, "Greska prilikom dobavljanja odeljenja iz baze podataka");
        }

        public static List<Odeljenje> vratiOdeljenja(String? oznaka = null, String? skolskaGodina = null, int razred = 0)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Odeljenje>();

                if (oznaka != null)
                    upit = upit.Where(x => x.Oznaka == oznaka);
                if (razred != 0)
                    upit = upit.Where(x => x.Razred == razred);
                if (skolskaGodina != null)
                    upit = upit.Where(x => x.SkolskaGodina == skolskaGodina);

                return upit.ToList();
            }, "Greska prilikom dobavljanja odeljenja iz baze podataka");
        }

        public static void obrisiOdeljenje(int oId)
        {
            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(oId);
                if (o is null)
                    throw new Exception("Odeljenje sa unetim id-jem ne postoji u bazi");

                s.Delete(o);
            }, "Greska prilikom brisanja odeljenja");
        }

        public static void dodajUcenikaUOdeljenje(int oId, int uId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(uId);
                if (u is null)
                    throw new Exception("Ucenik ne postoji u bazi");

                Odeljenje? o = s.Get<Odeljenje>(oId);
                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                u.Odeljenja.Add(o);
                s.Update(u);
            }, "Greska prilikom dodavanja ucenika u odeljenje");
        }

        public static void izmeniOdeljenje(int oId, string? oznaka = null, string? skolskaGodina = null, int razred = 0)
        {
            if (oznaka is null && skolskaGodina is null && razred == 0) return;

            izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(oId);
                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi podataka");

                string novaOznaka = oznaka ?? o.Oznaka;
                string novaGodina = skolskaGodina ?? o.SkolskaGodina;
                int novaRazred = (razred == 0) ? o.Razred : razred;

                bool postojiDrugoIsto = s.Query<Odeljenje>()
                    .Any(x => x.Id != oId
                           && x.Oznaka == novaOznaka
                           && x.SkolskaGodina == novaGodina
                           && x.Razred == novaRazred);

                if (postojiDrugoIsto)
                    throw new Exception("Vec postoji odeljenje sa istim razredom, oznakom i skolskom godinom");

                o.Oznaka = novaOznaka;
                o.SkolskaGodina = novaGodina;
                o.Razred = novaRazred;
                s.Update(o);
            }, "Greska prilikom azuriranja odeljenja");
        }

        public static void dodeliPredmetOdeljenju(int oId, int pId)
        {
            izvrsiUpit(s =>
            {
                Predaje? predaje = s.Get<Predaje>(pId);
                if (predaje is null)
                    throw new Exception("Predaje zapis ne postoji u bazi podataka");

                Odeljenje? odeljenje = s.Get<Odeljenje>(oId);
                if (odeljenje is null)
                    throw new Exception("Odeljenje sa zadatim id-jem ne postoji u bazi");

                bool vecPostoji = s.Query<Nastava>()
                    .Any(x => x.predajePredmet.Id == pId && x.Odeljenje.Id == oId);

                if (vecPostoji)
                    throw new Exception("Ovaj predmet/nastavnik je vec dodeljen ovom odeljenju");

                Nastava n = new Nastava
                {
                    predajePredmet = predaje,
                    Odeljenje = odeljenje
                };

                s.Save(n);
            }, "Greska prilikom dodavanja predmeta odeljenju");
        }



        #endregion
        #region Nastavnik

        private static bool imaDodatnuUlogu(ISession s, int idNastavnik)
        {
            int razredni = Convert.ToInt32(
                s.CreateSQLQuery("SELECT COUNT(*) FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
                .SetParameter("id", idNastavnik)
                .UniqueResult());

            int rukovodeci = Convert.ToInt32(
                s.CreateSQLQuery("SELECT COUNT(*) FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                .SetParameter("id", idNastavnik)
                .UniqueResult());

            int strucni = Convert.ToInt32(
                s.CreateSQLQuery("SELECT COUNT(*) FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                .SetParameter("id", idNastavnik)
                .UniqueResult());

            return razredni > 0 || rukovodeci > 0 || strucni > 0;
        }
        public static List<NastavnikDTO> vratiNastavnike()
        {
            return izvrsiUpit(s =>
            {
                var rezultat = s.CreateSQLQuery(@"
            SELECT 
                o.ID,
                o.IME,
                o.PREZIME,
                o.JMBG,
                o.ADRESA,
                o.EMAIL,
                o.TELEFON,
                n.STATUS,
                n.ZVANJE,
                n.STRUCNA_SPREMA,
                n.DATUM_ZAPOSLENJA
            FROM OSOBA o
            JOIN NASTAVNIK n
                ON o.ID = n.ID_OSOBA
        ").List<object[]>();

                return rezultat.Select(x => new NastavnikDTO(
                Convert.ToInt32(x[0]),
                Convert.ToString(x[1])!,
                Convert.ToString(x[2])!,
                Convert.ToString(x[3])!,
                Convert.ToString(x[4])!,
                Convert.ToString(x[5])!,
                Convert.ToString(x[6])!,
                Enum.Parse<StatusNastavnika>(Convert.ToString(x[7])!),
                Convert.ToString(x[8])!,
                Convert.ToString(x[9])!,
                Convert.ToDateTime(x[10])
            )).ToList();

            }, "Greska pri preuzimanju nastavnika iz baze")
    ?? new List<NastavnikDTO>();
        }

        public static Nastavnik vratiNastavnika(int id)
        {
            return izvrsiUpit<Nastavnik>(s => {
                Nastavnik n = s.Get<Nastavnik>(id);
                if (n is null) throw new Exception("Nastavnik ne postoji u bazi podataka");
                return n;
            }, "Greska prilikom dobavljanja podataka o nastavniku iz baze");
        }

        public static void dodajNastavnika(Nastavnik nastavnik)
        {
            izvrsiUpit(s =>
            {
                int? idOsobe = idOsobePoJmbg(s, nastavnik.JMBG);

                if (idOsobe is null)
                {
                    s.Save(nastavnik);
                    return;
                }

                if (imaUlogu(s, "UCENIK", idOsobe.Value))
                    throw new Exception("Osoba sa ovim JMBG-om je ucenik i ne moze biti nastavnik");
                if (imaUlogu(s, "NASTAVNIK", idOsobe.Value))
                    throw new Exception("Nastavnik sa ovim JMBG-om vec postoji");

                s.CreateSQLQuery(
                    "INSERT INTO NASTAVNIK (ID_OSOBA, STRUCNA_SPREMA, STATUS, ZVANJE, DATUM_ZAPOSLENJA) " +
                    "VALUES (:id, :sprema, :status, :zvanje, :datum)")
                 .SetParameter("id", idOsobe.Value)
                 .SetParameter("sprema", nastavnik.StrucnaSprema)
                 .SetParameter("status", nastavnik.Status.ToString())
                 .SetParameter("zvanje", nastavnik.Zvanje)
                 .SetParameter("datum", nastavnik.DatumZaposlenja)
                 .ExecuteUpdate();
            }, "Greska pri dodavanju novog nastavnika");
        }

        public static void obrisiNastavnika(Nastavnik nastavnik)
        {
            izvrsiUpit(s =>
            {
                s.CreateSQLQuery("DELETE FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
         .SetParameter("id", nastavnik.Id).ExecuteUpdate();
                s.CreateSQLQuery("DELETE FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                 .SetParameter("id", nastavnik.Id).ExecuteUpdate();
                s.CreateSQLQuery("DELETE FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                 .SetParameter("id", nastavnik.Id).ExecuteUpdate();

                Nastavnik? n = s.Get<Nastavnik>(nastavnik.Id);
                if (n is null) return;

                foreach (Predaje p in n.Predaje.ToList())
                {
                    List<Nastava> nastave = s.Query<Nastava>().Where(x => x.predajePredmet.Id == p.Id).ToList();
                    foreach (Nastava nn in nastave)
                    {
                        s.CreateSQLQuery("DELETE FROM OCENA WHERE ID_NASTAVA = :id")
                         .SetParameter("id", nn.Id).ExecuteUpdate();
                        s.CreateSQLQuery("DELETE FROM IZOSTANAK WHERE ID_NASTAVA = :id")
                         .SetParameter("id", nn.Id).ExecuteUpdate();
                        s.Delete(nn);
                    }
                    s.Delete(p);
                }
                s.Flush();
                s.Evict(n);

                if (!imaUlogu(s, "RODITELJ_STARATELJ", nastavnik.Id))
                {
                    s.CreateSQLQuery("DELETE FROM NASTAVNIK WHERE ID_OSOBA = :id")
                     .SetParameter("id", nastavnik.Id).ExecuteUpdate();
                    s.CreateSQLQuery("DELETE FROM OSOBA WHERE ID = :id")
                     .SetParameter("id", nastavnik.Id).ExecuteUpdate();
                }
                else
                {
                    s.CreateSQLQuery("DELETE FROM NASTAVNIK WHERE ID_OSOBA = :id")
                     .SetParameter("id", nastavnik.Id).ExecuteUpdate();
                }
            }, "Greska pri brisanju nastavnika iz baze");
        }


        public static RazredniStaresina? vratiRazrednogStaresinu(int odeljenjeId)
        {
            return izvrsiUpit<RazredniStaresina?>(s =>
            {
                return s.Query<RazredniStaresina>().Where(x => x.Odeljenje.Id == odeljenjeId).FirstOrDefault();
            }, "Greska prilikom pribavljanja razrednog staresine za odeljenje");
        }

        public static void dodeliRazrednogStaresinu(int idNastavnik, int idOdeljenje, DateTime datumPreuzimanja, string? napomena)
        {
            izvrsiUpit(s =>
            {
                Nastavnik? n = s.Get<Nastavnik>(idNastavnik);

                if (n is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                Odeljenje? o = s.Get<Odeljenje>(idOdeljenje);

                if (o is null)
                    throw new Exception("Odeljenje ne postoji u bazi");

                int postoji = Convert.ToInt32(
                    s.CreateSQLQuery(
                        "SELECT COUNT(*) FROM RAZREDNI_STARESINA WHERE ID_ODELJENJE = :id")
                    .SetParameter("id", idOdeljenje)
                    .UniqueResult()
                );

                if (postoji > 0)
                    throw new Exception("Ovo odeljenje vec ima razrednog staresinu");

                int nastavnikJeRazredni = Convert.ToInt32(
                    s.CreateSQLQuery(
                        "SELECT COUNT(*) FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", idNastavnik)
                    .UniqueResult()
                );

                if (nastavnikJeRazredni > 0)
                    throw new Exception("Nastavnik je vec razredni staresina");

                s.CreateSQLQuery(
                    "INSERT INTO RAZREDNI_STARESINA " +
                    "(ID_NASTAVNIK, ID_ODELJENJE, DATUM_PREUZIMANJA_STARESINSTVA, BROJ_ODRZANIH_SASTANAKA, NAPOMENA) " +
                    "VALUES (:idN, :idO, :datum, 0, :napomena)")
                    .SetParameter("idN", idNastavnik)
                    .SetParameter("idO", idOdeljenje)
                    .SetParameter("datum", datumPreuzimanja)
                    .SetParameter("napomena", napomena)
                    .ExecuteUpdate();

            }, "Greska prilikom dodele razrednog staresinstva");
        }

        public static void dodeliRukovodecuFunkciju(int idNastavnik, string pozicija, string oblastOdgovornosti, DateTime? datumPreuzimanja, int? godineStaza)
        {
            izvrsiUpit(s =>
            {
                if (imaDodatnuUlogu(s, idNastavnik))
                    throw new Exception("Nastavnik vec ima dodatnu ulogu (razredni staresina / rukovodece osoblje / strucni saradnik)");

                Nastavnik? n = s.Get<Nastavnik>(idNastavnik);
                if (n is null) throw new Exception("Nastavnik ne postoji u bazi");

                s.CreateSQLQuery(
                    "INSERT INTO RUKOVODECE_OSOBLJE (ID_NASTAVNIK, POZICIJA, DATUM_PREUZIMANJA_FUNKCIJE, OBLAST_ODGOVORNOSTI, GODINE_STAZA) " +
                    "VALUES (:idN, :pozicija, :datum, :oblast, :staz)")
                 .SetParameter("idN", idNastavnik)
                 .SetParameter("pozicija", pozicija)
                 .SetParameter("datum", datumPreuzimanja)
                 .SetParameter("oblast", oblastOdgovornosti)
                 .SetParameter("staz", godineStaza)
                 .ExecuteUpdate();
            }, "Greska prilikom dodele rukovodece funkcije");
        }

        public static void dodeliStrucnogSaradnika(int idNastavnik, string licenca, string strucnaOblast, int brojRadionica, int? brojRazgovora)
        {
            izvrsiUpit(s =>
            {
                if (imaDodatnuUlogu(s, idNastavnik))
                    throw new Exception("Nastavnik vec ima dodatnu ulogu (razredni staresina / rukovodece osoblje / strucni saradnik)");

                Nastavnik? n = s.Get<Nastavnik>(idNastavnik);
                if (n is null) throw new Exception("Nastavnik ne postoji u bazi");

                s.CreateSQLQuery(
                    "INSERT INTO STRUCNI_SARADNIK (ID_NASTAVNIK, LICENCA, STRUCNA_OBLAST, BROJ_ODRZANIH_RADIONICA, BROJ_SPROVEDENIH_RAZGOVORA) " +
                    "VALUES (:idN, :licenca, :oblast, :radionice, :razgovori)")
                 .SetParameter("idN", idNastavnik)
                 .SetParameter("licenca", licenca)
                 .SetParameter("oblast", strucnaOblast)
                 .SetParameter("radionice", brojRadionica)
                 .SetParameter("razgovori", brojRazgovora)
                 .ExecuteUpdate();
            }, "Greska prilikom dodele uloge strucnog saradnika");
        }

        public static void ukiniDodatnuUlogu(int idNastavnik)
        {
            izvrsiUpit(s =>
            {
                s.CreateSQLQuery("DELETE FROM RAZREDNI_STARESINA WHERE ID_NASTAVNIK = :id")
                 .SetParameter("id", idNastavnik).ExecuteUpdate();
                s.CreateSQLQuery("DELETE FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                 .SetParameter("id", idNastavnik).ExecuteUpdate();
                s.CreateSQLQuery("DELETE FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                 .SetParameter("id", idNastavnik).ExecuteUpdate();
            }, "Greska prilikom ukidanja dodatne uloge");
        }

        public static void izmeniNastavnika(int id, Nastavnik nastavnik)
        {
            izvrsiUpit(s =>
            {
                if (s.Query<Osoba>().Any(x => x.Email == nastavnik.Email && x.Id != id))
                    throw new Exception("Osoba sa ovim emailom vec postoji u bazi podataka");
                if (s.Query<Osoba>().Any(x => x.JMBG == nastavnik.JMBG && x.Id != id))
                    throw new Exception("Osoba sa ovim JMBG-om vec postoji u bazi podataka");

                Nastavnik? n = s.Get<Nastavnik>(id);
                if (n is null)
                    throw new Exception("Nastavnik ne postoji u bazi podataka");

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

        public static List<PredmetiDTO> vratiPredmeteNastavnika(int id, String? SkolskaGodina = null) {
            return izvrsiUpit(s =>
            {
                return s.Query<Predaje>()
                .Where(n => n.Nastavnik.Id == id &&
                            (SkolskaGodina == null ||
                            n.Predmet.SkolskaGodina == SkolskaGodina))
                .Select(n => new PredmetiDTO(n.Predmet.Id, n.Predmet.Naziv, n.Predmet.SkolskaGodina, n.Predmet.Razred))
                .Distinct()
                .ToList();
            }, "Greska prilikom dobavljanja podataka iz baze podataka");
        }

        public static List<Ucenik> vratiUcenikeZaPredmet(int odeljenjeId, int predmetId, int nastavnikId)
        {
            return izvrsiUpit<List<Ucenik>>(s =>
            {
                return s.Query<Nastava>()
                    .Where(x => x.Odeljenje.Id == odeljenjeId && x.predajePredmet.Predmet.Id == predmetId && x.predajePredmet.Nastavnik.Id == nastavnikId)
                    .SelectMany(x => x.Odeljenje.Ucenici)
                    .ToList();
            }, "Greska pri pribavljanju podataka iz baze") ?? new List<Ucenik>();
        }

        public static void dodeliOcenu(Ocena ocena) {
            izvrsiUpit(s => s.Save(ocena), "Greska prilikom dodele ocene");
        }

        public static List<OcenaDTO> pregledajOceneUcenikaZaPredmet(int ucenikId, int predmetId) {
            return izvrsiUpit<List<OcenaDTO>>(s =>
            {
                return s.Query<Ocena>()
                        .Where(x => x.Ucenik.Id == ucenikId && x.Ucenik.Predmeti.Any(x => x.Id == predmetId))
                        .Select(x => new OcenaDTO(x.Vrednost, x.DatumOcenjivanja, x.Polugodje))
                        .OrderByDescending(x => x.datumOcenjivanja)
                        .ToList();
            }, "Greska prilikom pribavljanja podataka iz baze");
        }

        public static void dodeliPredmetNastavniku(int idNastavnik, List<PredmetiDTO> predmeti) {
            izvrsiUpit(s =>
            {
                Nastavnik n = s.Load<Nastavnik>(idNastavnik);
                predmeti.ForEach(p =>
                {
                    s.Save(new Predaje
                    {
                        Nastavnik = n,
                        Predmet = s.Load<Predmet>(p.id)
                    });
                });
            }, "Greska prilikom azuriranja podataka u bazi");
        }
        #endregion

        #region Predmet
        public static List<Predmet> vratiPredmete(String? skolskaGodina = null)
        {
            return izvrsiUpit<List<Predmet>>(s =>
            {
                List<Predmet> predmeti = s.Query<Predmet>().ToList();
                if (!String.IsNullOrWhiteSpace(skolskaGodina))
                {
                    predmeti = predmeti.Where(x => x.SkolskaGodina == skolskaGodina).ToList();
                }
                return predmeti;
            }, "Greska prilikom pribavljanja podataka iz baze") ?? new List<Predmet>();
        }

        public static Predmet vratiPredmet(int id)
        {
            return izvrsiUpit<Predmet>(s => s.Get<Predmet>(id), "Greska prilikom pribavljanja iz baze podataka");
        }
        public static void dodajPredmet(Predmet p)
        {
            izvrsiUpit(s => s.Save(p), "Greska prilikom dodavanja predmeta u bazu podataka");
        }

        public static void obrisiPredmet(Predmet p)
        {
            izvrsiUpit(s => s.Delete(p), "Greska prilikom brisanja predmeta iz baze podataka");
        }

        public static void izmeniPredmet(int id, Predmet predmet)
        {
            izvrsiUpit(s =>
            {
                if (predmet is null)
                {
                    throw new Exception("Greska prilikom izmene predmeta");
                }
                Predmet p = s.Get<Predmet>(id);
                p.Naziv = predmet.Naziv;
                p.SkolskaGodina = predmet.SkolskaGodina;
                p.Opis = predmet.Opis;
                p.Komentar = predmet.Komentar;
                p.NedeljniFond = predmet.NedeljniFond;
                p.Razred = predmet.Razred;
                p.Tip = predmet.Tip;
                if (p is null) throw new Exception("Predmet sa unetim Idjem ne postoji u bazi podataka");


            }, "Greska prilikom izmene predmeta iz baze podataka");
        }

        public static List<UcenikDTO> vratiUcenikeKojiSlusajuPredmet(int idPredmeta)
        {
            return izvrsiUpit(s => s.Query<Ucenik>()
                                                  .Where(x => x.Predmeti
                                                  .Any(p => p.Id == idPredmeta))
                                                  .Select(u => new UcenikDTO(u.Id, u.Ime, u.Prezime, u.JMBG, u.Adresa, u.Status.ToString()))
                                                  .ToList(),
                "Nijedan ucenik ne slusa dati predmet");
        }

        public static List<Ocena> vratiOceneUcenikaNaPredmetu(int ucenikId, int predmetId)
        {
            return izvrsiUpit<List<Ocena>>(s =>
                s.Query<Ocena>()
                .Where(x => x.Ucenik.Id == ucenikId && x.Nastava.predajePredmet.Predmet.Id == predmetId)
                .ToList(), "Greska prilikom pribavljanja podataka iz baze") ?? new List<Ocena>();
        }

        public static List<Ocena> vratiOcenePoTipu(TipOcene tip)
        {
            return izvrsiUpit<List<Ocena>>(s =>
            {
                return s.Query<Ocena>().Where(x => x.Tip == tip).ToList();
            }, "Greska prilikom dobavljanja ocena iz baze") ?? new List<Ocena>();
        }

        public static List<PredmetiDTO> vratiPredmeteZaOdabir(int nastavnikId) {
            return izvrsiUpit(s =>
            {
                return s.Query<Predmet>()
                        .Where(x => !x.Predaje.Any(p => p.Nastavnik.Id == nastavnikId))
                        .OrderByDescending(x => x.SkolskaGodina)
                        .ThenBy(x => x.Razred)
                        .Select(x => new PredmetiDTO(x.Id, x.Naziv, x.SkolskaGodina, x.Razred))
                        .ToList();
            }, "Greska prilikom pribavljanja podataka iz baze");
        }

        public static Nastava vratiNastavu(int nastavnikId, int predmetId) {
            return izvrsiUpit(s =>
                s.Query<Nastava>().Where(x => x.predajePredmet.Nastavnik.Id == nastavnikId && x.predajePredmet.Predmet.Id == predmetId).FirstOrDefault()!
                , "Greska prilikom dobavljanaj nastave");
        }

        public static void izmeniOcenu(int id, Ocena novaOcena)
        {
            izvrsiUpit(s =>
            {
                Ocena o = s.Get<Ocena>(id);
                o.Tip = novaOcena.Tip;
                o.Vrednost = novaOcena.Vrednost;
                o.DatumOcenjivanja = novaOcena.DatumOcenjivanja;
                o.Komentar = novaOcena.Komentar;
                o.Polugodje = novaOcena.Polugodje;
                s.Update(o);
            }, "Greska prilikom izmene ocene");
        }

        public static void obrisiOcenu(Ocena ocena) => izvrsiUpit(s => s.Delete(ocena), "Greska prilikom brisanja ocene");

        public static void izbaciUcenikaSaPredmeta(int idUcenik, int idPredmet)
        {
            izvrsiUpit(s =>
            {
                Ucenik u = s.Get<Ucenik>(idUcenik);
                Predmet p = s.Get<Predmet>(idPredmet);
                if (u is null) throw new Exception("Nepostojeci ucenik");
                if (p is null) throw new Exception("Nepostojeci predmet");
                if (!u.Predmeti.Any(x => x.Id == p.Id))
                    throw new Exception("Ucenik ne slusa predmet");
                if (p.Tip == TipPredmeta.OBAVEZNI) throw new Exception("Mozete izbaciti ucenika samo sa neobaveznih predmete");
                u.Predmeti.Remove(p);
                s.Update(u);
            }, "Greska prilikom izbacivanja ucenika sa predmeta");
        }
        #endregion


    #region Izostanak
        
        public static void dodajIzostanak(Izostanak izostanak)
        {
            izvrsiUpit(s => s.Save(izostanak), "Greska prilikom dodavanja izostanka");
        }

        public static List<IzostanakDTO> vratiIzostankeUcenikaNaPredmetu(int ucenikId, int predmetId)
        {
            return izvrsiUpit<List<IzostanakDTO>>(s =>
                s.Query<Izostanak>()
                .Where(x => x.Id.Ucenik.Id == ucenikId && x.Nastava.predajePredmet.Predmet.Id == predmetId)
                .Select(x=>new IzostanakDTO(x.Nastava.predajePredmet.Predmet.Naziv, x.Id.RedniBrojCasa, x.Id.Datum, 
                                            x.TipIzostanka.ToString(), (x.Opravdao == null) ? " " : x.Opravdao.ToString()!, x.RazlogIzostanka, x.Komentar))
                .ToList(), "Greska prilikom pribavljanja izostanaka iz baze") ?? new List<IzostanakDTO>();
        }

        public static void izmeniIzostanak(IzostanakDTO i, int idUcenik, string komentar)
        {
            izvrsiUpit(s =>
            {
                Izostanak? izostanak = s.Query<Izostanak>()
                      .Where(x => x.Id.Datum.Date == i.datum.Date && x.Id.RedniBrojCasa == i.cas && x.Id.Ucenik.Id == idUcenik)
                      .FirstOrDefault();
                if (izostanak is null)
                    throw new Exception("Izostanak sa unetim podacima ne postoji u bazi");
                izostanak.Komentar = komentar;
                s.Update(izostanak);
            }, "Greska prilikom izmene izostanka");
        }

        public static void obrisiIzostanak(IzostanakDTO izostanak, int idUcenik) =>
            izvrsiUpit(s => {
                s.Delete(s.Query<Izostanak>()
                          .Where(x => x.Id.Datum == izostanak.datum && x.Id.RedniBrojCasa == izostanak.cas && x.Id.Ucenik.Id == idUcenik)
                          .FirstOrDefault());
            }, "Greska prilikom brisanja izostanka");
        #endregion

        #region Predmeti
        public static List<PredmetiDTO> vratiPredmeteKojeUcenikNeSlusa(Ucenik u)
        {
            return izvrsiUpit(s =>
            {
                return s.Query<Predmet>()
                        .Where(x => !x.Polaznici.Contains(u))
                        .Select(x => new PredmetiDTO(x.Id, x.Naziv, x.SkolskaGodina, x.Razred))
                        .ToList();
            }, "Greska prilikom dobavljanja podataka");
        }

        public static List<IzostanakDTO> vratiSveIzostankeUcenika(int ucenikId) {
            return izvrsiUpit(s => s.Query<Izostanak>()
                                                 .Where(x => x.Id.Ucenik.Id == ucenikId)
                                                 .OrderByDescending(x => x.Id.Datum)
                                                 .ThenByDescending(x => x.Id.RedniBrojCasa)
                                                 .Select(x => new IzostanakDTO(x.Nastava.predajePredmet.Predmet.Naziv,
                                                                               x.Id.RedniBrojCasa,
                                                                               x.Id.Datum,
                                                                               x.TipIzostanka.ToString(),
                                                                               x.Opravdao.ToString()!,
                                                                               x.RazlogIzostanka,
                                                                               x.Komentar))
                                                 .ToList()
           , "Greska pilikom dobavljanja podataka iz baze");
        }
        #endregion

        #region Roditelj
        public static void dodajRoditelja(RoditeljStaratelj r)
        {
            izvrsiUpit(s =>
            {
                if (r is null)
                    throw new Exception("Roditelj nije prosledjen");

                Osoba? postojeca = s.Query<Osoba>().FirstOrDefault(x => x.JMBG == r.JMBG);

                if (postojeca is null)
                {
                    s.Save(r);
                }
                else if (postojeca is Ucenik)
                {
                    throw new Exception("Osoba sa ovim JMBG-om je ucenik i ne moze biti roditelj");
                }
                else if (postojeca is RoditeljStaratelj)
                {
                    throw new Exception("Roditelj sa ovim JMBG-om vec postoji");
                }
                else if (postojeca is Nastavnik)
                {
                    // overlap: red u OSOBA vec postoji, dodaje se samo red u RODITELJ_STARATELJ
                    s.CreateSQLQuery(
                            "INSERT INTO RODITELJ_STARATELJ (ID_OSOBA, ZANIMANJE, RADNO_MESTO) " +
                            "VALUES (:id, :zanimanje, :radnoMesto)")
                     .SetParameter("id", postojeca.Id)
                     .SetParameter("zanimanje", r.Zanimanje)
                     .SetParameter("radnoMesto", r.RadnoMesto)
                     .ExecuteUpdate();
                }
            }, "Greska prilikom dodavanja roditelja");
        }

        public static void izmeniRoditelja(int id, RoditeljStaratelj roditelj)
        {
            izvrsiUpit(s =>
            {
                if (s.Query<Osoba>().Any(x => x.Email == roditelj.Email && x.Id != id))
                    throw new Exception("Osoba sa ovim emailom vec postoji u bazi podataka");
                if (s.Query<Osoba>().Any(x => x.JMBG == roditelj.JMBG && x.Id != id))
                    throw new Exception("Osoba sa ovim JMBG-om vec postoji u bazi podataka");

                Osoba? osoba = s.Query<Osoba>().FirstOrDefault(x => x.Id == id);
                if (osoba is null)
                    throw new Exception("Roditelj ne postoji u bazi podataka");

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
                    "UPDATE RODITELJ_STARATELJ SET ZANIMANJE = :z, RADNO_MESTO = :r WHERE ID_OSOBA = :id")
                 .SetParameter("z", roditelj.Zanimanje)
                 .SetParameter("r", roditelj.RadnoMesto)
                 .SetParameter("id", id)
                 .ExecuteUpdate();

            }, "Greska prilikom izmene podataka o roditelju");
        }

        public static void obrisiRoditelja(RoditeljStaratelj roditelj)
        {
            izvrsiUpit(s =>
            {
                s.CreateSQLQuery("DELETE FROM STARATELJSTVO WHERE ID_STARATELJ = :id")
                 .SetParameter("id", roditelj.Id)
                 .ExecuteUpdate();

                if (!imaUlogu(s, "NASTAVNIK", roditelj.Id))
                {
                    RoditeljStaratelj? r = s.Get<RoditeljStaratelj>(roditelj.Id);
                    if (r is null)
                        throw new Exception("Roditelj ne postoji u bazi podataka");

                    s.Delete(r);
                }
                else
                {
                    s.CreateSQLQuery("DELETE FROM RODITELJ_STARATELJ WHERE ID_OSOBA = :id")
                     .SetParameter("id", roditelj.Id)
                     .ExecuteUpdate();
                }
            }, "Greska prilikom brisanja roditelja iz baze");
        }

        public static RoditeljStaratelj? vratiRoditelja(int id)
        {
            return izvrsiUpit<RoditeljStaratelj?>(s => s.Get<RoditeljStaratelj>(id),
                "Greska prilikom pribavljanja roditelja iz baze");
        }

        public static List<RoditeljDTO> vratiRoditelje()
        {
            return izvrsiUpit(s => s.Query<RoditeljStaratelj>()
                    .Select(r => new RoditeljDTO(r.Id, r.Ime, r.Prezime, r.JMBG, r.Adresa,
                                                  r.Email, r.Telefon, r.Zanimanje, r.RadnoMesto))
                    .ToList(),
                "Greska prilikom pribavljanja roditelja iz baze") ?? new List<RoditeljDTO>();
        }

        public static List<UcenikDTO> vratiDecuRoditelja(int roditeljId)
        {
            return izvrsiUpit(s => s.Query<RoditeljStaratelj>()
                    .Where(r => r.Id == roditeljId)
                    .SelectMany(r => r.Deca)
                    .Select(u => new UcenikDTO(u.Id, u.Ime, u.Prezime, u.JMBG, u.Adresa, u.Status.ToString()))
                    .ToList(),
                "Greska prilikom pribavljanja dece roditelja") ?? new List<UcenikDTO>();
        }

        public static List<UcenikDTO> vratiUcenikeKojiNisuDeteRoditelja(int roditeljId)
        {
            return izvrsiUpit(s =>
            {
                var decaIds = s.Query<RoditeljStaratelj>()
                               .Where(r => r.Id == roditeljId)
                               .SelectMany(r => r.Deca)
                               .Select(u => u.Id);

                return s.Query<Ucenik>()
                        .Where(u => !decaIds.Contains(u.Id))
                        .Select(u => new UcenikDTO(u.Id, u.Ime, u.Prezime, u.JMBG, u.Adresa, u.Status.ToString()))
                        .ToList();
            }, "Greska prilikom pribavljanja ucenika za dodavanje veze") ?? new List<UcenikDTO>();
        }

        public static void dodajVezuRoditeljUcenik(int roditeljId, int ucenikId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                RoditeljStaratelj? r = s.Get<RoditeljStaratelj>(roditeljId);
                if (u is null) throw new Exception("Ucenik ne postoji u bazi");
                if (r is null) throw new Exception("Roditelj ne postoji u bazi");

                if (!u.Roditelji.Any(x => x.Id == roditeljId))
                    u.Roditelji.Add(r);
            }, "Greska prilikom dodavanja veze roditelj-ucenik");
        }

        public static void raskiniVezuRoditeljUcenik(int roditeljId, int ucenikId)
        {
            izvrsiUpit(s =>
            {
                Ucenik? u = s.Get<Ucenik>(ucenikId);
                if (u is null) throw new Exception("Ucenik ne postoji u bazi");

                RoditeljStaratelj? r = u.Roditelji.FirstOrDefault(x => x.Id == roditeljId);
                if (r is null) throw new Exception("Ova veza ne postoji u bazi");

                u.Roditelji.Remove(r);
            }, "Greska prilikom raskidanja veze roditelj-ucenik");
        }
        #endregion

        #region Statistika

        public static List<OcenaStatistikaDTO> vratiSveOceneZaStatistiku(int? idPredmeta = null)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Ocena>();
                if (idPredmeta.HasValue)
                    upit = upit.Where(x => x.Nastava.predajePredmet.Predmet.Id == idPredmeta.Value);

                return upit.Select(x => new OcenaStatistikaDTO(
                        x.Ucenik.Ime + " " + x.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Tip,
                        x.Polugodje))
                    .ToList();
            }, "Greska prilikom pribavljanja ocena za statistiku") ?? new List<OcenaStatistikaDTO>();
        }

        public static List<OcenaStatistikaDTO> vratiSveOceneUcenika(int idUcenika)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Ocena>().Where(x=>x.Ucenik.Id == idUcenika);
                return upit.Select(x => new OcenaStatistikaDTO(
                        x.Ucenik.Ime + " " + x.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Vrednost,
                        x.DatumOcenjivanja,
                        x.Tip,
                        x.Polugodje))
                    .ToList();
            }, "Greska prilikom pribavljanja ocena za statistiku") ?? new List<OcenaStatistikaDTO>();
        }

        public static List<IzostanakStatistikaDTO> vratiSveIzostankeZaStatistiku(string? skolskaGodina = null)
        {
            return izvrsiUpit(s =>
            {
                var upit = s.Query<Izostanak>();
                if (!string.IsNullOrWhiteSpace(skolskaGodina))
                    upit = upit.Where(x => x.Nastava.Odeljenje.SkolskaGodina == skolskaGodina);

                return upit.Select(x => new IzostanakStatistikaDTO(
                        x.Id.Ucenik.Ime + " " + x.Id.Ucenik.Prezime,
                        x.Nastava.predajePredmet.Predmet.Naziv,
                        x.Nastava.Odeljenje.SkolskaGodina,
                        x.Id.Datum,
                        x.Id.RedniBrojCasa,
                        x.TipIzostanka))
                    .ToList();
            }, "Greska prilikom pribavljanja izostanaka za statistiku") ?? new List<IzostanakStatistikaDTO>();
        }

        public static List<string> vratiSkolskeGodine()
        {
            return izvrsiUpit(s => s.Query<Odeljenje>()
                    .Select(o => o.SkolskaGodina)
                    .Distinct()
                    .OrderByDescending(g => g)
                    .ToList(),
                "Greska prilikom pribavljanja skolskih godina") ?? new List<string>();
        }

        public static List<Ucenik> vratiUcenikeKojiNisuUOdeljenju(int idOdeljenja)
        {
            return izvrsiUpit(s =>
            {
                Odeljenje o = s.Load<Odeljenje>(idOdeljenja);
                return s.Query<Ucenik>().Where(x => !x.Odeljenja.Any(x => x.Id == idOdeljenja) && 
                (
                        (x.Status == StatusUcenika.AKTIVAN 
                        && 
                        int.Parse(o.SkolskaGodina.Substring(0, 4)) - o.Razred + 1 == int.Parse(x.GodinaUpisa.Substring(0, 4)))
                    ||
                        (x.Status == StatusUcenika.PONAVLJA 
                        && 
                        int.Parse(o.SkolskaGodina.Substring(0, 4)) - o.Razred == int.Parse(x.GodinaUpisa.Substring(0, 4))

                ))).ToList();
            }, "Greska prilikom vracanja podataka iz baze");
        }

        public static void dodajUcenikeUOdeljenje(List<Ucenik> selektovano)
        {
            izvrsiUpit(s => {
                foreach (var ucenik in selektovano)
                {
                    s.Save(ucenik);
                }
            }, "Greska prilikom upisivanja ucenika u bazu");
        }

        public static List<NastavaDTO> vratiNastavuZaDodavanjeOdeljenju(int odeljenjeID)
        {
            return izvrsiUpit(s =>
            {
                Odeljenje? o = s.Get<Odeljenje>(odeljenjeID);
                if (o is null)
                    throw new Exception("Odeljenje sa unetim id-jem ne postoji u bazi");

                return s.Query<Predaje>()
                .Where(p => p.Predmet.SkolskaGodina == o.SkolskaGodina
                         && p.Predmet.Razred == o.Razred
                         && !p.Nastave.Any(n => n.Odeljenje.Id == odeljenjeID))
                .Select(p => new NastavaDTO(
                    p.Id,
                    p.Predmet.Naziv,
                    p.Predmet.Razred,
                    p.Predmet.SkolskaGodina,
                    p.Nastavnik.Ime))
                .ToList();
            }, "Greska prilikom pribavljanja podataka iz baze") ?? new List<NastavaDTO>();
        }

        public static void dodeliNastavuOdeljenju(int odeljenjeID, List<NastavaDTO> nastave)
        {
            izvrsiUpit(s =>
            {
                Odeljenje o = s.Load<Odeljenje>(odeljenjeID);
                nastave.ForEach(x =>
                {
                    Predaje? p = s.Get<Predaje>(x.id);
                    if (p is null)
                        throw new Exception("Predaje zapis sa unetim id-jem ne postoji u bazi");
                    Nastava n = new Nastava
                    {
                        Odeljenje = o,
                        predajePredmet = p
                    };
                    s.Save(n);
                    foreach (Ucenik u in o.Ucenici)
                    {
                        if (!u.Predmeti.Any(pr => pr.Id == p.Predmet.Id))
                            u.Predmeti.Add(p.Predmet);
                    }
                });
            }, "Greska prilikom povezivanja predmeta i nastave");
        }


        public static Predaje vratiNastavu(int id) {
            return izvrsiUpit(s => s.Get<Predaje>(id), "Greska prilikom dobavljanja podataka");
        }


        public static Izostanak? vratiIzostanak(int idUcenik, DateTime datum, int cas)
        {
            return izvrsiUpit(s =>
            {
                Izostanak? i = s.Query<Izostanak>()
                               .Where(x => x.Id.Ucenik.Id == idUcenik && x.Id.Datum.Date == datum.Date && x.Id.RedniBrojCasa == cas)
                               .FirstOrDefault();
                if (i is null) throw new Exception("Nepostojeci izostanak");
                return i;
            }, "Greska prilikom vracanja izostanka iz baze");
        }

        public static List<OdeljenjeDTO> vratiOdlejenjaBezRazrednog()
        {
            return izvrsiUpit(s =>
            {
                List<int> odeljenjaSaRazrednim = s.Query<RazredniStaresina>()
                    .Select(x => x.Odeljenje.Id)
                    .ToList();

                return s.Query<Odeljenje>()
                    .Where(x => !odeljenjaSaRazrednim.Contains(x.Id))
                    .Select(x => new OdeljenjeDTO(x.Id, x.Oznaka, x.SkolskaGodina, x.Razred))
                    .ToList();
            }, "Greska prilikom vracanja podataka");
        }

        public static void dodajStrucnogSaradnika(int idNastavnik, string licenca, StrucnaOblast s, int brojSprovedenihRazgovora, int brojRadionica)
        {
            izvrsiUpit(s =>
            {
                Nastavnik? nastavnik = s.Get<Nastavnik>(idNastavnik);

                if (nastavnik is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                int postoji = Convert.ToInt32(
                    s.CreateSQLQuery(
                        "SELECT COUNT(*) FROM STRUCNI_SARADNIK WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", idNastavnik)
                    .UniqueResult()
                );

                if (postoji > 0)
                    throw new Exception("Nastavnik je vec strucni saradnik");

                s.CreateSQLQuery(
                    "INSERT INTO STRUCNI_SARADNIK " +
                    "(ID_NASTAVNIK, LICENCA, STRUCNA_OBLAST, BROJ_ODRZANIH_RADIONICA, BROJ_SPROVEDENIH_RAZGOVORA) " +
                    "VALUES (:id, :licenca, :oblast, :radionice, :razgovori)")
                    .SetParameter("id", idNastavnik)
                    .SetParameter("licenca", licenca)
                    .SetParameter("oblast", s.ToString())
                    .SetParameter("radionice", brojRadionica)
                    .SetParameter("razgovori", brojSprovedenihRazgovora)
                    .ExecuteUpdate();

            }, "Greska prilikom dodavanja strucnog saradnika");
        }

        public static void dodajRukovodeciOrgan(int idNastavnik, RukovodecaPozicija pozicija, OblastOdgovornosti oblastOdgovornosti, DateTime datumPreuzimanjaFje, int staz)
        {
            izvrsiUpit(s =>
            {
                Nastavnik? nastavnik = s.Get<Nastavnik>(idNastavnik);

                if (nastavnik is null)
                    throw new Exception("Nastavnik ne postoji u bazi");

                int postoji = Convert.ToInt32(
                    s.CreateSQLQuery(
                        "SELECT COUNT(*) FROM RUKOVODECE_OSOBLJE WHERE ID_NASTAVNIK = :id")
                    .SetParameter("id", idNastavnik)
                    .UniqueResult()
                );

                if (postoji > 0)
                    throw new Exception("Nastavnik je vec deo rukovodeceg osoblja");

                s.CreateSQLQuery(
                    "INSERT INTO RUKOVODECE_OSOBLJE " +
                    "(ID_NASTAVNIK, POZICIJA, OBLAST_ODGOVORNOSTI, DATUM_PREUZIMANJA_FUNKCIJE, GODINE_STAZA) " +
                    "VALUES (:id, :pozicija, :oblast, :datum, :staz)")
                    .SetParameter("id", idNastavnik)
                    .SetParameter("pozicija", pozicija.ToString())
                    .SetParameter("oblast", oblastOdgovornosti.ToString())
                    .SetParameter("datum", datumPreuzimanjaFje)
                    .SetParameter("staz", staz)
                    .ExecuteUpdate();

            }, "Greska prilikom dodavanja rukovodeceg osoblja");
        }


        #endregion
    }
}

