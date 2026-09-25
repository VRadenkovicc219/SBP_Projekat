namespace Skoslki_dnevnik.Forme
{
    public partial class PregledUcenikaForm : Form
    {
        List<PredmetiDTO> predmeti = new List<PredmetiDTO>();
        List<UcenikDTO> ucenici = new List<UcenikDTO>();
        Nastavnik nastavnik = null!;
        public PregledUcenikaForm()
        {
            InitializeComponent();
        }

        public PregledUcenikaForm(Nastavnik n)
        {
            InitializeComponent();
            nastavnik = n;
        }

        private void PregledUcenikaForm_Load(object sender, EventArgs e)
        {
            if (nastavnik == null)
            {
                MessageBox.Show("Greska prilikom otvaranja forme");
                this.Close();
            }
            predmeti = DTOManager.vratiPredmeteNastavnika(nastavnik!.Id);
            predmetiCB.DataSource = predmeti;
        }

        private void predmetiCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void predmetiCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            ucenici = DTOManager.vratiUcenikeKojiSlusajuPredmet(id);
            ucenici.ForEach(u => MessageBox.Show($"{u.id}"));
            uceniciDgv.DataSource = null;
            uceniciDgv.DataSource = ucenici;
        }
    }
}
