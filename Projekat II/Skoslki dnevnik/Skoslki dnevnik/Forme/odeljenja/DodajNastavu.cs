using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajNastavu : Form
    {
        int odeljenjeID = -1;
        public DodajNastavu()
        {
            InitializeComponent();
        }

        public DodajNastavu(int odeljenjeId)
        {
            InitializeComponent();
            this.odeljenjeID = odeljenjeId;
        }

        private void DodajNastavu_Load(object sender, EventArgs e)
        {
            nastavaDgv.DataSource = DTOManager.vratiNastavuZaDodavanjeOdeljenju(odeljenjeID);
            nastavaDgv.Columns["id"]!.Visible = false;
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (nastavaDgv.SelectedRows.Count == 0) {
                MessageBox.Show("Morate izabrati jedan ili vise predmeta");
                return;
            }

            List<NastavaDTO> nastave = new List<NastavaDTO>();
            foreach (DataGridViewRow row in nastavaDgv.SelectedRows) { 
                NastavaDTO n = (NastavaDTO)row.DataBoundItem!;
                nastave.Add(n);
            }
            try
            {
                DTOManager.dodeliNastavuOdeljenju(odeljenjeID, nastave);
                MessageBox.Show("Uspesna dodela");
                nastavaDgv.DataSource = DTOManager.vratiNastavuZaDodavanjeOdeljenju(odeljenjeID);
                nastavaDgv.Columns["id"]!.Visible = false;
            }
            catch (Exception ex) {
                MessageBox.Show($"Greska prilikom dodele: {ex.Message}");
            }
        }
    }
}
