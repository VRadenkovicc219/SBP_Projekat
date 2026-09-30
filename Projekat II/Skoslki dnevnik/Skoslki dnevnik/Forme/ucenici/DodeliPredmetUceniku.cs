using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodeliPredmetUceniku : Form
    {

        Ucenik u = null;
        bool readOnly = false;
        public DodeliPredmetUceniku()
        {
            InitializeComponent();
        }

        public DodeliPredmetUceniku(Ucenik u, bool readOnly)
        {
            InitializeComponent();
            this.u = u;
            this.readOnly = readOnly;
        }

        private void DodeliPredmetUceniku_Load(object sender, EventArgs e)
        {
            predmetiDGV.DataSource = (readOnly) ? DTOManager.vratiPredmeteUcenika(u.Id) : DTOManager.vratiPredmeteKojeUcenikNeSlusa(u);
            button1.Visible = !readOnly;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PredmetiDTO p = (PredmetiDTO)predmetiDGV.SelectedRows[0].DataBoundItem!;
            DTOManager.dodeliPredmetUceniku(u.Id, p.id);
            predmetiDGV.DataSource = DTOManager.vratiPredmeteKojeUcenikNeSlusa(u);
        }
    }
}
