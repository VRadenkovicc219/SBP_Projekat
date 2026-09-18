using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajUcenikaForma : Form
    {
        public DodajUcenikaForma()
        {
            InitializeComponent();
        }

        public bool ValidanJmbg(string jmbg)
        {

            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
                return false;

            //int[] c = jmbg.Select(ch => ch - '0').ToArray();

            //int suma = 7 * c[0] + 6 * c[1] + 5 * c[2] + 4 * c[3] + 3 * c[4] + 2 * c[5] +
            //           7 * c[6] + 6 * c[7] + 5 * c[8] + 4 * c[9] + 3 * c[10] + 2 * c[11];

            //int ostatak = suma % 11;
            //int kontrolnaCifra = 11 - ostatak;

            //if (kontrolnaCifra == 11)
            //    kontrolnaCifra = 0;

            //if (kontrolnaCifra == 10)
            //    return false;

            //return kontrolnaCifra == c[12];
            return true;
        }

        private bool validirajPodatke()
        {
            if (String.IsNullOrWhiteSpace(imeTb.Text) ||
               String.IsNullOrWhiteSpace(prezimeTb.Text) ||
               String.IsNullOrWhiteSpace(jmbgTb.Text) ||
               String.IsNullOrWhiteSpace(emailTb.Text) ||
               String.IsNullOrWhiteSpace(adresaTb.Text) ||
               (polMCk.Checked ^ !polZCk.Checked))
            {
                MessageBox.Show("Morate popuniti sva polja");
                return false;
            }
            if (!ValidanJmbg(jmbgTb.Text))
            {
                MessageBox.Show("Unet je neispravan jmbg");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validirajPodatke())
            {
                string godina = jmbgTb.Text.Substring(4, 3);
                char charToInsert = godina.StartsWith("0") ? '2' : '1';
                godina = charToInsert + godina;
                string mesec = jmbgTb.Text.Substring(2, 2);
                string dan = jmbgTb.Text.Substring(0, 2);
                Ucenik u = new Ucenik
                {
                    Ime = imeTb.Text,
                    Prezime = prezimeTb.Text,
                    JMBG = jmbgTb.Text,
                    Adresa = adresaTb.Text,
                    DatumRodjenja = new DateTime(int.Parse(godina), int.Parse(mesec), int.Parse(dan)),
                    Komentar = komentarTb.Text,
                    Email = emailTb.Text,
                    Pol = polMCk.Checked ? 'M' : 'Z',
                    GodinaUpisa = "2023/2024",
                    Status = StatusUcenika.AKTIVAN
                };
                DTOManager.dodajUcenika(u);
            }

        }

        private void datumRodjenjaDtp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
