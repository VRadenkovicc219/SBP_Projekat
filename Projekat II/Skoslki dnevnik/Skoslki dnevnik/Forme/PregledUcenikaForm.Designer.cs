namespace Skoslki_dnevnik.Forme
{
    partial class PregledUcenikaForm
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
            uceniciDgv = new DataGridView();
            dodeliOcenuBtn = new Button();
            dodeliIzostanakBtn = new Button();
            izostanciBtn = new Button();
            oceneBtn = new Button();
            predmetiCB = new ComboBox();
            label1 = new Label();
            izbaciUcenikaBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).BeginInit();
            SuspendLayout();
            // 
            // uceniciDgv
            // 
            uceniciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uceniciDgv.Location = new Point(12, 46);
            uceniciDgv.Name = "uceniciDgv";
            uceniciDgv.ReadOnly = true;
            uceniciDgv.Size = new Size(364, 426);
            uceniciDgv.TabIndex = 0;
            // 
            // dodeliOcenuBtn
            // 
            dodeliOcenuBtn.Location = new Point(382, 151);
            dodeliOcenuBtn.Name = "dodeliOcenuBtn";
            dodeliOcenuBtn.Size = new Size(117, 29);
            dodeliOcenuBtn.TabIndex = 24;
            dodeliOcenuBtn.Text = "dodeli ocenu";
            dodeliOcenuBtn.UseVisualStyleBackColor = true;
            // 
            // dodeliIzostanakBtn
            // 
            dodeliIzostanakBtn.Location = new Point(382, 116);
            dodeliIzostanakBtn.Name = "dodeliIzostanakBtn";
            dodeliIzostanakBtn.Size = new Size(117, 29);
            dodeliIzostanakBtn.TabIndex = 23;
            dodeliIzostanakBtn.Text = "dodeli izostanak";
            dodeliIzostanakBtn.UseVisualStyleBackColor = true;
            // 
            // izostanciBtn
            // 
            izostanciBtn.Location = new Point(382, 81);
            izostanciBtn.Name = "izostanciBtn";
            izostanciBtn.Size = new Size(117, 29);
            izostanciBtn.TabIndex = 22;
            izostanciBtn.Text = "Pregledaj izostanke";
            izostanciBtn.UseVisualStyleBackColor = true;
            // 
            // oceneBtn
            // 
            oceneBtn.Location = new Point(382, 46);
            oceneBtn.Name = "oceneBtn";
            oceneBtn.Size = new Size(117, 29);
            oceneBtn.TabIndex = 21;
            oceneBtn.Text = "Pregledaj ocene";
            oceneBtn.UseVisualStyleBackColor = true;
            // 
            // predmetiCB
            // 
            predmetiCB.FormattingEnabled = true;
            predmetiCB.Location = new Point(70, 12);
            predmetiCB.Name = "predmetiCB";
            predmetiCB.Size = new Size(306, 23);
            predmetiCB.TabIndex = 25;
            predmetiCB.SelectedIndexChanged += predmetiCB_SelectedIndexChanged;
            predmetiCB.SelectionChangeCommitted += predmetiCB_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 26;
            label1.Text = "Predmet";
            // 
            // izbaciUcenikaBtn
            // 
            izbaciUcenikaBtn.Location = new Point(382, 186);
            izbaciUcenikaBtn.Name = "izbaciUcenikaBtn";
            izbaciUcenikaBtn.Size = new Size(117, 29);
            izbaciUcenikaBtn.TabIndex = 27;
            izbaciUcenikaBtn.Text = "izbaci ucenika";
            izbaciUcenikaBtn.UseVisualStyleBackColor = true;
            // 
            // PregledUcenikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 484);
            Controls.Add(izbaciUcenikaBtn);
            Controls.Add(label1);
            Controls.Add(predmetiCB);
            Controls.Add(dodeliOcenuBtn);
            Controls.Add(dodeliIzostanakBtn);
            Controls.Add(izostanciBtn);
            Controls.Add(oceneBtn);
            Controls.Add(uceniciDgv);
            Name = "PregledUcenikaForm";
            Text = "PregledUcenikaForm";
            Load += PregledUcenikaForm_Load;
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView uceniciDgv;
        private Button dodeliOcenuBtn;
        private Button dodeliIzostanakBtn;
        private Button izostanciBtn;
        private Button oceneBtn;
        private ComboBox predmetiCB;
        private Label label1;
        private Button izbaciUcenikaBtn;
    }
}