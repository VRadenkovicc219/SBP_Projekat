using NHibernate.Engine.Query;
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
            obrisiUcenikaBtn.Enabled = false;
            izmeniUcenikaBtn.Enabled = false;
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
                UcenikPodaci df = new UcenikPodaci(ucenik);
                df.Show();
            }
        }

        private void obrisiUcenikaBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) { return; }
            Ucenik ucenik = (Ucenik)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete ucenika {ucenik.Ime}", "Potvrda brisanja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DTOManager.obrisiUcenika(ucenik);
                ucitajUcenike();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            bool selektovan = dataGridView1.SelectedRows.Count > 0;
            izmeniUcenikaBtn.Enabled = selektovan;
            obrisiUcenikaBtn.Enabled = selektovan;
        }

        private void izmeniUcenikaBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) { return; }
            Ucenik ucenik = (Ucenik)dataGridView1.SelectedRows[0].DataBoundItem;
            DodajUcenikaForma df = new DodajUcenikaForma(ucenik);
            if (df.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Uspesno ste izmenili podatke o uceniku");
                ucitajUcenike();
            }
        }
    }
}
