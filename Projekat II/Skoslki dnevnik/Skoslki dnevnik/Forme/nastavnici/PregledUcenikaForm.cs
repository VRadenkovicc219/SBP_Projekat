namespace Skoslki_dnevnik.Forme
{
    public partial class PregledUcenikaForm : Form
    {
        List<PredmetiDTO> predmeti = new List<PredmetiDTO>();
        List<UcenikDTO> ucenici = new List<UcenikDTO>();
        NastavnikDTO nastavnik = null!;
        public PregledUcenikaForm()
        {
            InitializeComponent();
        }

        public PregledUcenikaForm(NastavnikDTO n)
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
            predmeti = DTOManager.vratiPredmeteNastavnika(nastavnik!.id);
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
            uceniciDgv.Columns["Id"].Visible = false;
        }

        private void oceneBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Greska");
                return;
            }

            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            int idNastavnik = nastavnik.id;
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            List<Ocena> ocene = DTOManager.vratiOceneUcenikaNaPredmetu(idUcenik, idNastavnik).OrderBy(x => x.DatumOcenjivanja).ThenBy(x => x.Tip).ToList();
            PregledOcena pf = new PregledOcena(ocene, idUcenik, idNastavnik, idPredmet);
            pf.Show();
        }


        private void izbaciUcenikaBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Greska");
                return;
            }
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            try {
                DTOManager.izbaciUcenikaSaPredmeta(idUcenik, idPredmet);
                int id = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
                ucenici = DTOManager.vratiUcenikeKojiSlusajuPredmet(id);
                uceniciDgv.DataSource = ucenici;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void izostanciBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Greska");
                return;
            }

            int idPredmet = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            int idNastavnik = nastavnik.id;
            int idUcenik = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            List<IzostanakDTO> ocene = DTOManager.vratiIzostankeUcenikaNaPredmetu(idUcenik, idNastavnik);
            PregledIzostanaka pf = new PregledIzostanaka(ocene, idUcenik, idNastavnik, idPredmet);
            pf.Show();
        }
    }
}
