namespace Skoslki_dnevnik.Forme
{
    partial class DodajIzostanakForm
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
            label2 = new Label();
            razlogTxt = new RichTextBox();
            label3 = new Label();
            label1 = new Label();
            Vrednost = new Label();
            tipCmb = new ComboBox();
            brojCasaNP = new NumericUpDown();
            datumDTP = new DateTimePicker();
            dodajBtn = new Button();
            opravdaoCmb = new ComboBox();
            opravdaoLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)brojCasaNP).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 102);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 18;
            label2.Text = "Komentar";
            // 
            // razlogTxt
            // 
            razlogTxt.Location = new Point(85, 99);
            razlogTxt.Name = "razlogTxt";
            razlogTxt.Size = new Size(218, 64);
            razlogTxt.TabIndex = 17;
            razlogTxt.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 16;
            label3.Text = "Tip";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 15;
            label1.Text = "Datum";
            // 
            // Vrednost
            // 
            Vrednost.AutoSize = true;
            Vrednost.Location = new Point(12, 14);
            Vrednost.Name = "Vrednost";
            Vrednost.Size = new Size(54, 15);
            Vrednost.TabIndex = 14;
            Vrednost.Text = "Broj casa";
            // 
            // tipCmb
            // 
            tipCmb.FormattingEnabled = true;
            tipCmb.Location = new Point(85, 70);
            tipCmb.Name = "tipCmb";
            tipCmb.Size = new Size(218, 23);
            tipCmb.TabIndex = 13;
            // 
            // brojCasaNP
            // 
            brojCasaNP.Location = new Point(85, 12);
            brojCasaNP.Name = "brojCasaNP";
            brojCasaNP.Size = new Size(218, 23);
            brojCasaNP.TabIndex = 12;
            // 
            // datumDTP
            // 
            datumDTP.Format = DateTimePickerFormat.Short;
            datumDTP.Location = new Point(85, 41);
            datumDTP.Name = "datumDTP";
            datumDTP.Size = new Size(218, 23);
            datumDTP.TabIndex = 11;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(125, 235);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(85, 28);
            dodajBtn.TabIndex = 19;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // opravdaoCmb
            // 
            opravdaoCmb.FormattingEnabled = true;
            opravdaoCmb.Location = new Point(85, 169);
            opravdaoCmb.Name = "opravdaoCmb";
            opravdaoCmb.Size = new Size(218, 23);
            opravdaoCmb.TabIndex = 20;
            // 
            // opravdaoLbl
            // 
            opravdaoLbl.AutoSize = true;
            opravdaoLbl.Location = new Point(12, 172);
            opravdaoLbl.Name = "opravdaoLbl";
            opravdaoLbl.Size = new Size(59, 15);
            opravdaoLbl.TabIndex = 21;
            opravdaoLbl.Text = "Opravdao";
            // 
            // DodajIzostanakForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 275);
            Controls.Add(opravdaoLbl);
            Controls.Add(opravdaoCmb);
            Controls.Add(dodajBtn);
            Controls.Add(label2);
            Controls.Add(razlogTxt);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Vrednost);
            Controls.Add(tipCmb);
            Controls.Add(brojCasaNP);
            Controls.Add(datumDTP);
            Name = "DodajIzostanakForm";
            Text = "DodajIzostanakForm";
            Load += DodajIzostanakForm_Load;
            ((System.ComponentModel.ISupportInitialize)brojCasaNP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private RichTextBox razlogTxt;
        private Label label3;
        private Label label1;
        private Label Vrednost;
        private ComboBox tipCmb;
        private NumericUpDown brojCasaNP;
        private DateTimePicker datumDTP;
        private Button dodajBtn;
        private ComboBox opravdaoCmb;
        private Label opravdaoLbl;
    }
}