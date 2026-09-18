using Skoslki_dnevnik.Entiteti.KompozitniKljucevi;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Skoslki_dnevnik
{
    public class DTOManager
    {
        
        public void izvrsiUpit(Action<ISession> upit, string porukaGreske) {
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

        #region Osoba
        public void dodajOsobu(Osoba o)
        {
            izvrsiUpit(s => s.Save(o), "Greska prilikom dodavanja osobe");
        }
        #endregion

        #region Ucenik
        public void dodajUcenika(Ucenik u) {
            izvrsiUpit(s => s.Save(u), "Greska prilikom dodavanja ucenika");
        }

        public void ObrisiUcenika()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
            }
        }
        #endregion
    }
}
