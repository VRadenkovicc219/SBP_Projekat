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
            dataGridView1 = new DataGridView();
            predmetiBtn = new Button();
            dodajTelefonBtn = new Button();
            dodeliPredmetBtn = new Button();
            obrisiNastavnikaBtn = new Button();
            dodajNastavnikaBtn = new Button();
            izmaniNastavnikaBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(394, 430);
            dataGridView1.TabIndex = 14;
            // 
            // predmetiBtn
            // 
            predmetiBtn.Location = new Point(406, 195);
            predmetiBtn.Name = "predmetiBtn";
            predmetiBtn.Size = new Size(117, 38);
            predmetiBtn.TabIndex = 13;
            predmetiBtn.Text = "Pregledaj predmete";
            predmetiBtn.UseVisualStyleBackColor = true;
            // 
            // dodajTelefonBtn
            // 
            dodajTelefonBtn.Location = new Point(406, 114);
            dodajTelefonBtn.Name = "dodajTelefonBtn";
            dodajTelefonBtn.Size = new Size(117, 39);
            dodajTelefonBtn.TabIndex = 12;
            dodajTelefonBtn.Text = "dodaj broj telefona";
            dodajTelefonBtn.UseVisualStyleBackColor = true;
            // 
            // dodeliPredmetBtn
            // 
            dodeliPredmetBtn.Location = new Point(406, 159);
            dodeliPredmetBtn.Name = "dodeliPredmetBtn";
            dodeliPredmetBtn.Size = new Size(117, 30);
            dodeliPredmetBtn.TabIndex = 11;
            dodeliPredmetBtn.Text = "dodeli predmet";
            dodeliPredmetBtn.UseVisualStyleBackColor = true;
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
            // NastavnikPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 473);
            Controls.Add(izmaniNastavnikaBtn);
            Controls.Add(dataGridView1);
            Controls.Add(predmetiBtn);
            Controls.Add(dodajTelefonBtn);
            Controls.Add(dodeliPredmetBtn);
            Controls.Add(obrisiNastavnikaBtn);
            Controls.Add(dodajNastavnikaBtn);
            Name = "NastavnikPocetna";
            Text = "NastavnikPocetna";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button predmetiBtn;
        private Button dodajTelefonBtn;
        private Button dodeliPredmetBtn;
        private Button obrisiNastavnikaBtn;
        private Button dodajNastavnikaBtn;
        private Button izmaniNastavnikaBtn;
    }
}