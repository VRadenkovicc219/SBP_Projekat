using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajUcenika : Form
    {
        int odeljenjeId = -1;
        public DodajUcenika()
        {
            InitializeComponent();
        }

        public DodajUcenika(int id)
        {
            InitializeComponent();
            odeljenjeId = id;
        }

        private void DodajUcenika_Load(object sender, EventArgs e)
        {
            ucitajUcenike();
        }

        private void ucitajUcenike()
        {
            List<Ucenik> ucenici = DTOManager.vratiUcenikeKojiNisuUOdeljenju(odeljenjeId);
            uceniciDgv.DataSource = ucenici;
            uceniciDgv.Columns["Id"].Visible = false;
            uceniciDgv.Columns["Roditelji"].Visible = false;
            uceniciDgv.Columns["Ocene"].Visible = false;
            uceniciDgv.Columns["Predmeti"].Visible = false;
            uceniciDgv.Columns["Odeljenja"].Visible = false;
            uceniciDgv.Columns["Izostanci"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ucenik> selektovano = new List<Ucenik>();

            foreach (DataGridViewRow red in uceniciDgv.SelectedRows)
            {
                if (red.DataBoundItem is Ucenik ucenik)
                {
                    selektovano.Add(ucenik);
                }
            }

            try
            {
                DTOManager.dodajUcenikeUOdeljenje(selektovano, odeljenjeId);

                MessageBox.Show("Uspesno dodavanje ucenika u odeljenje");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
