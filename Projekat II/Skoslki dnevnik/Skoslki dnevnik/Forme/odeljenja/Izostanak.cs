using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.odeljenja
{
    public partial class Izostanak : Form
    {
        int ucenikId = 0;
        string skolskaGodina;

        List<IzostanakDTO> izostanci = new();
        public Izostanak()
        {
            InitializeComponent();
        }

        public Izostanak(int id, string godina)
        {
            InitializeComponent();
            ucenikId = id;
            skolskaGodina = godina;
        }

        private void ucitajIzostanke() {
            izostanci = DTOManager.vratiIzostankeZaGodinu(ucenikId, skolskaGodina);
            izostanciDgv.DataSource = izostanci;
        }
        private void Izostanak_Load(object sender, EventArgs e)
        {
            ucitajIzostanke();
        }

        private void neopravdaniChk_CheckedChanged(object sender, EventArgs e)
        {
            if (neopravdaniChk.Checked == true)
            {
                izostanciDgv.DataSource = izostanci.Where(x => x.tip == TipIzostanka.NEOPRAVDAN.ToString());
            }
        }

        private void opravdajBtn_Click(object sender, EventArgs e)
        {
            if (izostanciDgv.SelectedRows.Count == 0) {
                MessageBox.Show("Morate izabrati makar 1 red");
                return;
            }
            List<IzostanakDTO> zaOpravdati = new List<IzostanakDTO>();
            foreach (DataGridViewRow red in izostanciDgv.SelectedRows)
            {
                IzostanakDTO i = (IzostanakDTO)red.DataBoundItem!;
                zaOpravdati.Add(i);
            }
            DTOManager.opravdajIzostanke(ucenikId, zaOpravdati);
            ucitajIzostanke();
        }
    }
}
