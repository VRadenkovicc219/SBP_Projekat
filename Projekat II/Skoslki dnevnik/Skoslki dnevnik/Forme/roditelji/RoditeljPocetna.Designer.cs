namespace Skoslki_dnevnik.Forme
{
    partial class RoditeljPocetna
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
            roditeljiDgv = new DataGridView();
            decaCmb = new ComboBox();
            oceneBtn = new Button();
            izostanciBtn = new Button();
            dodajBtn = new Button();
            obrisiBtn = new Button();
            izmeniBtn = new Button();
            dodajVezuBtn = new Button();
            raskiniVezuBtn = new Button();
            Deca = new Label();
            ((System.ComponentModel.ISupportInitialize)roditeljiDgv).BeginInit();
            SuspendLayout();
            // 
            // roditeljiDgv
            // 
            roditeljiDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            roditeljiDgv.Location = new Point(12, 12);
            roditeljiDgv.Name = "roditeljiDgv";
            roditeljiDgv.ReadOnly = true;
            roditeljiDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            roditeljiDgv.Size = new Size(277, 459);
            roditeljiDgv.TabIndex = 0;
            // 
            // decaCmb
            // 
            decaCmb.FormattingEnabled = true;
            decaCmb.Location = new Point(295, 137);
            decaCmb.Name = "decaCmb";
            decaCmb.Size = new Size(200, 23);
            decaCmb.TabIndex = 1;
            // 
            // oceneBtn
            // 
            oceneBtn.Location = new Point(295, 224);
            oceneBtn.Name = "oceneBtn";
            oceneBtn.Size = new Size(200, 23);
            oceneBtn.TabIndex = 2;
            oceneBtn.Text = "Pogledaj ocene";
            oceneBtn.UseVisualStyleBackColor = true;
            oceneBtn.Click += oceneBtn_Click;
            // 
            // izostanciBtn
            // 
            izostanciBtn.Location = new Point(295, 253);
            izostanciBtn.Name = "izostanciBtn";
            izostanciBtn.Size = new Size(200, 24);
            izostanciBtn.TabIndex = 3;
            izostanciBtn.Text = "Pogledaj izostanke";
            izostanciBtn.UseVisualStyleBackColor = true;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(295, 12);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(200, 23);
            dodajBtn.TabIndex = 4;
            dodajBtn.Text = "Dodaj roditelja";
            dodajBtn.UseVisualStyleBackColor = true;
            // 
            // obrisiBtn
            // 
            obrisiBtn.Location = new Point(295, 41);
            obrisiBtn.Name = "obrisiBtn";
            obrisiBtn.Size = new Size(200, 23);
            obrisiBtn.TabIndex = 5;
            obrisiBtn.Text = "Obrisi roditelja";
            obrisiBtn.UseVisualStyleBackColor = true;
            // 
            // izmeniBtn
            // 
            izmeniBtn.Location = new Point(295, 70);
            izmeniBtn.Name = "izmeniBtn";
            izmeniBtn.RightToLeft = RightToLeft.No;
            izmeniBtn.Size = new Size(200, 23);
            izmeniBtn.TabIndex = 6;
            izmeniBtn.Text = "Izmeni roditelja";
            izmeniBtn.UseVisualStyleBackColor = true;
            // 
            // dodajVezuBtn
            // 
            dodajVezuBtn.Location = new Point(295, 166);
            dodajVezuBtn.Name = "dodajVezuBtn";
            dodajVezuBtn.Size = new Size(200, 23);
            dodajVezuBtn.TabIndex = 7;
            dodajVezuBtn.Text = "Dodaj vezu s detetom";
            dodajVezuBtn.UseVisualStyleBackColor = true;
            dodajVezuBtn.Click += dodajVezuBtn_Click;
            // 
            // raskiniVezuBtn
            // 
            raskiniVezuBtn.Location = new Point(295, 195);
            raskiniVezuBtn.Name = "raskiniVezuBtn";
            raskiniVezuBtn.Size = new Size(200, 23);
            raskiniVezuBtn.TabIndex = 8;
            raskiniVezuBtn.Text = "Raskini vezu s detetom";
            raskiniVezuBtn.UseVisualStyleBackColor = true;
            raskiniVezuBtn.Click += raskiniVezuBtn_Click;
            // 
            // Deca
            // 
            Deca.AutoSize = true;
            Deca.Location = new Point(295, 119);
            Deca.Name = "Deca";
            Deca.Size = new Size(36, 15);
            Deca.TabIndex = 9;
            Deca.Text = "Deca:";
            // 
            // RoditeljPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 483);
            Controls.Add(Deca);
            Controls.Add(raskiniVezuBtn);
            Controls.Add(dodajVezuBtn);
            Controls.Add(izmeniBtn);
            Controls.Add(obrisiBtn);
            Controls.Add(dodajBtn);
            Controls.Add(izostanciBtn);
            Controls.Add(oceneBtn);
            Controls.Add(decaCmb);
            Controls.Add(roditeljiDgv);
            Name = "RoditeljPocetna";
            Text = "RoditeljPocetna";
            Load += RoditeljPocetna_Load;
            ((System.ComponentModel.ISupportInitialize)roditeljiDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView roditeljiDgv;
        private ComboBox decaCmb;
        private Button oceneBtn;
        private Button izostanciBtn;
        private Button dodajBtn;
        private Button obrisiBtn;
        private Button izmeniBtn;
        private Button dodajVezuBtn;
        private Button raskiniVezuBtn;
        private Label Deca;
    }
}