using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.nastavnici
{
    public partial class DodajRukovodeciOrganForm : Form
    {
        int idNastavnik = 0;
        public DodajRukovodeciOrganForm()
        {
            InitializeComponent();
        }

        public DodajRukovodeciOrganForm(int id)
        {
            InitializeComponent();
            idNastavnik = id;
        }

        private void DodajRukovodeciOrganForm_Load(object sender, EventArgs e)
        {
            pozicijaCmb.DataSource = Enum.GetValues<RukovodecaPozicija>();
            oblastOdgovornostiCmb.DataSource = Enum.GetValues<OblastOdgovornosti>();
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            RukovodecaPozicija pozicija = (RukovodecaPozicija)pozicijaCmb.SelectedItem!;
            OblastOdgovornosti oblastOdgovornosti = (OblastOdgovornosti)oblastOdgovornostiCmb.SelectedItem!;
            DateTime datumPreuzimanjaFje = datumPreuzimanjaFjeDtp.Value;
            int staz = (int)godineStazaNM.Value;
            DTOManager.dodajRukovodeciOrgan(idNastavnik, pozicija, oblastOdgovornosti, datumPreuzimanjaFje, staz);
        }
    }
}
