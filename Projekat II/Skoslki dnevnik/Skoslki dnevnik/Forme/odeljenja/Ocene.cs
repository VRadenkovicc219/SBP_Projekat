using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.odeljenja
{
    public partial class Ocene : Form
    {

        int ucenikId = 0;
        string skolska_godina;
        public Ocene()
        {
            InitializeComponent();
        }

        public Ocene(int id, string godina)
        {
            InitializeComponent();
            ucenikId = id;
            skolska_godina = godina;
        }

        private void Ocene_Load(object sender, EventArgs e)
        {
            oceneDgv.DataSource = DTOManager.vratiSveOceneUcenika(ucenikId, skolska_godina);
        }
    }
}
