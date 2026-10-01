namespace Skoslki_dnevnik.Forme.nastavnici
{
    partial class DodajSaradnikaForm
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
            brojRazgovoraNM = new NumericUpDown();
            brojRadionicaNM = new NumericUpDown();
            licencaTxt = new TextBox();
            sspremaCmb = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dodajBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)brojRazgovoraNM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brojRadionicaNM).BeginInit();
            SuspendLayout();
            // 
            // brojRazgovoraNM
            // 
            brojRazgovoraNM.Location = new Point(169, 70);
            brojRazgovoraNM.Name = "brojRazgovoraNM";
            brojRazgovoraNM.Size = new Size(120, 23);
            brojRazgovoraNM.TabIndex = 0;
            // 
            // brojRadionicaNM
            // 
            brojRadionicaNM.Location = new Point(169, 99);
            brojRadionicaNM.Name = "brojRadionicaNM";
            brojRadionicaNM.Size = new Size(120, 23);
            brojRadionicaNM.TabIndex = 1;
            // 
            // licencaTxt
            // 
            licencaTxt.Location = new Point(168, 15);
            licencaTxt.Name = "licencaTxt";
            licencaTxt.Size = new Size(120, 23);
            licencaTxt.TabIndex = 3;
            // 
            // sspremaCmb
            // 
            sspremaCmb.FormattingEnabled = true;
            sspremaCmb.Location = new Point(168, 41);
            sspremaCmb.Name = "sspremaCmb";
            sspremaCmb.Size = new Size(121, 23);
            sspremaCmb.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 5;
            label1.Text = "Licenca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 6;
            label2.Text = "Strucna sprema";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 72);
            label3.Name = "label3";
            label3.Size = new Size(151, 15);
            label3.TabIndex = 7;
            label3.Text = "Broj sprovedenih razgovora";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 101);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 8;
            label4.Text = "Broj odrzanih radionica";
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(109, 129);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 9;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // DodajSaradnikaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 164);
            Controls.Add(dodajBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(sspremaCmb);
            Controls.Add(licencaTxt);
            Controls.Add(brojRadionicaNM);
            Controls.Add(brojRazgovoraNM);
            Name = "DodajSaradnikaForm";
            Text = "DodajSaradnikaForm";
            Load += DodajSaradnikaForm_Load;
            ((System.ComponentModel.ISupportInitialize)brojRazgovoraNM).EndInit();
            ((System.ComponentModel.ISupportInitialize)brojRadionicaNM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown brojRazgovoraNM;
        private NumericUpDown brojRadionicaNM;
        private TextBox licencaTxt;
        private ComboBox sspremaCmb;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button dodajBtn;
    }
}