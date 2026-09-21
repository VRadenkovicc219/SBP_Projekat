using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class UcenikPocetna : Form
    {
        private List<UcenikDTO> ucenici = [];

        public UcenikPocetna()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UcenikPocetna_Load(object sender, EventArgs e)
        {
            ucenici = DTOManager.vratiUcenike();
            MessageBox.Show($"Broj ucenika: {ucenici.Count}");
            dataGridView1.DataSource = ucenici;
            
        }

        private void dodajUcenikaBtn_Click(object sender, EventArgs e)
        {
            DodajUcenikaForma df = new DodajUcenikaForma();
            df.Show();
        }
    }
}
