namespace Skoslki_dnevnik.Forme
{
    public partial class DodajPredmetForm : Form
    {
        Predmet p = null;
        public DodajPredmetForm()
        {
            InitializeComponent();
        }

        public DodajPredmetForm(Predmet p)
        {
            InitializeComponent();
            this.p = p;
        }


        private void DodajPredmetForm_Load(object sender, EventArgs e)
        {
            tipCb.DataSource = Enum.GetValues(typeof(TipPredmeta));
            if (p != null) {
                nazivTxt.Text = p.Naziv;
                skolskaGodinaTxt.Text = p.SkolskaGodina;
                tipCb.SelectedItem = p.Tip;
                razredTxt.Text = p.Razred.ToString();
                fondTxt.Text = p.NedeljniFond.ToString();
                OpisTxt.Text = p.Opis;
                komentarTxt.Text = p.Komentar;
            }
        }

        private bool validacijaPodataka()
        {
            if (String.IsNullOrWhiteSpace(nazivTxt.Text) ||
                String.IsNullOrWhiteSpace(skolskaGodinaTxt.Text) ||
                String.IsNullOrWhiteSpace(fondTxt.Text) ||
                String.IsNullOrWhiteSpace(razredTxt.Text)
                ) return false;
            if (int.Parse(skolskaGodinaTxt.Text.Substring(0, 4)) + 1 != int.Parse(skolskaGodinaTxt.Text.Substring(5, 4)))
            {
                return false;
            }
            return true;
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            Predmet noviPredmet = new Predmet
            {
                Naziv = nazivTxt.Text,
                SkolskaGodina = skolskaGodinaTxt.Text,
                Razred = int.Parse(razredTxt.Text),
                NedeljniFond = int.Parse(fondTxt.Text),
                Opis = OpisTxt.Text,
                Komentar = komentarTxt.Text,
                Tip = (TipPredmeta)tipCb.SelectedItem
            };
            try
            {

                if (p is null)
                {
                    if (!validacijaPodataka())
                    {
                        MessageBox.Show("Sva polja koja nisu opciona moraju biti popunjena");
                    }
                    DTOManager.dodajPredmet(noviPredmet);
                }
                else
                {
                    DTOManager.izmeniPredmet(p.Id, noviPredmet);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom izvodjenja akcije: {ex.Message}");
            }
            finally
            {
                this.Close();
            }
        }

        private void razredTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fondTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void skolskaGodinaTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (skolskaGodinaTxt.Text.Length == 4 &&
                int.TryParse(skolskaGodinaTxt.Text, out int godina))
            {
                skolskaGodinaTxt.Text += $"/{godina + 1}";
                skolskaGodinaTxt.SelectionStart = skolskaGodinaTxt.Text.Length;
            }
        }

    }
}

