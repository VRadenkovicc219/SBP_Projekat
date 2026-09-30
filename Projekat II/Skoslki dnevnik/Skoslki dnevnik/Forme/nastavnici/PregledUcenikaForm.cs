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
            uceniciDgv.DataSource = ucenici;
        }

        private void oceneBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Greska");
            }

            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            int idNastavnik = nastavnik.Id;
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            List<Ocena> ocene = DTOManager.vratiOceneUcenikaNaPredmetu(idUcenik, idNastavnik).OrderBy(x => x.DatumOcenjivanja).ThenBy(x => x.Tip).ToList();
            PregledOcena pf = new PregledOcena(ocene, idUcenik, idNastavnik, idPredmet);
            pf.Show();
        }

        private void dodeliOcenuBtn_Click(object sender, EventArgs e)
        {
            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            int idNastavnik = nastavnik.Id;
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;

        }

        private void izbaciUcenikaBtn_Click(object sender, EventArgs e)
        {
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            DTOManager.izbaciUcenikaSaPredmeta(idUcenik, idPredmet);
        }

        private void izostanciBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Greska");
            }

            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            int idNastavnik = nastavnik.Id;
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            List<Izostanak> ocene = DTOManager.vratiIzostankeUcenikaNaPredmetu(idUcenik, idNastavnik);
            PregledIzostanaka pf = new PregledIzostanaka(ocene, idUcenik, idNastavnik, idPredmet);
            pf.Show();
        }
    }
}
