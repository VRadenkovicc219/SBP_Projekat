using NHibernate.Hql.Ast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PredmetiForma : Form
    {
        List<Predmet> predmeti = new List<Predmet>();
        public PredmetiForma()
        {
            InitializeComponent();
        }

        private void PredmetiForma_Load(object sender, EventArgs e)
        {
            ucitajPredmete();
            predmeti_dgv.DataSource = predmeti;
        }

        private void ucitajPredmete()
        {
            predmeti.Clear();
            predmeti = DTOManager.vratiPredmete();
        }

        private void dodajPredmetBtn_Click(object sender, EventArgs e)
        {
            DodajPredmetForm df = new DodajPredmetForm();
            if(df.ShowDialog() == DialogResult.OK){
                MessageBox.Show("Uspesno dodavanje predmeta");
            }
            else { 
                MessageBox.Show("Neuspesno dodavanje predmeta");
            }

        }
    }
}
