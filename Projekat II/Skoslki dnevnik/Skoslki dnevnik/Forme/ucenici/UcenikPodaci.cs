namespace Skoslki_dnevnik.Forme
{
    public partial class UcenikPodaci : Form
    {

        private Ucenik u;
        public UcenikPodaci()
        {
            InitializeComponent();
        }

        public UcenikPodaci(Ucenik ucenik)
        {
            InitializeComponent();

            if (ucenik is null)
            {
                MessageBox.Show("Greska prilikom prikaza podataka ucenika");
                Close();
                return;
            }

            u = ucenik;
        }
        private void UcenikPodaci_Load(object sender, EventArgs e)
        {
            ImeLbl.Text = u.Ime;
            prezimeLbl.Text = u.Prezime;
            jmbgLbl.Text = u.JMBG;
            adresaLbl.Text = u.Adresa;
            godinaUpisaLbl.Text = u.GodinaUpisa;
            statusLbl.Text = u.Status.ToString();
            komentarLbl.Text = u.Komentar;
            polLbl.Text = (u.Pol == 'M') ? "Muski" : "Zenski";
            emailLbl.Text = u.Email;
            telefonLbl.Text = u.Telefon;
            datumRodjenjaLbl.Text = u.DatumRodjenja.ToShortDateString();
            razredLbl.Text = DTOManager.vratiRazred(u.Id);
        }
    }
}
