using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class KreirajOdeljenjeForm : Form
    {
        Odeljenje o = null;
        public KreirajOdeljenjeForm()
        {
            InitializeComponent();
        }

        public KreirajOdeljenjeForm(Odeljenje o)
        {
            InitializeComponent();
            this.o = o;
        }

        private bool validacija()
        {
            if (razredNum.Value > 8 || 
                String.IsNullOrWhiteSpace(oznakaTxt.Text) || 
                String.IsNullOrWhiteSpace(godinaTxt.Text)) 
                return false;
            return true;
        }

        private void kreirajBtn_Click(object sender, EventArgs e)
        {
            if (validacija())
            {
                Odeljenje novo = new Odeljenje { Oznaka = oznakaTxt.Text, Razred = (int)razredNum.Value, SkolskaGodina = godinaTxt.Text };
                try
                {
                    if (o is null)
                    {
                        DTOManager.kreirajOdeljenje(novo);
                        MessageBox.Show("Uspesno ste kreirali odeljenje!");
                    }
                    else {
                        DTOManager.izmeniOdeljenje(o.Id, novo.Oznaka, novo.SkolskaGodina, novo.Razred);
                        MessageBox.Show("Uspesno ste azurirali odeljenje!");

                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                MessageBox.Show("Greska prilikom unosa podataka");
            }
        }
    }
}
