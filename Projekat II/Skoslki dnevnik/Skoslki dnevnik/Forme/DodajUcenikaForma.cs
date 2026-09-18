using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajUcenikaForma : Form
    {
        DTOManager dm = new DTOManager();
        public DodajUcenikaForma()
        {
            InitializeComponent();
        }

        public bool ValidanJmbg(string jmbg)
        {
            
            if (string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13 || !jmbg.All(char.IsDigit))
                return false;

            int[] c = jmbg.Select(ch => ch - '0').ToArray();

            int suma = 7 * c[0] + 6 * c[1] + 5 * c[2] + 4 * c[3] + 3 * c[4] + 2 * c[5] +
                       7 * c[6] + 6 * c[7] + 5 * c[8] + 4 * c[9] + 3 * c[10] + 2 * c[11];

            int ostatak = suma % 11;
            int kontrolnaCifra = 11 - ostatak;

            if (kontrolnaCifra == 11)
                kontrolnaCifra = 0;

            if (kontrolnaCifra == 10)
                return false;

            return kontrolnaCifra == c[12];
        }

        private bool validirajPodatke() {
            if
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
