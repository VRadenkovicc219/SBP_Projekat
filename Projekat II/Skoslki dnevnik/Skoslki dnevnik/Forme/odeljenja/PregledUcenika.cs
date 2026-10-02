using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.odeljenja
{
    public partial class PregledUcenika : Form
    {
        int odeljenjeID = 0;
        string godina;
        public PregledUcenika()
        {
            InitializeComponent();
        }

        public PregledUcenika(int id, string godina)
        {
            InitializeComponent();
            odeljenjeID = id;
            this.godina = godina;
        }

        private void PregledUcenika_Load(object sender, EventArgs e)
        {
            uceniciDgv.DataSource = DTOManager.vratiUcenikeOdeljenja(odeljenjeID);
            uceniciDgv.Columns["Id"].Visible = false;
        }

        private void izostanciBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate odabrati jednog ucenika");
                return;
            }
            int id = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            Izostanak nf = new Izostanak(id, godina);
            nf.Show();
        }

        private void oceneBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate odabrati jednog ucenika");
                return;
            }
            int id = ((UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!).id;
            Ocene nf = new Ocene(id, godina);
            nf.Show();
        }
    }
}
