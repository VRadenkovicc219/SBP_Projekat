namespace Skoslki_dnevnik.Forme
{
    public partial class PredmetiForma : Form
    {
        List<Predmet> predmeti = new List<Predmet>();
        public PredmetiForma()
        {
            InitializeComponent();
        }

        private void PredmetiForma_Load(object sender, EventArgs e)
        {
            ucitajPredmete();
            predmeti_dgv.DataSource = predmeti;
        }

        private void ucitajPredmete()
        {
            predmeti.Clear();
            predmeti = DTOManager.vratiPredmete();
            predmeti_dgv.DataSource = predmeti;
        }

        private void dodajPredmetBtn_Click(object sender, EventArgs e)
        {
            DodajPredmetForm df = new DodajPredmetForm();
            if (df.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Uspesno dodavanje predmeta");
            }
            else
            {
                MessageBox.Show("Neuspesno dodavanje predmeta");
            }

        }

        private void izmeniPredmetBtn_Click(object sender, EventArgs e)
        {
            if (predmeti_dgv.SelectedRows.Count == 1)
            {
                Predmet p = (Predmet)predmeti_dgv.SelectedRows[0].DataBoundItem;
                DodajPredmetForm df = new DodajPredmetForm(p);
                if (df.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Uspesno ste izmenili podatke o predmetu");
                    ucitajPredmete();
                }
            }
        }

        private void predmeti_dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (predmeti_dgv.SelectedRows.Count == 1)
            {
                obrisiPredmetBtn.Enabled = true;
                izmeniPredmetBtn.Enabled = true;
            }
            else
            {
                obrisiPredmetBtn.Enabled = false;
                izmeniPredmetBtn.Enabled = false;
            }
        }

        private void obrisiPredmetBtn_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)predmeti_dgv.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Da li ste sigurni da zelite da obrisete izabrani predmet",
                    "Brisanje predmeta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )
                == DialogResult.Yes) {
                DTOManager.obrisiPredmet(p);
                ucitajPredmete();
            }

        }
    }
}
