using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajIzostanakForm : Form
    {
        private IzostanakDTO? izostanak = null;

        private int idPredmet = -1;
        private int idNastavnik = -1;
        private int idUcenik = -1;

        private bool sacuvano = false;

        public DodajIzostanakForm()
        {
            InitializeComponent();
        }

        public DodajIzostanakForm(IzostanakDTO i, int idUcenik)
        {
            InitializeComponent();
            izostanak = i;
            this.idUcenik = idUcenik;
        }

        public DodajIzostanakForm(int idUcenik, int idPredmet, int idNastavnik)
        {
            InitializeComponent();

            this.idUcenik = idUcenik;
            this.idPredmet = idPredmet;
            this.idNastavnik = idNastavnik;
        }

        private void DodajIzostanakForm_Load(object sender, EventArgs e)
        {

            if (izostanak != null)
            {
                datumDTP.Value = izostanak.datum;
                brojCasaNP.Value = izostanak.cas;
                komentarTxt.Text = izostanak.komentar;
                brojCasaNP.Enabled = false;
                datumDTP.Enabled = false;
                dodajBtn.Text = "Izmeni";
            }

            FormClosing += DodajIzostanakForm_FormClosing;
        }

        private void DodajIzostanakForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (sacuvano)
                return;

            DialogResult potvrda = MessageBox.Show(
                "Zatvoriti formu bez cuvanja izmena?",
                "Potvrda",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potvrda == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (izostanak == null)
                {
                    dodajIzostanak();
                }
                else
                {
                    izmeniIzostanak();
                }

                sacuvano = true;

                MessageBox.Show(izostanak == null ? "Izostanak je uspesno dodat." : "Izostanak je uspesno izmenjen.");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Doslo je do greske:\n{ex.Message}",
                    "Greska",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dodajIzostanak()
        {
            if (idUcenik == -1 || idPredmet == -1 || idNastavnik == -1)
                throw new Exception("Nisu prosledjeni potrebni podaci.");

            Ucenik? ucenik = DTOManager.vratiUcenika(idUcenik);

            if (ucenik == null)
            {
                throw new Exception("Ucenik nije pronadjen u bazi.");
            }

            Nastava? nastava = DTOManager.vratiNastavu(idNastavnik, idPredmet);

            if (nastava == null)
            {
                throw new Exception("Nastava za izabranog nastavnika i predmet ne postoji.");
            }

            Izostanak novi = new Izostanak
            {
                Id = new IzostanakId
                {
                    Ucenik = ucenik,
                    Datum = datumDTP.Value,
                    RedniBrojCasa = (int)brojCasaNP.Value
                },

                TipIzostanka = TipIzostanka.NEOPRAVDAN,
                Komentar = komentarTxt.Text,
                Nastava = nastava
            };

            DTOManager.dodajIzostanak(novi);
        }

        private void izmeniIzostanak()
        {
            if (izostanak == null)
                throw new Exception("Izostanak nije prosledjen.");

            DTOManager.izmeniIzostanak(izostanak, idUcenik, komentarTxt.Text);
            
        }
    }
}