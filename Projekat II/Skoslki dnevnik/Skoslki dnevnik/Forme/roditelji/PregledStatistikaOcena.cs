using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PregledStatistikaOcena : Form
    {
        private List<OcenaStatistikaDTO> sveOcene = new List<OcenaStatistikaDTO>();

        private Ucenik u = null;

        private class PredmetStavka
        {
            public int? Id { get; set; }
            public string Naziv { get; set; } = "";
            public override string ToString() => Naziv;
        }

        public PregledStatistikaOcena()
        {
            InitializeComponent();
        }

        public PregledStatistikaOcena(Ucenik u) {
            InitializeComponent();
            this.u = u;
        }

        private void PregledStatistikaOcena_Load(object sender, EventArgs e)
        {
            var stavke = new List<PredmetStavka> { new PredmetStavka { Id = null, Naziv = "Svi predmeti" } };
            stavke.AddRange(DTOManager.vratiPredmete().Select(p => new PredmetStavka { Id = p.Id, Naziv = p.Naziv }));

            predmetCmb.DataSource = stavke;
            predmetCmb.DisplayMember = nameof(PredmetStavka.Naziv);

            UcitajOcene();
        }

        private void UcitajOcene()
        {
            sveOcene = DTOManager.vratiSveOceneUcenika(u.Id);
        }

        private void datumOdDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void datumDoDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void aktivnostCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void pisanaProveraCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void usmeniOdgovorCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void zakljucnaCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();

        private void PrimeniFiltere()
        {
            var izabraniTipovi = new List<TipOcene>();
            if (aktivnostCB.Checked) izabraniTipovi.Add(TipOcene.AKTIVNOST);
            if (pisanaProveraCb.Checked) izabraniTipovi.Add(TipOcene.PISANA_PROVERA);
            if (usmeniOdgovorCB.Checked) izabraniTipovi.Add(TipOcene.USMENI_ODGOVOR);
            if (zakljucnaCb.Checked) izabraniTipovi.Add(TipOcene.ZAKLJUCNA);

            var rezultat = sveOcene.Where(x =>
                x.datum.Date >= datumOdDtp.Value.Date &&
                x.datum.Date <= datumDoDtp.Value.Date);

            PredmetStavka predmet = (PredmetStavka)predmetCmb.SelectedItem!;
            rezultat = (predmet.Id is null) ? rezultat : rezultat.Where(x => x.predmet == predmet.Naziv).ToList(); 

            rezultat = izabraniTipovi.Count > 0
                ? rezultat.Where(x => izabraniTipovi.Contains(x.tip))
                : Enumerable.Empty<OcenaStatistikaDTO>();

            statistikaDgv.DataSource = rezultat.ToList();
        }
    }
}

