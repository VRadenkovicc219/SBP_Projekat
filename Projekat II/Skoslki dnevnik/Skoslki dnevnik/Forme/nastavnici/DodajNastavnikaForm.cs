using Antlr.Runtime;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajNastavnikaForm : Form
    {
        Nastavnik n = null;
        private bool jmbgPrepoznat = false;
        public DodajNastavnikaForm()
        {
            InitializeComponent();
        }

        public DodajNastavnikaForm(Nastavnik n)
        {
            InitializeComponent();
            this.n = n;
        }

        private void DodajNastavnikaForm_Load(object sender, EventArgs e)
        {
            statusCb.DataSource = Enum.GetValues(typeof(StatusNastavnika));
            if (n != null)
            {
                imeTb.Text = n.Ime;
                prezimeTb.Text = n.Prezime;
                jmbgTb.Text = n.JMBG;
                adresaTb.Text = n.Adresa;
                datumRodjenjaDtp.Value = n.DatumRodjenja;
                emailTb.Text = n.Email;
                statusCb.SelectedItem = n.Status;
                zvanjeTxt.Text = n.Zvanje;
                sSpremaTxt.Text = n.StrucnaSprema;
                if (n.Pol == 'M') polMCk.Checked = true; else polZCk.Checked = true;
                dZaposljenjaDtp.Value = n.DatumZaposlenja;
                komentarTb.Text = n.Komentar;
            }
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            Nastavnik novi = new Nastavnik
            {
                Ime = imeTb.Text,
                Prezime = prezimeTb.Text,
                JMBG = jmbgTb.Text,
                Adresa = adresaTb.Text,
                DatumRodjenja = datumRodjenjaDtp.Value,
                Email = emailTb.Text,
                Status = (StatusNastavnika)statusCb.SelectedItem,
                Zvanje = zvanjeTxt.Text,
                StrucnaSprema = sSpremaTxt.Text,
                Pol = (polMCk.Checked) ? 'M' : 'Z',
                DatumZaposlenja = dZaposljenjaDtp.Value,
                Komentar = komentarTb.Text,
                Telefon = telefonTb.Text
            };
            if (n is null)
            {
                DTOManager.dodajNastavnika(novi);
            }
            else
            {
                DTOManager.izmeniNastavnika(n.Id, novi);
            }
            this.Close();
        }

        private void jmbgTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void telefonTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void polMCk_CheckedChanged(object sender, EventArgs e)
        {
            if (polMCk.Checked) polZCk.Checked = false;
        }

        private void polZCk_CheckedChanged(object sender, EventArgs e)
        {
            if (polZCk.Checked) polMCk.Checked = false;
        }



        private void ZakljucajLicnaPolja()
        {
            jmbgPrepoznat = true;
            imeTb.Enabled = false;
            prezimeTb.Enabled = false;
            adresaTb.Enabled = false;
            emailTb.Enabled = false;
            telefonTb.Enabled = false;
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
            telefonTb.Enabled = true;
            datumRodjenjaDtp.Enabled = true;
            polMCk.Enabled = true;
            polZCk.Enabled = true;
        }


        private void jmbgTb_Leave(object sender, EventArgs e)
        {
            if (n is not null) return;
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
                MessageBox.Show("Osoba sa ovim JMBG-om je ucenik i ne moze biti nastavnik.",
                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                jmbgTb.Clear();
                OtkljucajLicnaPolja();
                return;
            }

            if (postojeca is Nastavnik)
            {
                MessageBox.Show("Nastavnik sa ovim JMBG-om vec postoji u bazi.",
                    "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                jmbgTb.Clear();
                OtkljucajLicnaPolja();
                return;
            }

            var odgovor = MessageBox.Show(
                "Osoba sa ovim JMBG-om vec postoji u bazi (kao roditelj/staratelj). Zelite li da automatski popunite licne podatke?",
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
            telefonTb.Text = postojeca.Telefon;
            datumRodjenjaDtp.Value = postojeca.DatumRodjenja;
            komentarTb.Text = postojeca.Komentar;
            if (postojeca.Pol == 'M') { polMCk.Checked = true; polZCk.Checked = false; }
            else { polZCk.Checked = true; polMCk.Checked = false; }

            ZakljucajLicnaPolja();
        }
    }
}
