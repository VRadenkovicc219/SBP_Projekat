namespace Skoslki_dnevnik.Forme
{
    public partial class NastavnikPocetna : Form
    {
        List<Nastavnik> nastavnici = new List<Nastavnik>();
        public NastavnikPocetna()
        {
            InitializeComponent();
        }

        private void NastavnikPocetna_Load(object sender, EventArgs e)
        {
            nastavnici = DTOManager.vratiNastavnike();
            nastavnici_dgv.DataSource = nastavnici;
        }

        private void dodajNastavnikaBtn_Click(object sender, EventArgs e)
        {
            DodajNastavnikaForm df = new DodajNastavnikaForm();
            df.Show();
        }


        private void dodeliPredmetBtn_Click(object sender, EventArgs e)
        {
            int id = ((Nastavnik)nastavnici_dgv.SelectedRows[0].DataBoundItem!).Id;
            DodelaPredmetaFrom df = new DodelaPredmetaFrom(id);
            df.Show();
        }

        private void predmetiBtn_Click(object sender, EventArgs e)
        {
            int id = ((Nastavnik)nastavnici_dgv.SelectedRows[0].DataBoundItem!).Id;
            DodelaPredmetaFrom df = new DodelaPredmetaFrom(id, true);
            df.Show();
        }

        private void dodeliOcenuBtn_Click(object sender, EventArgs e)
        {
            Nastavnik nastavnik = (Nastavnik)nastavnici_dgv.SelectedRows[0].DataBoundItem!;
            PregledUcenikaForm pf = new PregledUcenikaForm(nastavnik);
            pf.Show();
        }
    }
}
