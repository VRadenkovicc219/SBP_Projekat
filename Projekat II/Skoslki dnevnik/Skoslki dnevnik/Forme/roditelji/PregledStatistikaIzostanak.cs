using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class PregledStatistikaIzostanak : Form
    {
        private const string SVE_GODINE = "Sve skolske godine";
        private List<IzostanakStatistikaDTO> sviIzostanci = new List<IzostanakStatistikaDTO>();
        private UcenikDTO u = null;

        public PregledStatistikaIzostanak()
        {
            InitializeComponent();
        }

        public PregledStatistikaIzostanak(UcenikDTO u)
        {
            InitializeComponent();
            this.u = u;
        }

        private void PregledStatistikaIzostanak_Load_1(object sender, EventArgs e)
        {
            var godine = new List<string> { SVE_GODINE };
            godine.AddRange(DTOManager.vratiSkolskeGodine());

            skoslkaGodinaCmb.DataSource = godine;

            UcitajIzostanke();
        }

        private void UcitajIzostanke()
        {
            string? godina = skoslkaGodinaCmb.SelectedItem as string;

            sviIzostanci = DTOManager.vratiSveIzostankeZaStatistiku(u.id, godina == SVE_GODINE ? null : godina);

            if (sviIzostanci.Count > 0)
            {
                datumOdDtp.Value = sviIzostanci.Min(x => x.datum);
                datumDoDtp.Value = sviIzostanci.Max(x => x.datum);
            }

            PrimeniFiltere();
        }

        private void skolskaGodinaCmb_SelectedIndexChanged(object sender, EventArgs e) => UcitajIzostanke();

        private void datumOdDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void datumDoDtp_ValueChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void opravdaniCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();
        private void neopravdaniCb_CheckedChanged(object sender, EventArgs e) => PrimeniFiltere();

        private void PrimeniFiltere()
        {
            var izabraniTipovi = new List<TipIzostanka>();
            if (opravdaniCB.Checked) izabraniTipovi.Add(TipIzostanka.OPRAVDAN);
            if (neopravdaniCB.Checked) izabraniTipovi.Add(TipIzostanka.NEOPRAVDAN);

            var rezultat = sviIzostanci.Where(x =>
                x.datum.Date >= datumOdDtp.Value.Date &&
                x.datum.Date <= datumDoDtp.Value.Date);

            rezultat = izabraniTipovi.Count > 0
                ? rezultat.Where(x => izabraniTipovi.Contains(x.tip))
                : Enumerable.Empty<IzostanakStatistikaDTO>();

            statistikaDgv.DataSource = rezultat.ToList();
        }

        
    }
}
