using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.nastavnici
{
    public partial class UlogaNastavnika : Form
    {
        private int idNastavnik = -1;

        public UlogaNastavnika()
        {
            InitializeComponent();
        }

        public UlogaNastavnika(int nastavnikID)
        {
            InitializeComponent();
            idNastavnik = nastavnikID;
        }

        private void razredniBtn_Click(object sender, EventArgs e)
        {
            DodelaRazrednogOdeljenju nf = new DodelaRazrednogOdeljenju(idNastavnik);
            nf.Show();
        }

        private void dodajSSaradnika_Click(object sender, EventArgs e)
        {
            DodajSaradnikaForm nf = new DodajSaradnikaForm(idNastavnik);
            nf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
