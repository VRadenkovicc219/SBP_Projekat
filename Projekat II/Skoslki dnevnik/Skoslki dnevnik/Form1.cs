namespace Skoslki_dnevnik
{
    public partial class login_form : Form
    {
        DTOManager dm = new DTOManager();
        public login_form()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            dm.dodajUcenika();
        }
    }
}
