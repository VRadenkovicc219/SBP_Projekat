using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme.roditelji
{
    public partial class IzborDece : Form
    {
        bool dodaj = false;
        List<UcenikDTO> deca = new List<UcenikDTO>();
        int idRoditelj = -1;
        public IzborDece()
        {
            InitializeComponent();
        }

        public IzborDece(int idRoditelj, bool dodaj = true)
        {
            InitializeComponent();
            this.dodaj = dodaj;
            this.idRoditelj = idRoditelj;
        }

        private void IzborDece_Load(object sender, EventArgs e)
        {
            dodajBtn.Text = (dodaj) ? "Dodaj vezu" : "Obrisi vezu";
            if (!dodaj)
            {
                label3.Visible = false;
                jmbgTb.Visible = false;
            }
            ucitajPodatke();
        }

        private void jmbgTb_Leave(object sender, EventArgs e)
        {
            if (jmbgTb.Text.Length == 13)
            {
                uceniciDgv.DataSource = deca.Where(x => x.JMBG == jmbgTb.Text).ToList();
            }
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (uceniciDgv.SelectedRows.Count == 0) {
                return;
            }
            if (dodaj) dodajVezu(); 
            else raskiniVezu();
        }
        private void ucitajPodatke() {
            deca = DTOManager.vratiUcenikeKojiNisuDeteRoditelja(idRoditelj);
            uceniciDgv.DataSource = deca;
        }

        private void dodajVezu() {
            UcenikDTO u = (UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!;
            try
            {
                DTOManager.dodajVezuRoditeljUcenik(idRoditelj, u.id);
                MessageBox.Show("Uspesno dodata veza roditelj ucenik");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja veze roditelj ucenik: {ex.Message}");
                this.Close();
            }
        }

        private void raskiniVezu() {
            UcenikDTO u = (UcenikDTO)uceniciDgv.SelectedRows[0].DataBoundItem!;
            try
            {
                DTOManager.raskiniVezuRoditeljUcenik(idRoditelj, u.id);
                MessageBox.Show("Uspesno raskinuta veza roditelj ucenik");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom dodavanja veze roditelj ucenik: {ex.Message}");
                this.Close();
            }
        }
    }
}
