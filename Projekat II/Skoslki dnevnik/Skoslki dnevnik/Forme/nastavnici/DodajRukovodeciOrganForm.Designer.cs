namespace Skoslki_dnevnik.Forme.nastavnici
{
    partial class DodajRukovodeciOrganForm
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
            dodajBtn = new Button();
            godineStazaNM = new NumericUpDown();
            pozicijaCmb = new ComboBox();
            oblastOdgovornostiCmb = new ComboBox();
            datumPreuzimanjaFjeDtp = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)godineStazaNM).BeginInit();
            SuspendLayout();
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(123, 123);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 0;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // godineStazaNM
            // 
            godineStazaNM.Location = new Point(187, 94);
            godineStazaNM.Name = "godineStazaNM";
            godineStazaNM.Size = new Size(121, 23);
            godineStazaNM.TabIndex = 1;
            // 
            // pozicijaCmb
            // 
            pozicijaCmb.FormattingEnabled = true;
            pozicijaCmb.Location = new Point(187, 7);
            pozicijaCmb.Name = "pozicijaCmb";
            pozicijaCmb.Size = new Size(121, 23);
            pozicijaCmb.TabIndex = 2;
            // 
            // oblastOdgovornostiCmb
            // 
            oblastOdgovornostiCmb.FormattingEnabled = true;
            oblastOdgovornostiCmb.Location = new Point(187, 36);
            oblastOdgovornostiCmb.Name = "oblastOdgovornostiCmb";
            oblastOdgovornostiCmb.Size = new Size(121, 23);
            oblastOdgovornostiCmb.TabIndex = 3;
            // 
            // datumPreuzimanjaFjeDtp
            // 
            datumPreuzimanjaFjeDtp.Format = DateTimePickerFormat.Short;
            datumPreuzimanjaFjeDtp.Location = new Point(187, 65);
            datumPreuzimanjaFjeDtp.Name = "datumPreuzimanjaFjeDtp";
            datumPreuzimanjaFjeDtp.Size = new Size(121, 23);
            datumPreuzimanjaFjeDtp.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 5;
            label1.Text = "Rukovodeca pozicija";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 6;
            label2.Text = "Oblast odgovornosti";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(156, 15);
            label3.TabIndex = 7;
            label3.Text = "Datum preuzimanja funkcije";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(169, 15);
            label4.TabIndex = 8;
            label4.Text = "Broj godina rukovodeceg staza";
            // 
            // DodajRukovodeciOrganForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 149);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumPreuzimanjaFjeDtp);
            Controls.Add(oblastOdgovornostiCmb);
            Controls.Add(pozicijaCmb);
            Controls.Add(godineStazaNM);
            Controls.Add(dodajBtn);
            Name = "DodajRukovodeciOrganForm";
            Text = "DodajRukovodeciOrganForm";
            Load += DodajRukovodeciOrganForm_Load;
            ((System.ComponentModel.ISupportInitialize)godineStazaNM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button dodajBtn;
        private NumericUpDown godineStazaNM;
        private ComboBox pozicijaCmb;
        private ComboBox oblastOdgovornostiCmb;
        private DateTimePicker datumPreuzimanjaFjeDtp;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}