using NHibernate.Hql;
using Skoslki_dnevnik.Forme;

namespace Skoslki_dnevnik
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            UcenikPocetna novaForma = new UcenikPocetna();
            novaForma.Show();
        }

        private void nastavniciBtn_Click(object sender, EventArgs e)
        {
            NastavnikPocetna nf = new NastavnikPocetna();
            nf.Show();
        }

        private void uceniciBtn_Click(object sender, EventArgs e)
        {
            UcenikPocetna nf = new UcenikPocetna();
            nf.Show();
        }

        private void predmetiBtn_Click(object sender, EventArgs e)
        {
            PredmetiForma nf = new PredmetiForma();
            nf.Show();
        }
    }
}
