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
        private List<Ucenik> ucenici = [];

        public UcenikPocetna()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UcenikPocetna_Load(object sender, EventArgs e)
        {
            ucitajUcenike();

        }

        private void dodajUcenikaBtn_Click(object sender, EventArgs e)
        {
            DodajUcenikaForma df = new DodajUcenikaForma();
            if (df.ShowDialog() == DialogResult.OK)
            {
                ucitajUcenike();
            }
        }

        private void ucitajUcenike()
        {
            ucenici.Clear();
            ucenici = DTOManager.vratiUcenike();
            dataGridView1.DataSource = ucenici;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow red = dataGridView1.Rows[e.RowIndex];
                Ucenik ucenik = (Ucenik)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                DodajUcenikaForma df = new DodajUcenikaForma(ucenik);
                if (df.ShowDialog() == DialogResult.OK) {
                    ucitajUcenike();
                }
            }
        }
    }
}
