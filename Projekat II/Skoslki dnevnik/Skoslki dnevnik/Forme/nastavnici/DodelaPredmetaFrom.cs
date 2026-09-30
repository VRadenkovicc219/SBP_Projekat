using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodelaPredmetaFrom : Form
    {
        List<PredmetiDTO> predmeti = new List<PredmetiDTO>();
        int id = -1;
        bool readOnly = false;
        public DodelaPredmetaFrom()
        {
            InitializeComponent();
        }

        public DodelaPredmetaFrom(int id, bool readOnly = false)
        {
            InitializeComponent();
            this.id = id;
            this.readOnly = readOnly;
        }

        private void DodelaPredmetaFrom_Load(object sender, EventArgs e)
        {
            ucitajPredmete();
            if(readOnly == true) dodeliBtn.Visible = false;
        }

        private void ucitajPredmete()
        {
            predmeti.Clear();
            predmeti = (readOnly) ? DTOManager.vratiPredmeteNastavnika(id) : DTOManager.vratiPredmeteZaOdabir(id);
            predmetiOdabirDgv.DataSource = predmeti;
            predmetiOdabirDgv.Columns["ID"]!.Visible = false;
        }

        private void predmetiOdabirDgv_SelectionChanged(object sender, EventArgs e)
        {
            dodeliBtn.Enabled = predmetiOdabirDgv.SelectedRows.Count != 0;
        }

        private void dodeliBtn_Click(object sender, EventArgs e)
        {
            List<PredmetiDTO> predmeti = predmetiOdabirDgv.SelectedRows.Cast<DataGridViewRow>()
                                                                                 .Select(x => (PredmetiDTO)x.DataBoundItem!)
                                                                                 .ToList();
            DTOManager.dodeliPredmetNastavniku(id, predmeti);
            this.Close();
        }
    }
}
