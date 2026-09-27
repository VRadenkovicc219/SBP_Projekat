using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PregledIzostanaka : Form
    {
        private readonly List<Izostanak> sviIzostanci = new List<Izostanak>();
        int idNastavnik = -1, idPredmet = -1, idUcenik = -1;

        public PregledIzostanaka()
        {
            InitializeComponent();
        }

        public PregledIzostanaka(List<Izostanak> izostanci, int idUcenik, int idNastavnik, int idPredmet)
        {
            InitializeComponent();
            sviIzostanci = izostanci ?? new List<Izostanak>();
            this.idUcenik = idUcenik;
            this.idNastavnik = idNastavnik;
            this.idPredmet = idPredmet;
        }

        private void PregledIzostanaka_Load(object sender, EventArgs e)
        {
            if (sviIzostanci.Count > 0)
            {
                datumOdDtp.Value = sviIzostanci.Min(x => x.Id.Datum);
                datumDoDtp.Value = sviIzostanci.Max(x => x.Id.Datum);
            }
            PrimeniFiltere();
        }


        private void PrimeniFiltere()
        {
            var izabraniTipovi = new List<TipIzostanka>();
            if (opravdaniCB.Checked) izabraniTipovi.Add(TipIzostanka.OPRAVDAN);
            if (neopravdaniCB.Checked) izabraniTipovi.Add(TipIzostanka.NEOPRAVDAN);

            var rezultat = sviIzostanci.Where(x =>
                x.Id.Datum.Date >= datumOdDtp.Value.Date &&
                x.Id.Datum.Date <= datumDoDtp.Value.Date);

            rezultat = izabraniTipovi.Count > 0
                ? rezultat.Where(x => izabraniTipovi.Contains(x.TipIzostanka))
                : rezultat;

            izostanciDgv.DataSource = rezultat.ToList();
        }

        private void dodajOcenuBtn_Click(object sender, EventArgs e)
        {
            DodajIzostanakForm df = new DodajIzostanakForm(idUcenik, idPredmet, idNastavnik);
            df.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (izostanciDgv.SelectedRows.Count != 1) return;

            Izostanak izabrani = (Izostanak)izostanciDgv.SelectedRows[0].DataBoundItem!;
            DodajIzostanakForm df = new DodajIzostanakForm(izabrani);
            df.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (izostanciDgv.SelectedRows.Count == 0) return;

            foreach (DataGridViewRow red in izostanciDgv.SelectedRows)
            {
                if (red.DataBoundItem is Izostanak izostanak)
                    DTOManager.obrisiIzostanak(izostanak);
            }
        }

        private void datumOdDtp_ValueChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void datumDoDtp_ValueChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void opravdaniCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void neopravdaniCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }
    }
}
