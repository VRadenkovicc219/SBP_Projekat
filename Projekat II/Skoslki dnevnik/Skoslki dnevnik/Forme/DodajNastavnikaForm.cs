using Antlr.Runtime;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajNastavnikaForm : Form
    {
        Nastavnik n = null;
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
            if(polZCk.Checked) polMCk.Checked = false;
        }
    }
}
