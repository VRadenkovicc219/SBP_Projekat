using NHibernate.Linq;
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

        public static List<UcenikDTO> vratiUcenike() {
            return izvrsiUpit(s => s.Query<Ucenik>()
                             .ToList()
                             .Select(x=> new UcenikDTO(x.Id, 
                                                       x.Ime, 
                                                       x.Prezime, 
                                                       x.JMBG,  
                                                       x.Adresa, 
                                                       x.Status.ToString()
                                                       )
                             )
                             .ToList(), "Greska pri preuzimanju ucenika iz baze") ?? new List<UcenikDTO>();
        }
        #endregion
        #region Nastavnik

        public static List<Nastavnik> vratiNastavnike()
        {
            return izvrsiUpit(s => s.Query<Nastavnik>().ToList(), "Greska pri preuzimanju nastavnika iz baze")
                ?? new List<Nastavnik>();
        }
        #endregion

        public static void dodajNastavnika(Nastavnik nastavnik) {
            izvrsiUpit(n => n.Save(nastavnik), "Greska pri dodavanju novog nastavnika");
        }

        public static void obrisiNastavnika(Nastavnik nastavnik) {
            izvrsiUpit(n => n.Delete(nastavnik), "Greska pri brisanju nastavnika iz baze");
        }

        //public static void azurirajPodatke(Nastavnik n, Nastavnik )
    }
}

