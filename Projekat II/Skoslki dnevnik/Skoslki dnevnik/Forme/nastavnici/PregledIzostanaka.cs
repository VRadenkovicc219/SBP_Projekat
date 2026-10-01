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
        private List<IzostanakDTO> sviIzostanci = new List<IzostanakDTO>();

        int idNastavnik = -1, idPredmet = -1, idUcenik = -1;


        public PregledIzostanaka()
        {
            InitializeComponent();
        }

        public PregledIzostanaka(List<IzostanakDTO> izostanci, int idUcenik, int idNastavnik, int idPredmet)
        {
            InitializeComponent();

            sviIzostanci = izostanci ?? new List<IzostanakDTO>();

            this.idUcenik = idUcenik;
            this.idNastavnik = idNastavnik;
            this.idPredmet = idPredmet;
        }

        private void PregledIzostanaka_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            sviIzostanci = DTOManager.vratiIzostankeUcenikaNaPredmetu(idUcenik, idPredmet);

            if (sviIzostanci.Count > 0)
            {
                datumOdDtp.Value = sviIzostanci.Min(x => x.datum);
                datumDoDtp.Value = sviIzostanci.Max(x => x.datum);
            }

            PrimeniFiltere();
        }

        private void PrimeniFiltere()
        {
            var izabraniTipovi = new List<TipIzostanka>();

            if (opravdaniCB.Checked)
                izabraniTipovi.Add(TipIzostanka.OPRAVDAN);

            if (neopravdaniCB.Checked)
                izabraniTipovi.Add(TipIzostanka.NEOPRAVDAN);

            var rezultat = sviIzostanci.Where(x =>
                x.datum >= datumOdDtp.Value &&
                x.datum <= datumDoDtp.Value);

            rezultat = izabraniTipovi.Count > 0 ? rezultat.Where(x => izabraniTipovi.Contains(Enum.Parse<TipIzostanka>(x.tip))) : rezultat;

            izostanciDgv.DataSource = null;
            izostanciDgv.DataSource = rezultat.ToList();
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

        private void dodajIzostanakBtn_Click(object sender, EventArgs e)
        {
            DodajIzostanakForm df = new DodajIzostanakForm(idUcenik, idPredmet, idNastavnik);
            df.ShowDialog();
            ucitajPodatke();
        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {
            if (izostanciDgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Morate odabrati tacno jedan red");
                return;
            }

            IzostanakDTO izabrani = (IzostanakDTO)izostanciDgv.SelectedRows[0].DataBoundItem!;

            DodajIzostanakForm df = new DodajIzostanakForm(izabrani, idUcenik);

            df.ShowDialog();

            ucitajPodatke();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            if (izostanciDgv.SelectedRows.Count == 0) {
                MessageBox.Show("Morate odabrati redove za brisanje");
                return;
            }

            foreach (DataGridViewRow red in izostanciDgv.SelectedRows)
            {
                if (red.DataBoundItem is IzostanakDTO izostanak)
                    DTOManager.obrisiIzostanak(izostanak, idUcenik);
            }

            ucitajPodatke();

        }
    }
}