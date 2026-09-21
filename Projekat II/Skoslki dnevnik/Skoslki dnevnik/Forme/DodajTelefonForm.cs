using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Skoslki_dnevnik.Forme
{
    public partial class DodajTelefonForm : Form
    {
        List<OsobaTelefon> telefoni = new List<OsobaTelefon>();
        Osoba o = null;
        public DodajTelefonForm()
        {
            InitializeComponent();
        }
        public DodajTelefonForm(Osoba o) : this() {
            this.o = o;
        }
        private void DodajTelefonForm_Load(object sender, EventArgs e)
        {
            telefoni = DTOManager.vratiTelefone(o);
            dataGridView1.DataSource = telefoni;
        }
    }
}
