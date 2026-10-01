using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.nastavnici
{
    public partial class DodajRukovodeciOrganForm : Form
    {
        public DodajRukovodeciOrganForm()
        {
            InitializeComponent();
        }

        private void DodajRukovodeciOrganForm_Load(object sender, EventArgs e)
        {
            pozicijaCmb.DataSource = Enum.GetValues<RukovodecaPozicija>();
            oblastOdgovornostiCmb.DataSource = Enum.GetValues<OblastOdgovornosti>();
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
