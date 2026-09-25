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

        private void vratiNastavnike() { 
            
        }
    }
}
