namespace Skoslki_dnevnik.Forme
{
    partial class DodajOcenuForm
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
            datumDTP = new DateTimePicker();
            groupBox1 = new GroupBox();
            drugoRB = new RadioButton();
            prvoRB = new RadioButton();
            numericUpDown1 = new NumericUpDown();
            tipCmb = new ComboBox();
            dodajBtn = new Button();
            Vrednost = new Label();
            label1 = new Label();
            label3 = new Label();
            komentarTxt = new RichTextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // datumDTP
            // 
            datumDTP.Format = DateTimePickerFormat.Short;
            datumDTP.Location = new Point(85, 41);
            datumDTP.Name = "datumDTP";
            datumDTP.Size = new Size(218, 23);
            datumDTP.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(drugoRB);
            groupBox1.Controls.Add(prvoRB);
            groupBox1.Location = new Point(85, 169);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(218, 55);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Polugodje";
            // 
            // drugoRB
            // 
            drugoRB.AutoSize = true;
            drugoRB.Location = new Point(145, 22);
            drugoRB.Name = "drugoRB";
            drugoRB.Size = new Size(31, 19);
            drugoRB.TabIndex = 1;
            drugoRB.TabStop = true;
            drugoRB.Text = "II";
            drugoRB.UseVisualStyleBackColor = true;
            // 
            // prvoRB
            // 
            prvoRB.AutoSize = true;
            prvoRB.Location = new Point(35, 22);
            prvoRB.Name = "prvoRB";
            prvoRB.Size = new Size(28, 19);
            prvoRB.TabIndex = 0;
            prvoRB.TabStop = true;
            prvoRB.Text = "I";
            prvoRB.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(85, 12);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(218, 23);
            numericUpDown1.TabIndex = 2;
            // 
            // tipCmb
            // 
            tipCmb.FormattingEnabled = true;
            tipCmb.Location = new Point(85, 70);
            tipCmb.Name = "tipCmb";
            tipCmb.Size = new Size(218, 23);
            tipCmb.TabIndex = 3;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(120, 242);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 4;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // Vrednost
            // 
            Vrednost.AutoSize = true;
            Vrednost.Location = new Point(12, 14);
            Vrednost.Name = "Vrednost";
            Vrednost.Size = new Size(54, 15);
            Vrednost.TabIndex = 5;
            Vrednost.Text = "Vrednost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Datum";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 8;
            label3.Text = "Tip";
            // 
            // komentarTxt
            // 
            komentarTxt.Location = new Point(85, 99);
            komentarTxt.Name = "komentarTxt";
            komentarTxt.Size = new Size(218, 64);
            komentarTxt.TabIndex = 9;
            komentarTxt.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 102);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 10;
            label2.Text = "Komentar";
            // 
            // DodajOcenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 277);
            Controls.Add(label2);
            Controls.Add(komentarTxt);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Vrednost);
            Controls.Add(dodajBtn);
            Controls.Add(tipCmb);
            Controls.Add(numericUpDown1);
            Controls.Add(groupBox1);
            Controls.Add(datumDTP);
            Name = "DodajOcenuForm";
            Text = "DodajOcenuForm";
            Load += DodajOcenuForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker datumDTP;
        private GroupBox groupBox1;
        private RadioButton drugoRB;
        private RadioButton prvoRB;
        private NumericUpDown numericUpDown1;
        private ComboBox tipCmb;
        private Button dodajBtn;
        private Label Vrednost;
        private Label label1;
        private Label label3;
        private RichTextBox komentarTxt;
        private Label label2;
    }
}