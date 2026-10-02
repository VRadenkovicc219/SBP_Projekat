using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajOcenuForm : Form
    {
        Ocena ocena = null;
        int idPredmet = -1;
        int idProfesor = -1;
        int idUcenik = -1;
        public DodajOcenuForm()
        {
            InitializeComponent();
        }

        public DodajOcenuForm(Ocena o)
        {
            InitializeComponent();
            this.ocena = o;
        }

        public DodajOcenuForm(int idUcenik, int idPredmet, int idNastavnik)
        {
            InitializeComponent();
            this.idPredmet = idPredmet;
            this.idProfesor = idNastavnik;
            this.idUcenik = idUcenik;
        }
        private void dodajBtn_Click(object sender, EventArgs e)
        {
            Ocena novaOcena = new Ocena
            {
                Vrednost = (int)numericUpDown1.Value,
                DatumOcenjivanja = datumDTP.Value,
                Polugodje = (prvoRB.Checked) ? 1 : 2,
                Komentar = komentarTxt.Text,
                Ucenik = (ocena == null) ? DTOManager.vratiUcenika(idUcenik)! : ocena.Ucenik,
                Nastava = (ocena == null) ? DTOManager.vratiNastavu(idProfesor, idPredmet)! : ocena.Nastava
            };

            if (ocena == null)
            {
                DTOManager.dodeliOcenu(novaOcena);
            }
            else
            {
                DTOManager.izmeniOcenu(ocena.Id, novaOcena);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajOcenuForm_Load(object sender, EventArgs e)
        {
            tipCmb.DataSource = Enum.GetValues(typeof(TipOcene));
            if (ocena != null) {
                komentarTxt.Text = ocena.Komentar;
                numericUpDown1.Value = ocena.Vrednost;
                if(ocena.Polugodje == 1) 
                    prvoRB.Checked = true;
                else drugoRB.Checked = true;
                datumDTP.Value = ocena.DatumOcenjivanja;
                tipCmb.SelectedItem = ocena.Tip;
            }
        }
    }
}
