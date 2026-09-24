using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajPredmetForm : Form
    {
        public DodajPredmetForm()
        {
            InitializeComponent();
        }

        private void DodajPredmetForm_Load(object sender, EventArgs e)
        {
            tipCb.DataSource = Enum.GetValues(typeof(TipPredmeta));
        }
    }
}
