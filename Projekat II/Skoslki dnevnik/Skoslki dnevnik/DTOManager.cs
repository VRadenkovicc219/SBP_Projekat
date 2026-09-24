using FluentNHibernate.Conventions.Inspections;
using NHibernate.Linq;
using NHibernate.Proxy;
using NHibernate.Util;
using Skoslki_dnevnik.Entiteti.KompozitniKljucevi;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Skoslki_dnevnik
{
    public static class DTOManager
    {
        
        private static void izvrsiUpit(Action<ISession> upit, string porukaGreske) {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction t = s.BeginTransaction())
                {
                    upit(s);
                    t.Commit();
                }
            }
            catch (Exception ex){
                MessageBox.Show($"{porukaGreske}: {ex.Message}");
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
                MessageBox.Show($"{porukaGreske}: {ex.Message}");
                return default;
            }
        }

        #region Osoba
        public static void dodajOsobu(Osoba o)
        {
            izvrsiUpit(s => s.Save(o), "Greska prilikom dodavanja osobe");
        }



        #endregion

        #region Ucenik
        public static void dodajUcenika(Ucenik u) {
            izvrsiUpit(s => s.Save(u), "Greska prilikom dodavanja ucenika");
        }

        public static List<Ucenik> vratiUcenike() {
            return izvrsiUpit(s => s.Query<Ucenik>()
                             .ToList(), "Greska pri preuzimanju ucenika iz baze") ?? new List<Ucenik>();
        }

        public static Ucenik? vratiUcenika(int id) {
            return izvrsiUpit(s => s.Query<Ucenik>().Where(x => x.Id == id).FirstOrDefault(), "Greska prilikom pribavljanja ucenika iz baze");
        }
        public static void izmeniUcenika(int id, Ucenik u) {
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

        public static void obrisiUcenika(Ucenik u) {
            izvrsiUpit(s => s.Delete(u), "Greska prilikom brisanja ucenika iz baze podataka");
        }

        public static void dodeliPredmetUceniku(int uId, int pId) {
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
                if (p is null) {
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
        public static void kreirajOdeljenje(Odeljenje o) {
            izvrsiUpit(s => {
                if (s.Query<Odeljenje>().Any(x => x.Oznaka == o.Oznaka && x.Razred == o.Razred && x.SkolskaGodina == o.SkolskaGodina)) {
                    throw new Exception("Odeljenje vec postoji u bazi podataka");
                }

                s.Save(o);
            }, "Greska prilikom kreiranja novog odeljenja");
        }

        public static Odeljenje vratiOdeljenje(int id) {
            return izvrsiUpit(s => {
                Odeljenje o = s.Get<Odeljenje>(id);
                if (o is null) throw new Exception("Odeljenje ne postoji u bazi podataka");
                return o;
            }, "Greska prilikom dobavljanja odeljenja iz baze podataka");
        }

        public static List<Odeljenje> vratiOdeljenja(String? oznaka = null, String? skolskaGodina = null, int razred = 0) {
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

        public static void dodajUcenikaUOdeljenje(int oId, int uId) {
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

        public static List<Nastavnik> vratiNastavnike()
        {
            return izvrsiUpit(s => s.Query<Nastavnik>().ToList(), "Greska pri preuzimanju nastavnika iz baze")
                ?? new List<Nastavnik>();
        }
        

        public static void dodajNastavnika(Nastavnik nastavnik) {
            izvrsiUpit(n => n.Save(nastavnik), "Greska pri dodavanju novog nastavnika");
        }

        public static void obrisiNastavnika(Nastavnik nastavnik) {
          izvrsiUpit(n => n.Delete(nastavnik), "Greska pri brisanju nastavnika iz baze");
        }


        public static RazredniStaresina? vratiRazrednogStaresinu(int odeljenjeId) {
            return izvrsiUpit<RazredniStaresina?>(s =>
            {
                return s.Query<RazredniStaresina>().Where(x => x.Odeljenje.Id == odeljenjeId).FirstOrDefault();
            }, "Greska prilikom pribavljanja razrednog staresine za odeljenje");
        }
        #endregion

        #region Predmet
        public static List<Predmet> vratiPredmete(string skolskaGodina = null) {
            return izvrsiUpit<List<Predmet>>(s => { 
                List<Predmet> predmeti = s.Query<Predmet>().ToList();
                if (!String.IsNullOrWhiteSpace(skolskaGodina)) {
                    predmeti = predmeti.Where(x => x.SkolskaGodina == skolskaGodina).ToList();
                }
                return predmeti;
            } , "Greska prilikom pribavljanja podataka iz baze") ?? new List<Predmet>();
        }

        public static Predmet vratiPredmet(int id) {
            return izvrsiUpit<Predmet>(s => s.Get<Predmet>(id), "Greska prilikom pribavljanja iz baze podataka");
        }
        public static void dodajPredmet(Predmet p) {
            izvrsiUpit(s => s.Save(p), "Greska prilikom dodavanja predmeta u bazu podataka");
        }

        public static void obrisiPredmet(Predmet p) {
            izvrsiUpit(s => s.Delete(p), "Greska prilikom brisanja predmeta iz baze podataka");
        }

        public static void izmeniPredmet(int id, Predmet predmet) {
            izvrsiUpit(s =>
            {
                if (predmet is null) {
                    throw new Exception("Greska prilikom izmene predmeta");
                }
                Predmet p = s.Get<Predmet>(id);
                if (p is null) throw new Exception("Predmet sa unetim Idjem ne postoji u bazi podataka");


            }, "Greska prilikom izmene predmeta iz baze podataka");
        }

        public static List<Ucenik> vratiUcenikeKojiSlusajuPredmet(int idPredmeta) {
            return izvrsiUpit<List<Ucenik>>(s => s.Query<Ucenik>().Where(x => x.Predmeti.Any(x => x.Id == idPredmeta)).ToList(),
                "Nijedan ucenik ne slusa dati predmet");
        }

        public static List<Ocena> vratiOceneUcenikaNaPredmetu(int ucenikId, int predmetId) {
            return izvrsiUpit<List<Ocena>>(s =>
                s.Query<Ocena>()
                .Where(x=>x.Ucenik.Id == ucenikId && x.Nastava.predajePredmet.Nastavnik.Id == predmetId)
                .ToList(), "Greska prilikom pribavljanja podataka iz baze") ?? new List<Ocena>();
        }

        public static List<Ocena> vratiOcenePoTipu(TipOcene tip)
        {
            return izvrsiUpit<List<Ocena>>(s => {
                 return s.Query<Ocena>().Where(x=>x.Tip == tip).ToList();
            }, "Greska prilikom dobavljanja ocena iz baze") ?? new List<Ocena>();
        }
        #endregion
    }
}

