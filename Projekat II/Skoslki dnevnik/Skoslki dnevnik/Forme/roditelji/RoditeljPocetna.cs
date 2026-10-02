using Skoslki_dnevnik.Forme.roditelji;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class RoditeljPocetna : Form
    {
        List<RoditeljDTO> roditelji = new List<RoditeljDTO>();
        List<UcenikDTO> deca = new List<UcenikDTO>();

        public RoditeljPocetna()
        {
            InitializeComponent();
        }

        private void RoditeljPocetna_Load(object sender, EventArgs e)
        {
            UcitajRoditelje();
        }

        private void UcitajRoditelje()
        {
            roditelji = DTOManager.vratiRoditelje();

            roditeljiDgv.DataSource = null;
            roditeljiDgv.DataSource = roditelji;

            UcitajDecu();
        }

        private RoditeljDTO? IzabraniRoditelj()
        {
            if (roditeljiDgv.SelectedRows.Count != 1)
                return null;

            return (RoditeljDTO)roditeljiDgv.SelectedRows[0].DataBoundItem!;
        }

        private UcenikDTO? IzabranoDete()
        {
            return decaCmb.SelectedItem as UcenikDTO;
        }

        private void UcitajDecu()
        {
            RoditeljDTO? roditelj = IzabraniRoditelj();

            if (roditelj == null)
            {
                deca = new List<UcenikDTO>();

                decaCmb.DataSource = null;

                OsveziStanjeDugmadi();
                return;
            }

            deca = DTOManager.vratiDecuRoditelja(roditelj.id);

            decaCmb.DataSource = null;
            decaCmb.DataSource = deca;
            decaCmb.DisplayMember = nameof(UcenikDTO.ime);

            OsveziStanjeDugmadi();
        }

        private void OsveziStanjeDugmadi()
        {
            bool imaRoditelja = roditeljiDgv.SelectedRows.Count == 1;
            bool imaDete = decaCmb.SelectedItem is UcenikDTO;

            obrisiBtn.Enabled = imaRoditelja;
            izmeniBtn.Enabled = imaRoditelja;

            dodajVezuBtn.Enabled = imaRoditelja;
            raskiniVezuBtn.Enabled = imaRoditelja && imaDete;

            oceneBtn.Enabled = imaDete;
            izostanciBtn.Enabled = imaDete;
        }

        private void roditeljiDgv_SelectionChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated)
                return;

            BeginInvoke(new Action(() =>
            {
                UcitajDecu();
            }));
        }

        private void decaCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OsveziStanjeDugmadi();
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            DodajRoditeljaForm nf = new DodajRoditeljaForm();
            nf.ShowDialog();

            UcitajRoditelje();
        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {
            RoditeljDTO? roditelj = IzabraniRoditelj();

            if (roditelj == null)
                return;

            RoditeljStaratelj? r = DTOManager.vratiRoditelja(roditelj.id);

            if (r == null)
            {
                MessageBox.Show("Roditelj vise ne postoji u bazi podataka");
                UcitajRoditelje();
                return;
            }

            DodajRoditeljaForm nf = new DodajRoditeljaForm(r);
            nf.ShowDialog();

            UcitajRoditelje();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            RoditeljDTO? roditelj = IzabraniRoditelj();

            if (roditelj == null)
                return;

            DialogResult potvrda = MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete roditelja {roditelj.ime} {roditelj.prezime}?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes)
                return;

            RoditeljStaratelj? r = DTOManager.vratiRoditelja(roditelj.id);

            if (r == null)
                return;

            DTOManager.obrisiRoditelja(r);

            UcitajRoditelje();
        }

        private void dodajVezuBtn_Click(object sender, EventArgs e)
        {
            RoditeljDTO? roditelj = IzabraniRoditelj();

            if (roditelj == null)
                return;

            IzborDece nf = new IzborDece(roditelj.id);
            nf.ShowDialog();

            UcitajDecu();
        }

        private void raskiniVezuBtn_Click(object sender, EventArgs e)
        {
            RoditeljDTO? roditelj = IzabraniRoditelj();

            if (roditelj == null)
                return;

            IzborDece nf = new IzborDece(roditelj.id, false);
            nf.ShowDialog();

            UcitajDecu();
        }

        private void oceneBtn_Click(object sender, EventArgs e)
        {
            UcenikDTO? u = IzabranoDete();

            if (u == null)
                return;

            PregledStatistikaOcena nf = new PregledStatistikaOcena(u);
            nf.ShowDialog();
        }

        private void izostanciBtn_Click(object sender, EventArgs e)
        {
            UcenikDTO? u = IzabranoDete();

            if (u == null)
                return;

            PregledStatistikaIzostanak nf = new PregledStatistikaIzostanak(u);
            nf.ShowDialog();
        }
    }
}