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
            if (roditeljiDgv.SelectedRows.Count != 1) return null;
            return (RoditeljDTO)roditeljiDgv.SelectedRows[0].DataBoundItem!;
        }

        private UcenikDTO? IzabranoDete() => decaCmb.SelectedItem as UcenikDTO;

        private void UcitajDecu()
        {
            var roditelj = IzabraniRoditelj();
            deca = roditelj is null ? new List<UcenikDTO>() : DTOManager.vratiDecuRoditelja(roditelj.id);

            decaCmb.DataSource = null;
            decaCmb.DataSource = deca;
            decaCmb.DisplayMember = nameof(UcenikDTO.ime);

            OsveziStanjeDugmadi();
        }

        private void OsveziStanjeDugmadi()
        {
            bool imaRoditelja = IzabraniRoditelj() != null;
            bool imaDete = IzabranoDete() != null;

            obrisiBtn.Enabled = imaRoditelja;
            izmeniBtn.Enabled = imaRoditelja;

            dodajVezuBtn.Enabled = imaRoditelja;
            raskiniVezuBtn.Enabled = imaRoditelja && imaDete;
            oceneBtn.Enabled = imaDete;
            izostanciBtn.Enabled = imaDete;
        }

        private void roditeljiDgv_SelectionChanged(object sender, EventArgs e) => UcitajDecu();

        private void decaCmb_SelectedIndexChanged(object sender, EventArgs e) => OsveziStanjeDugmadi();

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            new DodajRoditeljaForm().ShowDialog();
            UcitajRoditelje();
        }

        private void izmeniBtn_Click(object sender, EventArgs e)
        {
            var roditelj = IzabraniRoditelj();
            if (roditelj is null) return;

            RoditeljStaratelj? r = DTOManager.vratiRoditelja(roditelj.id);
            if (r is null)
            {
                MessageBox.Show("Roditelj vise ne postoji u bazi podataka");
                UcitajRoditelje();
                return;
            }

            new DodajRoditeljaForm(r).ShowDialog();
            UcitajRoditelje();
        }

        private void obrisiBtn_Click(object sender, EventArgs e)
        {
            var roditelj = IzabraniRoditelj();
            if (roditelj is null) return;

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete roditelja {roditelj.ime} {roditelj.prezime}?",
                "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            RoditeljStaratelj? r = DTOManager.vratiRoditelja(roditelj.id);
            if (r is null) return;

            DTOManager.obrisiRoditelja(r);
            UcitajRoditelje();
        }

        private void dodajVezuBtn_Click(object sender, EventArgs e)
        {
            if (roditeljiDgv.SelectedRows.Count != 0)
            {
                return;
            }
            int id = IzabraniRoditelj()!.id;
            IzborDece nf = new IzborDece(id);

        }

        private void raskiniVezuBtn_Click(object sender, EventArgs e)
        {
            if (roditeljiDgv.SelectedRows.Count != 0)
            {
                return;
            }
            int id = IzabraniRoditelj()!.id;
            IzborDece nf = new IzborDece(id, false);
        }

        private void oceneBtn_Click(object sender, EventArgs e)
        {
            Ucenik u = (Ucenik)decaCmb.SelectedItem!;
            PregledStatistikaOcena nf = new PregledStatistikaOcena();
        }
    }
}
