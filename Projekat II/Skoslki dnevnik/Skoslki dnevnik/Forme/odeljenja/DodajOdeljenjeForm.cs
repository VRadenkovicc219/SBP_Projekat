using Skoslki_dnevnik.Forme.odeljenja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajOdeljenjeForm : Form
    {
        List<Odeljenje> odeljenja = new List<Odeljenje>();

        public DodajOdeljenjeForm()
        {
            InitializeComponent();
        }

        private void ucitajOdeljenja()
        {
            odeljenja = DTOManager.vratiOdeljenja();
            odeljenjaDgv.DataSource = odeljenja;
            odeljenjaDgv.Columns["Id"].Visible = false;
            odeljenjaDgv.Columns["Nastava"].Visible = false;
            odeljenjaDgv.Columns["Ucenici"].Visible = false;
        }



        private void kreirajBtn_Click(object sender, EventArgs e)
        {
            KreirajOdeljenjeForm kf = new KreirajOdeljenjeForm();
            if (kf.ShowDialog() == DialogResult.OK)
            {
                ucitajOdeljenja();
            }
        }

        private void DodajOdeljenjeForm_Load(object sender, EventArgs e)
        {
            ucitajOdeljenja();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate selektovati jedno odeljenje");
                return;
            }
            int id = ((Odeljenje)odeljenjaDgv.SelectedRows[0].DataBoundItem!).Id;
            try
            {
                DTOManager.obrisiOdeljenje(id);
                ucitajOdeljenja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void azurirajBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate selektovati jedno odeljenje");
                return;
            }
            Odeljenje o = (Odeljenje)odeljenjaDgv.SelectedRows[0].DataBoundItem!;
            KreirajOdeljenjeForm kf = new KreirajOdeljenjeForm(o);
            if (kf.ShowDialog() == DialogResult.OK)
            {
                ucitajOdeljenja();
            }
        }

        private void dodajUcenikaBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate selektovati jedno odeljenje");
                return;
            }
            Odeljenje o = (Odeljenje)odeljenjaDgv.SelectedRows[0].DataBoundItem!;
            DodajUcenika nf = new DodajUcenika(o.Id);
            nf.Show();
        }

        private void dodajNastavuBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate selektovati jedno odeljenje");
                return;
            }

            Odeljenje o = (Odeljenje)odeljenjaDgv.SelectedRows[0].DataBoundItem!;
            DodajNastavu nf = new DodajNastavu(o.Id);
            nf.Show();
        }

        private void uceniciBtn_Click(object sender, EventArgs e)
        {
            if (odeljenjaDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate selektovati jedno odeljenje");
                return;
            }

            Odeljenje o = (Odeljenje)odeljenjaDgv.SelectedRows[0].DataBoundItem!;
            PregledUcenika nf = new PregledUcenika(o.Id, o.SkolskaGodina);
            nf.Show();
        }
    }
}
