using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PregledIzostanakaKaoUcenik : Form
    {
        Ucenik u = null;
        public PregledIzostanakaKaoUcenik()
        {
            InitializeComponent();
        }

        public PregledIzostanakaKaoUcenik(Ucenik u)
        {
            InitializeComponent();
            this.u = u;
        }

        private void PregledIzostanakaKaoUcenik_Load(object sender, EventArgs e)
        {
            izostanciDgv.DataSource = DTOManager.vratiSveIzostankeUcenika(u.Id);
        }
    }
}
