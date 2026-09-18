namespace Skoslki_dnevnik.Forme
{
    partial class UcenikPocetna
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
            dodajUcenikaBtn = new Button();
            obrisiUcenikaBtn = new Button();
            dodeliPredmetBtn = new Button();
            dodajTelefonBtn = new Button();
            predmetiBtn = new Button();
            dataGridView1 = new DataGridView();
            oceneBtn = new Button();
            izostanciBtn = new Button();
            roditeljiBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dodajUcenikaBtn
            // 
            dodajUcenikaBtn.Location = new Point(432, 8);
            dodajUcenikaBtn.Name = "dodajUcenikaBtn";
            dodajUcenikaBtn.Size = new Size(100, 30);
            dodajUcenikaBtn.TabIndex = 0;
            dodajUcenikaBtn.Text = "dodaj ucenika";
            dodajUcenikaBtn.UseVisualStyleBackColor = true;
            dodajUcenikaBtn.Click += dodajUcenikaBtn_Click;
            // 
            // obrisiUcenikaBtn
            // 
            obrisiUcenikaBtn.Location = new Point(432, 44);
            obrisiUcenikaBtn.Name = "obrisiUcenikaBtn";
            obrisiUcenikaBtn.Size = new Size(100, 30);
            obrisiUcenikaBtn.TabIndex = 1;
            obrisiUcenikaBtn.Text = "obrisi ucenika";
            obrisiUcenikaBtn.UseVisualStyleBackColor = true;
            // 
            // dodeliPredmetBtn
            // 
            dodeliPredmetBtn.Location = new Point(432, 80);
            dodeliPredmetBtn.Name = "dodeliPredmetBtn";
            dodeliPredmetBtn.Size = new Size(100, 30);
            dodeliPredmetBtn.TabIndex = 2;
            dodeliPredmetBtn.Text = "dodeli predmet";
            dodeliPredmetBtn.UseVisualStyleBackColor = true;
            // 
            // dodajTelefonBtn
            // 
            dodajTelefonBtn.Location = new Point(432, 116);
            dodajTelefonBtn.Name = "dodajTelefonBtn";
            dodajTelefonBtn.Size = new Size(100, 39);
            dodajTelefonBtn.TabIndex = 3;
            dodajTelefonBtn.Text = "dodaj broj telefona";
            dodajTelefonBtn.UseVisualStyleBackColor = true;
            // 
            // predmetiBtn
            // 
            predmetiBtn.Location = new Point(432, 161);
            predmetiBtn.Name = "predmetiBtn";
            predmetiBtn.Size = new Size(100, 42);
            predmetiBtn.TabIndex = 4;
            predmetiBtn.Text = "Pregledaj predmete";
            predmetiBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 8);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(394, 430);
            dataGridView1.TabIndex = 5;
            // 
            // oceneBtn
            // 
            oceneBtn.Location = new Point(432, 209);
            oceneBtn.Name = "oceneBtn";
            oceneBtn.Size = new Size(100, 29);
            oceneBtn.TabIndex = 6;
            oceneBtn.Text = "Pregledaj ocene";
            oceneBtn.UseVisualStyleBackColor = true;
            // 
            // izostanciBtn
            // 
            izostanciBtn.Location = new Point(432, 244);
            izostanciBtn.Name = "izostanciBtn";
            izostanciBtn.Size = new Size(100, 43);
            izostanciBtn.TabIndex = 7;
            izostanciBtn.Text = "Pregledaj izostanke";
            izostanciBtn.UseVisualStyleBackColor = true;
            // 
            // roditeljiBtn
            // 
            roditeljiBtn.Location = new Point(432, 293);
            roditeljiBtn.Name = "roditeljiBtn";
            roditeljiBtn.Size = new Size(100, 43);
            roditeljiBtn.TabIndex = 8;
            roditeljiBtn.Text = "Pregledaj roditelje";
            roditeljiBtn.UseVisualStyleBackColor = true;
            // 
            // UcenikPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 450);
            Controls.Add(roditeljiBtn);
            Controls.Add(izostanciBtn);
            Controls.Add(oceneBtn);
            Controls.Add(dataGridView1);
            Controls.Add(predmetiBtn);
            Controls.Add(dodajTelefonBtn);
            Controls.Add(dodeliPredmetBtn);
            Controls.Add(obrisiUcenikaBtn);
            Controls.Add(dodajUcenikaBtn);
            Name = "UcenikPocetna";
            Text = "UcenikPocetna";
            Load += UcenikPocetna_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }



        #endregion

        private Button dodajUcenikaBtn;
        private Button obrisiUcenikaBtn;
        private Button dodeliPredmetBtn;
        private Button dodajTelefonBtn;
        private Button predmetiBtn;
        private DataGridView dataGridView1;
        private Button oceneBtn;
        private Button izostanciBtn;
        private Button roditeljiBtn;
    }
}