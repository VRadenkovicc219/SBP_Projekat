using Antlr.Runtime.Tree;
using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PregledOcena : Form
    {
        private readonly List<Ocena> sveOcene = new List<Ocena>();
        int idNastavnik = -1;
        int idPredmet = -1;
        int idUcenik = -1;
        public PregledOcena(List<Ocena> ocene, int idUcenik, int idNastavnik, int idPredmet)
        {
            InitializeComponent();
            this.sveOcene = ocene;
            this.idUcenik = idUcenik;
            this.idNastavnik = idNastavnik;
            this.idPredmet = idPredmet;
        }

        private void PregledOcena_Load(object sender, EventArgs e)
        {
            if (sveOcene.Count > 0)
            {
                datumOdDtp.Value = sveOcene.Min(x => x.DatumOcenjivanja);
                datumDoDtp.Value = sveOcene.Max(x => x.DatumOcenjivanja);
            }
            PrimeniFiltere();
        }

        private void datumOdDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void datumDoDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();

        private void PrimeniFiltere()
        {
            var izabraniTipovi = new List<TipOcene>();
            if (aktivnostCB.Checked) izabraniTipovi.Add(TipOcene.AKTIVNOST);
            if (pisanaCB.Checked) izabraniTipovi.Add(TipOcene.PISANA_PROVERA);
            if (usmeniCB.Checked) izabraniTipovi.Add(TipOcene.USMENI_ODGOVOR);
            if (zakljucnaCB.Checked) izabraniTipovi.Add(TipOcene.ZAKLJUCNA);




            var rezultat = sveOcene.Where(x =>
                x.DatumOcenjivanja.Date >= datumOdDtp.Value.Date &&
                x.DatumOcenjivanja.Date <= datumDoDtp.Value.Date);

            rezultat = izabraniTipovi.Count > 0
                ? rezultat.Where(x => izabraniTipovi.Contains(x.Tip))
                : Enumerable.Empty<Ocena>();

            if (prvoCB.Checked ^ drugoCB.Checked)
            {
                int p = prvoCB.Checked ? 1 : 2;
                rezultat = rezultat.Where(x => x.Polugodje == p);
            }

            oceneDgv.DataSource = rezultat.ToList();
        }


        private void aktivnostCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void zakljucnaCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void pisanaCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void usmeniCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void prvoCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void drugoCB_CheckedChanged(object sender, EventArgs e)
        {
            PrimeniFiltere();
        }

        private void dodajOcenuBtn_Click(object sender, EventArgs e)
        {
            DodajOcenuForm df = new DodajOcenuForm(idUcenik, idPredmet, idNastavnik);
            df.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Ocena ocena in oceneDgv.SelectedRows)
            {
                DTOManager.obrisiOcenu(ocena);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ocena o = (Ocena)oceneDgv.SelectedRows[0].DataBoundItem;
            DodajOcenuForm df = new DodajOcenuForm(o);
            df.Show();
        }
    }
}
