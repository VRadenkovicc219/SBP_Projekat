namespace Skoslki_dnevnik.Forme
{
    partial class DodajUcenikaForma
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
            imeTb = new TextBox();
            prezimeTb = new TextBox();
            jmbgTb = new TextBox();
            adresaTb = new TextBox();
            godinaUpisatxt = new TextBox();
            emailTb = new TextBox();
            polMCk = new CheckBox();
            polZCk = new CheckBox();
            Imel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            polCk = new Label();
            komentarTb = new TextBox();
            statusCb = new ComboBox();
            label1 = new Label();
            label8 = new Label();
            datumRodjenjaDtp = new DateTimePicker();
            label7 = new Label();
            label9 = new Label();
            telefontxt = new TextBox();
            SuspendLayout();
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(117, 356);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(209, 23);
            dodajBtn.TabIndex = 13;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += button1_Click;
            // 
            // imeTb
            // 
            imeTb.Location = new Point(140, 22);
            imeTb.Name = "imeTb";
            imeTb.Size = new Size(264, 23);
            imeTb.TabIndex = 1;
            // 
            // prezimeTb
            // 
            prezimeTb.Location = new Point(140, 51);
            prezimeTb.Name = "prezimeTb";
            prezimeTb.Size = new Size(264, 23);
            prezimeTb.TabIndex = 2;
            // 
            // jmbgTb
            // 
            jmbgTb.Location = new Point(140, 80);
            jmbgTb.Name = "jmbgTb";
            jmbgTb.Size = new Size(264, 23);
            jmbgTb.TabIndex = 3;
            // 
            // adresaTb
            // 
            adresaTb.Location = new Point(140, 109);
            adresaTb.Name = "adresaTb";
            adresaTb.Size = new Size(264, 23);
            adresaTb.TabIndex = 4;
            // 
            // godinaUpisatxt
            // 
            godinaUpisatxt.Location = new Point(140, 196);
            godinaUpisatxt.Name = "godinaUpisatxt";
            godinaUpisatxt.Size = new Size(264, 23);
            godinaUpisatxt.TabIndex = 7;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(140, 138);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(264, 23);
            emailTb.TabIndex = 5;
            // 
            // polMCk
            // 
            polMCk.AutoSize = true;
            polMCk.Location = new Point(140, 312);
            polMCk.Name = "polMCk";
            polMCk.Size = new Size(37, 19);
            polMCk.TabIndex = 11;
            polMCk.Text = "M";
            polMCk.UseVisualStyleBackColor = true;
            polMCk.CheckedChanged += polMCk_CheckedChanged;
            // 
            // polZCk
            // 
            polZCk.AutoSize = true;
            polZCk.Location = new Point(183, 312);
            polZCk.Name = "polZCk";
            polZCk.Size = new Size(33, 19);
            polZCk.TabIndex = 12;
            polZCk.Text = "Z";
            polZCk.UseVisualStyleBackColor = true;
            polZCk.CheckedChanged += polZCk_CheckedChanged;
            // 
            // Imel
            // 
            Imel.AutoSize = true;
            Imel.Location = new Point(15, 25);
            Imel.Name = "Imel";
            Imel.Size = new Size(30, 15);
            Imel.TabIndex = 16;
            Imel.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 17;
            label2.Text = "Prezime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 83);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(37, 15);
            label3.TabIndex = 18;
            label3.Text = "JMBG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 112);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 19;
            label4.Text = "Adresa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 141);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 33;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 286);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 27;
            label6.Text = "Dodatni komentar";
            // 
            // polCk
            // 
            polCk.AutoSize = true;
            polCk.Location = new Point(15, 313);
            polCk.Name = "polCk";
            polCk.Size = new Size(24, 15);
            polCk.TabIndex = 28;
            polCk.Text = "Pol";
            // 
            // komentarTb
            // 
            komentarTb.Location = new Point(140, 283);
            komentarTb.Name = "komentarTb";
            komentarTb.Size = new Size(264, 23);
            komentarTb.TabIndex = 10;
            // 
            // statusCb
            // 
            statusCb.FormattingEnabled = true;
            statusCb.Location = new Point(140, 225);
            statusCb.Name = "statusCb";
            statusCb.Size = new Size(264, 23);
            statusCb.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 199);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 32;
            label1.Text = "Godina upisa";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 228);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 21;
            label8.Text = "Status";
            // 
            // datumRodjenjaDtp
            // 
            datumRodjenjaDtp.Format = DateTimePickerFormat.Short;
            datumRodjenjaDtp.Location = new Point(140, 254);
            datumRodjenjaDtp.Name = "datumRodjenjaDtp";
            datumRodjenjaDtp.RightToLeft = RightToLeft.No;
            datumRodjenjaDtp.Size = new Size(264, 23);
            datumRodjenjaDtp.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 260);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 24;
            label7.Text = "Datum rodjenja";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 170);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 26;
            label9.Text = "Telefon";
            // 
            // telefontxt
            // 
            telefontxt.Location = new Point(140, 167);
            telefontxt.Name = "telefontxt";
            telefontxt.Size = new Size(264, 23);
            telefontxt.TabIndex = 6;
            // 
            // DodajUcenikaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 391);
            Controls.Add(label9);
            Controls.Add(telefontxt);
            Controls.Add(label7);
            Controls.Add(datumRodjenjaDtp);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(statusCb);
            Controls.Add(komentarTb);
            Controls.Add(polCk);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Imel);
            Controls.Add(polZCk);
            Controls.Add(polMCk);
            Controls.Add(emailTb);
            Controls.Add(godinaUpisatxt);
            Controls.Add(adresaTb);
            Controls.Add(jmbgTb);
            Controls.Add(prezimeTb);
            Controls.Add(imeTb);
            Controls.Add(dodajBtn);
            Name = "DodajUcenikaForma";
            Text = "DodajUcenikaForma";
            Load += DodajUcenikaForma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button dodajBtn;
        private TextBox imeTb;
        private TextBox prezimeTb;
        private TextBox jmbgTb;
        private TextBox adresaTb;
        private TextBox godinaUpisatxt;
        private TextBox emailTb;
        private CheckBox polMCk;
        private CheckBox polZCk;
        private Label Imel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label polCk;
        private TextBox komentarTb;
        private ComboBox statusCb;
        private Label label1;
        private Label label8;
        private DateTimePicker datumRodjenjaDtp;
        private Label label7;
        private Label label9;
        private TextBox telefontxt;
    }
}