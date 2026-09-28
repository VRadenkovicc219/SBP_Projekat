namespace Skoslki_dnevnik.Forme
{
    partial class DodajOdeljenjeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            odeljenjaDgv = new DataGridView();
            kreirajBtn = new Button();
            obrisiBtn = new Button();
            azurirajBtn = new Button();
            dodajUcenikaBtn = new Button();
            dodajNastavuBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)odeljenjaDgv).BeginInit();
            SuspendLayout();
            // 
            // odeljenjaDgv
            // 
            odeljenjaDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            odeljenjaDgv.Location = new Point(12, 12);
            odeljenjaDgv.Name = "odeljenjaDgv";
            odeljenjaDgv.ReadOnly = true;
            odeljenjaDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            odeljenjaDgv.Size = new Size(352, 582);
            odeljenjaDgv.TabIndex = 0;
            // 
            // kreirajBtn
            // 
            kreirajBtn.Location = new Point(370, 12);
            kreirajBtn.Name = "kreirajBtn";
            kreirajBtn.Size = new Size(118, 23);
            kreirajBtn.TabIndex = 1;
            kreirajBtn.Text = "Kreiraj odeljenje";
            kreirajBtn.UseVisualStyleBackColor = true;
            // 
            // obrisiBtn
            // 
            obrisiBtn.Location = new Point(370, 41);
            obrisiBtn.Name = "obrisiBtn";
            obrisiBtn.Size = new Size(118, 23);
            obrisiBtn.TabIndex = 2;
            obrisiBtn.Text = "Obrisi odeljenje";
            obrisiBtn.UseVisualStyleBackColor = true;
            // 
            // azurirajBtn
            // 
            azurirajBtn.Location = new Point(370, 70);
            azurirajBtn.Name = "azurirajBtn";
            azurirajBtn.Size = new Size(118, 23);
            azurirajBtn.TabIndex = 3;
            azurirajBtn.Text = "Azuriraj odeljenje";
            azurirajBtn.UseVisualStyleBackColor = true;
            // 
            // dodajUcenikaBtn
            // 
            dodajUcenikaBtn.Location = new Point(370, 116);
            dodajUcenikaBtn.Name = "dodajUcenikaBtn";
            dodajUcenikaBtn.Size = new Size(118, 23);
            dodajUcenikaBtn.TabIndex = 4;
            dodajUcenikaBtn.Text = "Dodaj ucenika";
            dodajUcenikaBtn.UseVisualStyleBackColor = true;
            // 
            // dodajNastavuBtn
            // 
            dodajNastavuBtn.Location = new Point(370, 145);
            dodajNastavuBtn.Name = "dodajNastavuBtn";
            dodajNastavuBtn.Size = new Size(118, 23);
            dodajNastavuBtn.TabIndex = 5;
            dodajNastavuBtn.Text = "Dodaj nastavu";
            dodajNastavuBtn.UseVisualStyleBackColor = true;
            // 
            // DodajOdeljenjeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 606);
            Controls.Add(dodajNastavuBtn);
            Controls.Add(dodajUcenikaBtn);
            Controls.Add(azurirajBtn);
            Controls.Add(obrisiBtn);
            Controls.Add(kreirajBtn);
            Controls.Add(odeljenjaDgv);
            Name = "DodajOdeljenjeForm";
            Text = "DodajOdeljenjeForm";
            ((System.ComponentModel.ISupportInitialize)odeljenjaDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView odeljenjaDgv;
        private Button kreirajBtn;
        private Button obrisiBtn;
        private Button azurirajBtn;
        private Button dodajUcenikaBtn;
        private Button dodajNastavuBtn;
    }
}