using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajPredmetForm : Form
    {
        public DodajPredmetForm()
        {
            InitializeComponent();
        }

        private void DodajPredmetForm_Load(object sender, EventArgs e)
        {
            tipCb.DataSource = Enum.GetValues(typeof(TipPredmeta));
        }

        private bool validacijaPodataka()
        {
            if (String.IsNullOrWhiteSpace(nazivTxt.Text) ||
                String.IsNullOrWhiteSpace(skolskaGodinaTxt.Text) ||
                String.IsNullOrWhiteSpace(fondTxt.Text) ||
                String.IsNullOrWhiteSpace(razredTxt.Text)
                ) return false;
            if (int.Parse(skolskaGodinaTxt.Text.Substring(0, 4)) + 1 != int.Parse(skolskaGodinaTxt.Text.Substring(5, 4)))
            {
                return false;
            }
            return true;
        }

        private void dodajBtn_Click(object sender, EventArgs e)
        {
            if (!validacijaPodataka())
            {
                MessageBox.Show("Sva polja koja nisu opciona moraju biti popunjena");
            }
            DTOManager.dodajPredmet(new Predmet
            {
                Naziv = nazivTxt.Text,
                SkolskaGodina = skolskaGodinaTxt.Text,
                Razred = long.Parse(razredTxt.Text),
                NedeljniFond = long.Parse(fondTxt.Text),
                Opis = OpisTxt.Text,
                Komentar = komentarTxt.Text,
                Tip = (TipPredmeta)tipCb.SelectedIndex,
            });
        }

        private void razredTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fondTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void skolskaGodinaTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (skolskaGodinaTxt.Text.Length == 4 &&
                int.TryParse(skolskaGodinaTxt.Text, out int godina))
            {
                skolskaGodinaTxt.Text += $"/{godina + 1}";
                skolskaGodinaTxt.SelectionStart = skolskaGodinaTxt.Text.Length;
            }
        }

    }
}

