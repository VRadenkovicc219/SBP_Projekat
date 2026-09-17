using Skoslki_dnevnik.Entiteti.KompozitniKljucevi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik
{
    public class DTOManager
    {

        #region Osoba
        public void dodajOsobu()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Osoba o = new Osoba
                {
                    Ime = "Vladimir",
                    Prezime = "Radenkovic",
                    JMBG = "1905004740021",
                    DatumRodjenja = new DateTime(2004, 5, 19),
                    Adresa = "Krusevica 389",
                    Pol = 'M',
                    Email = "v.radenkovic219@gmail.com",
                };
                s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Greska prilikom dodavanja osobe u bazu: {ex.Message}");
            }
        }
        #endregion

        #region
        public void dodajUcenika() {
            try
            {
                ISession s = DataLayer.GetSession();
                Ucenik u = new Ucenik
                {
                    Ime = "Vladimir",
                    Prezime = "Radenkovic",
                    JMBG = "1905004740021",
                    DatumRodjenja = new DateTime(2004, 5, 19),
                    Adresa = "Krusevica 389",
                    Pol = 'M',
                    Email = "v.radenkovic219@gmail.com",
                    Status = StatusUcenika.AKTIVAN,
                    GodinaUpisa = "2023/2024"
                };
                s.Save(u);
                s.Flush();
                s.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion
    }
}
