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
        private Izostanak? izostanak = null;

        private int idPredmet = -1;
        private int idNastavnik = -1;
        private int idUcenik = -1;

        private bool sacuvano = false;

        public DodajIzostanakForm()
        {
            InitializeComponent();
        }

        public DodajIzostanakForm(Izostanak i)
        {
            InitializeComponent();
            izostanak = i;
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
            tipCmb.DataSource = Enum.GetValues(typeof(TipIzostanka));

            if (izostanak == null)
            {
                tipCmb.SelectedItem = TipIzostanka.NEOPRAVDAN;
                tipCmb.Enabled = false;

                opravdaoCmb.Visible = false;
                opravdaoLbl.Visible = false;
            }
            else
            {
                opravdaoCmb.DataSource = Enum.GetValues(typeof(Opravdao));

                datumDTP.Value = izostanak.Id.Datum;
                brojCasaNP.Value = izostanak.Id.RedniBrojCasa;

                datumDTP.Enabled = false;
                brojCasaNP.Enabled = false;

                tipCmb.SelectedItem = izostanak.TipIzostanka;
                opravdaoCmb.SelectedItem = izostanak.Opravdao;

                razlogTxt.Text = izostanak.RazlogIzostanka;
                komentarTxt.Text = izostanak.Komentar;

                bool opravdan = izostanak.TipIzostanka == TipIzostanka.OPRAVDAN;

                opravdaoCmb.Visible = opravdan;
                opravdaoLbl.Visible = opravdan;
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

        private void tipCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool opravdan = tipCmb.SelectedItem is TipIzostanka tip
                            && tip == TipIzostanka.OPRAVDAN;

            opravdaoCmb.Visible = opravdan;
            opravdaoLbl.Visible = opravdan;

            if (opravdan && opravdaoCmb.DataSource == null)
                opravdaoCmb.DataSource = Enum.GetValues(typeof(Opravdao));
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool dodavanje = izostanak == null;

                if (dodavanje)
                {
                    dodajIzostanak();
                }
                else
                {
                    izmeniIzostanak();
                }

                sacuvano = true;

                MessageBox.Show(dodavanje
                    ? "Izostanak je uspesno dodat."
                    : "Izostanak je uspesno izmenjen.");

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
                throw new Exception("Ucenik nije pronadjen u bazi.");

            Nastava? nastava = DTOManager.vratiNastavu(idNastavnik, idPredmet);

            if (nastava == null)
                throw new Exception("Nastava za izabranog nastavnika i predmet ne postoji.");

            Izostanak novi = new Izostanak
            {
                Id = new IzostanakId
                {
                    Ucenik = ucenik,
                    Datum = datumDTP.Value,
                    RedniBrojCasa = (int)brojCasaNP.Value
                },

                TipIzostanka = TipIzostanka.NEOPRAVDAN,
                Opravdao = null,
                RazlogIzostanka = razlogTxt.Text,
                Komentar = komentarTxt.Text,
                Nastava = nastava
            };

            DTOManager.dodajIzostanak(novi);
        }

        private void izmeniIzostanak()
        {
            if (izostanak == null)
                throw new Exception("Izostanak nije prosledjen.");

            if (tipCmb.SelectedItem == null)
                throw new Exception("Morate izabrati tip izostanka.");

            TipIzostanka tip = (TipIzostanka)tipCmb.SelectedItem;

            if (tip == TipIzostanka.OPRAVDAN && opravdaoCmb.SelectedItem == null)
                throw new Exception("Morate izabrati ko je opravdao izostanak.");

            Izostanak izmenjen = new Izostanak
            {
                Id = izostanak.Id,

                TipIzostanka = tip,

                Opravdao = tip == TipIzostanka.OPRAVDAN
                    ? (Opravdao)opravdaoCmb.SelectedItem!
                    : null,

                RazlogIzostanka = razlogTxt.Text,
                Komentar = komentarTxt.Text,
                Nastava = izostanak.Nastava
            };

            DTOManager.izmeniIzostanak(
                izostanak.Id,
                izmenjen);
        }
    }
}