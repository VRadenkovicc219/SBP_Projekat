using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajNastavnikaForm : Form
    {
        public DodajNastavnikaForm()
        {
            InitializeComponent();
        }

        private void DodajNastavnikaForm_Load(object sender, EventArgs e)
        {
            statusCb.DataSource = Enum.GetValues(typeof(StatusNastavnika));
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            Nastavnik n = new Nastavnik
            {
                Ime = imeTb.Text,
                Prezime = prezimeTb.Text,
                JMBG = jmbgTb.Text,
                Adresa = adresaTb.Text,
                Pol = polMCk.Checked ? 'M' : 'Z',
                DatumRodjenja = datumRodjenjaDtp.Value,
                DatumZaposlenja = DateOnly.FromDateTime(dZaposljenjaDtp.Value),
                Email = emailTb.Text,
                StrucnaSprema = sSpremaTxt.Text,
                Zvanje = zvanjeTxt.Text,
                Telefon = zvanjeTxt.Text
            };
            DTOManager.dodajNastavnika(n);
        }
    }
}
