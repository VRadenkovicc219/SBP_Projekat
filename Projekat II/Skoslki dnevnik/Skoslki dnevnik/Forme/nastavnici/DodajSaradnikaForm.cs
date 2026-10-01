using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.nastavnici
{
    public partial class DodajSaradnikaForm : Form
    {
        int idNastavnik = -1;
        public DodajSaradnikaForm()
        {
            InitializeComponent();
        }

        public DodajSaradnikaForm(int id)
        {
            InitializeComponent();
            this.idNastavnik = id;
        }



        private void DodajSaradnikaForm_Load(object sender, EventArgs e)
        {
            sspremaCmb.DataSource = Enum.GetValues<StrucnaOblast>();
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(licencaTxt.Text)) {
                MessageBox.Show("Mora se uneti licenca");
                return;
            }

            int brojSprovedenihRazgovora = (int)brojRazgovoraNM.Value;
            int brojRadionica = (int)brojRadionicaNM.Value;
            StrucnaOblast s = (StrucnaOblast)sspremaCmb.SelectedItem!;
            try {
                DTOManager.dodajStrucnogSaradnika(idNastavnik, licencaTxt.Text, s, brojSprovedenihRazgovora, brojRadionica);
                MessageBox.Show("Uspesno ste dodali strucnog radnika");
                this.Close();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
    }
}
