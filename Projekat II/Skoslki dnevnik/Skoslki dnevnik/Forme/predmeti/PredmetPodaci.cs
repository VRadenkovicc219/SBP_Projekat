using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PredmetPodaci : Form
    {
        Predmet p = null;
        public PredmetPodaci()
        {
            InitializeComponent();
        }

        public PredmetPodaci(Predmet p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void PredmetPodaci_Load(object sender, EventArgs e)
        {
            NazivLbl.Text = p.Naziv;
            godinaLbl.Text = p.SkolskaGodina;
            razredLbl.Text = p.Razred.ToString();
            tipLbl.Text = p.Tip.ToString();
            fondLbl.Text = p.NedeljniFond.ToString();
            opisLbl.Text = p.Opis;
            komentarLbl.Text = p.Komentar;
        }
    }
}
