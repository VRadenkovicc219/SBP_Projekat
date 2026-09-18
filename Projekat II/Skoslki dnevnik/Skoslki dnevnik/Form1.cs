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
    }
}
