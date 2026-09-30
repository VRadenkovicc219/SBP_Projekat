using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajRoditeljaForm : Form
    {
        RoditeljStaratelj? r = null;
        bool jmbgPrepoznat = false;
        public DodajRoditeljaForm()
        {
            InitializeComponent();
        }

        public DodajRoditeljaForm(RoditeljStaratelj r)
        {
            InitializeComponent();
            this.r = r;
        }

        private void DodajRoditeljaForm_Load(object sender, EventArgs e)
        {
            if (r != null)
            {
                imeTb.Text = r.Ime;
                prezimeTb.Text = r.Prezime;
                jmbgTb.Text = r.JMBG;
                adresaTb.Text = r.Adresa;
                datumRodjenjaDtp.Value = r.DatumRodjenja;
                emailTb.Text = r.Email;
                telefontxt.Text = r.Telefon;
                komentarTb.Text = r.Komentar;
                if (r.Pol == 'M') polMCk.Checked = true; else polZCk.Checked = true;
                zanimanjetxt.Text = r.Zanimanje;
                radnoMestoTxt.Text = r.RadnoMesto;
            }
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            RoditeljStaratelj novi = new RoditeljStaratelj
            {
                Ime = imeTb.Text,
                Prezime = prezimeTb.Text,
                JMBG = jmbgTb.Text,
                Adresa = adresaTb.Text,
                DatumRodjenja = datumRodjenjaDtp.Value,
                Email = emailTb.Text,
                Pol = (polMCk.Checked) ? 'M' : 'Z',
                Telefon = telefontxt.Text,
                Komentar = komentarTb.Text,
                Zanimanje = zanimanjetxt.Text,
                RadnoMesto = radnoMestoTxt.Text
            };

            if (r is null)
            {
                DTOManager.dodajRoditelja(novi);
            }
            else
            {
                DTOManager.izmeniRoditelja(r.Id, novi);
            }
            this.Close();
        }

        private void jmbgTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void telefonTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void polMCk_CheckedChanged(object sender, EventArgs e)
        {
            if (polMCk.Checked) polZCk.Checked = false;
        }

        private void polZCk_CheckedChanged(object sender, EventArgs e)
        {
            if (polZCk.Checked) polMCk.Checked = false;
        }

        private void jmbgTb_Leave(object sender, EventArgs e)
        {
            if (r is not null) return;

            string jmbg = jmbgTb.Text.Trim();
            if (jmbg.Length != 13)
            {
                OtkljucajLicnaPolja();
                return;
            }

            Osoba? postojeca = DTOManager.vratiOsobuPoJmbg(jmbg);

            if (postojeca is null)
            {
                OtkljucajLicnaPolja();
                return;
            }

            if (postojeca is Ucenik)
            {
                MessageBox.Show("Osoba sa ovim JMBG-om je ucenik i ne moze biti roditelj.",
                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                jmbgTb.Clear();
                OtkljucajLicnaPolja();
                return;
            }

            if (postojeca is RoditeljStaratelj)
            {
                MessageBox.Show("Roditelj/staratelj sa ovim JMBG-om vec postoji u bazi.",
                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                jmbgTb.Clear();
                OtkljucajLicnaPolja();
                return;
            }

            var odgovor = MessageBox.Show(
                "Osoba sa ovim JMBG-om vec postoji u bazi (kao nastavnik). Zelite li da automatski popunite licne podatke?",
                "Postojeca osoba", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (odgovor != DialogResult.Yes)
            {
                jmbgTb.Clear();
                OtkljucajLicnaPolja();
                return;
            }

            imeTb.Text = postojeca.Ime;
            prezimeTb.Text = postojeca.Prezime;
            adresaTb.Text = postojeca.Adresa;
            emailTb.Text = postojeca.Email;
            telefontxt.Text = postojeca.Telefon;
            datumRodjenjaDtp.Value = postojeca.DatumRodjenja;
            komentarTb.Text = postojeca.Komentar;
            if (postojeca.Pol == 'M') { polMCk.Checked = true; polZCk.Checked = false; }
            else { polZCk.Checked = true; polMCk.Checked = false; }

            ZakljucajLicnaPolja();
        }

        private void ZakljucajLicnaPolja()
        {
            jmbgPrepoznat = true;
            imeTb.Enabled = false;
            prezimeTb.Enabled = false;
            adresaTb.Enabled = false;
            emailTb.Enabled = false;
            telefontxt.Enabled = false;
            datumRodjenjaDtp.Enabled = false;
            polMCk.Enabled = false;
            polZCk.Enabled = false;
        }

        private void OtkljucajLicnaPolja()
        {
            if (!jmbgPrepoznat) return;
            jmbgPrepoznat = false;
            imeTb.Enabled = true;
            prezimeTb.Enabled = true;
            adresaTb.Enabled = true;
            emailTb.Enabled = true;
            telefontxt.Enabled = true;
            datumRodjenjaDtp.Enabled = true;
            polMCk.Enabled = true;
            polZCk.Enabled = true;
        }
    }
}
