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
            if (neopravdaniCB.Checked) izabraniTipovi.Add(TipIzostanka.OPRAVDAN);

            var rezultat = sviIzostanci.Where(x =>
                x.Id.Datum.Date >= datumOdDtp.Value.Date &&
                x.Id.Datum.Date <= datumDoDtp.Value.Date);

            rezultat = izabraniTipovi.Count > 0
                ? rezultat.Where(x => izabraniTipovi.Contains(x.TipIzostanka))
                : Enumerable.Empty<Izostanak>();

            oceneDgv.DataSource = rezultat.ToList();
        }
    }
}
