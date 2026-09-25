namespace Skoslki_dnevnik.Forme
{
    partial class NastavnikPocetna
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
            nastavnici_dgv = new DataGridView();
            predmetiBtn = new Button();
            dodeliPredmetBtn = new Button();
            obrisiNastavnikaBtn = new Button();
            dodajNastavnikaBtn = new Button();
            izmaniNastavnikaBtn = new Button();
            dodeliOcenuBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)nastavnici_dgv).BeginInit();
            SuspendLayout();
            // 
            // nastavnici_dgv
            // 
            nastavnici_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nastavnici_dgv.Location = new Point(6, 10);
            nastavnici_dgv.MultiSelect = false;
            nastavnici_dgv.Name = "nastavnici_dgv";
            nastavnici_dgv.ReadOnly = true;
            nastavnici_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            nastavnici_dgv.Size = new Size(394, 430);
            nastavnici_dgv.TabIndex = 14;
            // 
            // predmetiBtn
            // 
            predmetiBtn.Location = new Point(406, 195);
            predmetiBtn.Name = "predmetiBtn";
            predmetiBtn.Size = new Size(117, 38);
            predmetiBtn.TabIndex = 13;
            predmetiBtn.Text = "Pregledaj predmete";
            predmetiBtn.UseVisualStyleBackColor = true;
            predmetiBtn.Click += predmetiBtn_Click;
            // 
            // dodeliPredmetBtn
            // 
            dodeliPredmetBtn.Location = new Point(406, 159);
            dodeliPredmetBtn.Name = "dodeliPredmetBtn";
            dodeliPredmetBtn.Size = new Size(117, 30);
            dodeliPredmetBtn.TabIndex = 11;
            dodeliPredmetBtn.Text = "dodeli predmet";
            dodeliPredmetBtn.UseVisualStyleBackColor = true;
            dodeliPredmetBtn.Click += dodeliPredmetBtn_Click;
            // 
            // obrisiNastavnikaBtn
            // 
            obrisiNastavnikaBtn.Location = new Point(406, 46);
            obrisiNastavnikaBtn.Name = "obrisiNastavnikaBtn";
            obrisiNastavnikaBtn.Size = new Size(117, 30);
            obrisiNastavnikaBtn.TabIndex = 10;
            obrisiNastavnikaBtn.Text = "obrisi nastavanika";
            obrisiNastavnikaBtn.UseVisualStyleBackColor = true;
            // 
            // dodajNastavnikaBtn
            // 
            dodajNastavnikaBtn.Location = new Point(406, 10);
            dodajNastavnikaBtn.Name = "dodajNastavnikaBtn";
            dodajNastavnikaBtn.Size = new Size(117, 30);
            dodajNastavnikaBtn.TabIndex = 9;
            dodajNastavnikaBtn.Text = "dodaj nastavnika";
            dodajNastavnikaBtn.UseVisualStyleBackColor = true;
            dodajNastavnikaBtn.Click += dodajNastavnikaBtn_Click;
            // 
            // izmaniNastavnikaBtn
            // 
            izmaniNastavnikaBtn.Location = new Point(406, 82);
            izmaniNastavnikaBtn.Name = "izmaniNastavnikaBtn";
            izmaniNastavnikaBtn.Size = new Size(117, 29);
            izmaniNastavnikaBtn.TabIndex = 18;
            izmaniNastavnikaBtn.Text = "izmeni nastavnika";
            izmaniNastavnikaBtn.UseVisualStyleBackColor = true;
            // 
            // dodeliOcenuBtn
            // 
            dodeliOcenuBtn.Location = new Point(406, 239);
            dodeliOcenuBtn.Name = "dodeliOcenuBtn";
            dodeliOcenuBtn.Size = new Size(117, 23);
            dodeliOcenuBtn.TabIndex = 19;
            dodeliOcenuBtn.Text = "Dodeli ocenu";
            dodeliOcenuBtn.UseVisualStyleBackColor = true;
            dodeliOcenuBtn.Click += dodeliOcenuBtn_Click;
            // 
            // NastavnikPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 473);
            Controls.Add(dodeliOcenuBtn);
            Controls.Add(izmaniNastavnikaBtn);
            Controls.Add(nastavnici_dgv);
            Controls.Add(predmetiBtn);
            Controls.Add(dodeliPredmetBtn);
            Controls.Add(obrisiNastavnikaBtn);
            Controls.Add(dodajNastavnikaBtn);
            Name = "NastavnikPocetna";
            Text = "NastavnikPocetna";
            Load += NastavnikPocetna_Load;
            ((System.ComponentModel.ISupportInitialize)nastavnici_dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView nastavnici_dgv;
        private Button predmetiBtn;
        private Button dodeliPredmetBtn;
        private Button obrisiNastavnikaBtn;
        private Button dodajNastavnikaBtn;
        private Button izmaniNastavnikaBtn;
        private Button dodeliOcenuBtn;
    }
}