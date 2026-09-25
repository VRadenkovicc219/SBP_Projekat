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
            if(uceniciDgv.Rows.Count != 1)
            {
                MessageBox.Show("Greska");
            }

            Ucenik u = (Ucenik)uceniciDgv.SelectedRows[0].DataBoundItem!;
            int id = ((PredmetiDTO)predmetiCB.SelectedItem!).id;
            List<Ocena> ocene = DTOManager.vratiOceneUcenikaNaPredmetu(u.Id, id).OrderBy(x => x.DatumOcenjivanja).ThenBy(x => x.Tip).ToList();
            
        }
    }
}
