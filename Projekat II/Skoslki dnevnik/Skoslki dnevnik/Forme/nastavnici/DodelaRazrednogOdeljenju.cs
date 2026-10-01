using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.nastavnici
{
    public partial class DodelaRazrednogOdeljenju : Form
    {
        int nastavnikId = -1;
        public DodelaRazrednogOdeljenju()
        {
            InitializeComponent();
        }

        public DodelaRazrednogOdeljenju(int idNastavnik)
        {
            InitializeComponent();
            nastavnikId = idNastavnik;
        }

        private void DodelaRazrednogOdeljenju_Load(object sender, EventArgs e)
        {
            odeljenjaDgv.DataSource = DTOManager.vratiOdlejenjaBezRazrednog();
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1) {
                MessageBox.Show("Morate odabrati tacno jedan red");
                return;
            }
            int odeljenje = (odeljenjaDgv.SelectedRows[0].DataBoundItem as OdeljenjeDTO).id;
            DTOManager.dodeliRazrednogStaresinu(nastavnikId, odeljenje, DateTime.Now, null);
        }
    }
}
