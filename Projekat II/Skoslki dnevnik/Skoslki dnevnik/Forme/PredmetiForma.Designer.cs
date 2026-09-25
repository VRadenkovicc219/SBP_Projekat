namespace Skoslki_dnevnik.Forme
{
    partial class PredmetiForma
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
            predmeti_dgv = new DataGridView();
            dodajPredmetBtn = new Button();
            izmeniPredmetBtn = new Button();
            obrisiPredmetBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)predmeti_dgv).BeginInit();
            SuspendLayout();
            // 
            // predmeti_dgv
            // 
            predmeti_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predmeti_dgv.Location = new Point(12, 12);
            predmeti_dgv.Name = "predmeti_dgv";
            predmeti_dgv.ReadOnly = true;
            predmeti_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            predmeti_dgv.Size = new Size(280, 370);
            predmeti_dgv.TabIndex = 0;
            predmeti_dgv.CellDoubleClick += predmeti_dgv_CellDoubleClick;
            predmeti_dgv.SelectionChanged += predmeti_dgv_SelectionChanged;
            // 
            // dodajPredmetBtn
            // 
            dodajPredmetBtn.Location = new Point(298, 12);
            dodajPredmetBtn.Name = "dodajPredmetBtn";
            dodajPredmetBtn.Size = new Size(134, 23);
            dodajPredmetBtn.TabIndex = 1;
            dodajPredmetBtn.Text = "dodaj predmet";
            dodajPredmetBtn.UseVisualStyleBackColor = true;
            dodajPredmetBtn.Click += dodajPredmetBtn_Click;
            // 
            // izmeniPredmetBtn
            // 
            izmeniPredmetBtn.Location = new Point(298, 41);
            izmeniPredmetBtn.Name = "izmeniPredmetBtn";
            izmeniPredmetBtn.Size = new Size(134, 23);
            izmeniPredmetBtn.TabIndex = 2;
            izmeniPredmetBtn.Text = "izmeni predmet";
            izmeniPredmetBtn.UseVisualStyleBackColor = true;
            izmeniPredmetBtn.Click += izmeniPredmetBtn_Click;
            // 
            // obrisiPredmetBtn
            // 
            obrisiPredmetBtn.Location = new Point(298, 70);
            obrisiPredmetBtn.Name = "obrisiPredmetBtn";
            obrisiPredmetBtn.Size = new Size(134, 23);
            obrisiPredmetBtn.TabIndex = 3;
            obrisiPredmetBtn.Text = "obrisi predmet";
            obrisiPredmetBtn.UseVisualStyleBackColor = true;
            obrisiPredmetBtn.Click += obrisiPredmetBtn_Click;
            // 
            // PredmetiForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 450);
            Controls.Add(obrisiPredmetBtn);
            Controls.Add(izmeniPredmetBtn);
            Controls.Add(dodajPredmetBtn);
            Controls.Add(predmeti_dgv);
            Name = "PredmetiForma";
            Text = "PredmetiForma";
            Load += PredmetiForma_Load;
            ((System.ComponentModel.ISupportInitialize)predmeti_dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView predmeti_dgv;
        private Button dodajPredmetBtn;
        private Button izmeniPredmetBtn;
        private Button obrisiPredmetBtn;
    }
}