using Skoslki_dnevnik.Forme.nastavnici;

namespace Skoslki_dnevnik.Forme
{
    public partial class NastavnikPocetna : Form
    {
        List<NastavnikDTO> nastavnici = new List<NastavnikDTO>();
        public NastavnikPocetna()
        {
            InitializeComponent();
        }

        private void NastavnikPocetna_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            nastavnici = DTOManager.vratiNastavnike();
            nastavnici_dgv.DataSource = nastavnici;
            nastavnici_dgv.Columns["Id"].Visible = false;
        }
        private void dodajNastavnikaBtn_Click(object sender, EventArgs e)
        {
            DodajNastavnikaForm df = new DodajNastavnikaForm();
            if (df.ShowDialog() == DialogResult.OK)
                ucitajPodatke();
        }


        private void dodeliPredmetBtn_Click(object sender, EventArgs e)
        {
            int id = ((NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!).id;
            DodelaPredmetaFrom df = new DodelaPredmetaFrom(id);
            df.Show();
        }

        private void predmetiBtn_Click(object sender, EventArgs e)
        {
            int id = ((NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!).id;
            DodelaPredmetaFrom df = new DodelaPredmetaFrom(id, true);
            df.Show();
        }

        private void dodeliOcenuBtn_Click(object sender, EventArgs e)
        {
            NastavnikDTO nastavnik = (NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!;
            PregledUcenikaForm pf = new PregledUcenikaForm(nastavnik);
            pf.Show();
        }

        private void ulogaBtn_Click(object sender, EventArgs e)
        {
            NastavnikDTO nastavnik = (NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!;
            UlogaNastavnika nf = new UlogaNastavnika(nastavnik.id);
            nf.Show();
        }

        private void obrisiNastavnikaBtn_Click(object sender, EventArgs e)
        {
            NastavnikDTO nastavnik = (NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!;
            DTOManager.obrisiNastavnika(nastavnik.id);
            ucitajPodatke();
        }

        private void izmaniNastavnikaBtn_Click(object sender, EventArgs e)
        {
            NastavnikDTO nastavnik = (NastavnikDTO)nastavnici_dgv.SelectedRows[0].DataBoundItem!;
            DodajNastavnikaForm df = new DodajNastavnikaForm(nastavnik);
            if(df.ShowDialog() == DialogResult.OK)
                ucitajPodatke();
        }
    }
}
