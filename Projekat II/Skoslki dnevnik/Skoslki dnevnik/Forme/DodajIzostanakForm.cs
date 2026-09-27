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

        Izostanak? izostanak = null;
        int idPredmet = -1, idNastavnik = -1, idUcenik = -1;
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
            if (izostanak == null) { opravdaoCmb.Visible = false; opravdaoLbl.Visible = false; }
            else
            {
                opravdaoCmb.DataSource = Enum.GetValues(typeof(Opravdao));
            }

            if (izostanak != null)
            {
                datumDTP.Value = izostanak.Id.Datum;
                brojCasaNP.Value = izostanak.Id.RedniBrojCasa;
                datumDTP.Enabled = false;
                brojCasaNP.Enabled = false;

                tipCmb.SelectedItem = izostanak.TipIzostanka;
                opravdaoCmb.SelectedItem = izostanak.Opravdao;
                razlogTxt.Text = izostanak.RazlogIzostanka;
                razlogTxt.Text = izostanak.Komentar;
            }

            this.FormClosing += (s, args) =>
            {
                var potvrda = MessageBox.Show(
                    "Zatvoriti formu bez cuvanja izmena?",
                    "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (potvrda == DialogResult.No)
                    args.Cancel = true;
            };
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (izostanak == null)
            {
                Ucenik u = DTOManager.vratiUcenika(idUcenik)!;
                Nastava? n = DTOManager.vratiNastavu(idNastavnik, idPredmet);
                if (n is null) {
                    MessageBox.Show("Greska prilikom pribavljanja podataka iz baze");
                    this.Close();
                }

                Izostanak novi = new Izostanak
                {
                    Id = new IzostanakId
                    {
                        Ucenik = u,
                        Datum = datumDTP.Value,
                        RedniBrojCasa = (int)brojCasaNP.Value
                    },
                    TipIzostanka = (TipIzostanka)tipCmb.SelectedItem!,
                    Opravdao = (Opravdao)opravdaoCmb.SelectedItem!,
                    RazlogIzostanka = razlogTxt.Text,
                    Komentar = razlogTxt.Text,
                    Nastava = n!
                };

                DTOManager.dodajIzostanak(novi);
            }
            else
            {
                Izostanak izmenjen = new Izostanak
                {
                    Id = izostanak.Id,
                    TipIzostanka = (TipIzostanka)tipCmb.SelectedItem!,
                    Opravdao = (Opravdao)opravdaoCmb.SelectedItem!,
                    RazlogIzostanka = razlogTxt.Text,
                    Komentar = razlogTxt.Text,
                    Nastava = izostanak.Nastava
                };

                DTOManager.izmeniIzostanak(izostanak.Id, izmenjen);
            }

            this.FormClosing -= null; 
            this.Close();
        }
    }
}
