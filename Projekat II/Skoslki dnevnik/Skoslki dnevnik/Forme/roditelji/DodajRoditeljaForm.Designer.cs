namespace Skoslki_dnevnik.Forme
{
    partial class DodajRoditeljaForm
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
            label9 = new Label();
            telefontxt = new TextBox();
            label7 = new Label();
            datumRodjenjaDtp = new DateTimePicker();
            label8 = new Label();
            label1 = new Label();
            komentarTb = new TextBox();
            polCk = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Imel = new Label();
            polZCk = new CheckBox();
            polMCk = new CheckBox();
            emailTb = new TextBox();
            zanimanjetxt = new TextBox();
            adresaTb = new TextBox();
            jmbgTb = new TextBox();
            prezimeTb = new TextBox();
            imeTb = new TextBox();
            dodajBtn = new Button();
            radnoMestoTxt = new TextBox();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 154);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 53;
            label9.Text = "Telefon";
            // 
            // telefontxt
            // 
            telefontxt.Location = new Point(137, 151);
            telefontxt.Name = "telefontxt";
            telefontxt.Size = new Size(264, 23);
            telefontxt.TabIndex = 39;
            telefontxt.KeyPress += telefonTb_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 244);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 52;
            label7.Text = "Datum rodjenja";
            // 
            // datumRodjenjaDtp
            // 
            datumRodjenjaDtp.Format = DateTimePickerFormat.Short;
            datumRodjenjaDtp.Location = new Point(137, 238);
            datumRodjenjaDtp.Name = "datumRodjenjaDtp";
            datumRodjenjaDtp.RightToLeft = RightToLeft.No;
            datumRodjenjaDtp.Size = new Size(264, 23);
            datumRodjenjaDtp.TabIndex = 42;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 212);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 51;
            label8.Text = "Radno mesto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 183);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 56;
            label1.Text = "Zanimanje";
            // 
            // komentarTb
            // 
            komentarTb.Location = new Point(137, 267);
            komentarTb.Name = "komentarTb";
            komentarTb.Size = new Size(264, 23);
            komentarTb.TabIndex = 43;
            // 
            // polCk
            // 
            polCk.AutoSize = true;
            polCk.Location = new Point(13, 297);
            polCk.Name = "polCk";
            polCk.Size = new Size(24, 15);
            polCk.TabIndex = 55;
            polCk.Text = "Pol";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 270);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 54;
            label6.Text = "Dodatni komentar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 125);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 57;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 50;
            label4.Text = "Adresa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(37, 15);
            label3.TabIndex = 49;
            label3.Text = "JMBG";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 48;
            label2.Text = "Prezime";
            // 
            // Imel
            // 
            Imel.AutoSize = true;
            Imel.Location = new Point(12, 9);
            Imel.Name = "Imel";
            Imel.Size = new Size(27, 15);
            Imel.TabIndex = 47;
            Imel.Text = "Ime";
            // 
            // polZCk
            // 
            polZCk.AutoSize = true;
            polZCk.Location = new Point(180, 296);
            polZCk.Name = "polZCk";
            polZCk.Size = new Size(33, 19);
            polZCk.TabIndex = 45;
            polZCk.Text = "Z";
            polZCk.UseVisualStyleBackColor = true;
            polZCk.CheckedChanged += polZCk_CheckedChanged;
            // 
            // polMCk
            // 
            polMCk.AutoSize = true;
            polMCk.Location = new Point(137, 296);
            polMCk.Name = "polMCk";
            polMCk.Size = new Size(37, 19);
            polMCk.TabIndex = 44;
            polMCk.Text = "M";
            polMCk.UseVisualStyleBackColor = true;
            polMCk.CheckedChanged += polMCk_CheckedChanged;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(137, 122);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(264, 23);
            emailTb.TabIndex = 38;
            // 
            // zanimanjetxt
            // 
            zanimanjetxt.Location = new Point(137, 180);
            zanimanjetxt.Name = "zanimanjetxt";
            zanimanjetxt.Size = new Size(264, 23);
            zanimanjetxt.TabIndex = 40;
            // 
            // adresaTb
            // 
            adresaTb.Location = new Point(137, 93);
            adresaTb.Name = "adresaTb";
            adresaTb.Size = new Size(264, 23);
            adresaTb.TabIndex = 37;
            // 
            // jmbgTb
            // 
            jmbgTb.Location = new Point(137, 64);
            jmbgTb.MaxLength = 13;
            jmbgTb.Name = "jmbgTb";
            jmbgTb.Size = new Size(264, 23);
            jmbgTb.TabIndex = 36;
            jmbgTb.KeyPress += jmbgTb_KeyPress;
            jmbgTb.Leave += jmbgTb_Leave;
            // 
            // prezimeTb
            // 
            prezimeTb.Location = new Point(137, 35);
            prezimeTb.Name = "prezimeTb";
            prezimeTb.Size = new Size(264, 23);
            prezimeTb.TabIndex = 35;
            // 
            // imeTb
            // 
            imeTb.Location = new Point(137, 6);
            imeTb.Name = "imeTb";
            imeTb.Size = new Size(264, 23);
            imeTb.TabIndex = 34;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(109, 359);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(209, 23);
            dodajBtn.TabIndex = 46;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // radnoMestoTxt
            // 
            radnoMestoTxt.Location = new Point(137, 209);
            radnoMestoTxt.Name = "radnoMestoTxt";
            radnoMestoTxt.Size = new Size(264, 23);
            radnoMestoTxt.TabIndex = 41;
            // 
            // DodajRoditeljaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 394);
            Controls.Add(radnoMestoTxt);
            Controls.Add(label9);
            Controls.Add(telefontxt);
            Controls.Add(label7);
            Controls.Add(datumRodjenjaDtp);
            Controls.Add(label8);
            Controls.Add(label1);
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
            Controls.Add(zanimanjetxt);
            Controls.Add(adresaTb);
            Controls.Add(jmbgTb);
            Controls.Add(prezimeTb);
            Controls.Add(imeTb);
            Controls.Add(dodajBtn);
            Name = "DodajRoditeljaForm";
            Text = "DodajRoditeljaForm";
            Load += DodajRoditeljaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private TextBox telefontxt;
        private Label label7;
        private DateTimePicker datumRodjenjaDtp;
        private Label label8;
        private Label label1;
        private TextBox komentarTb;
        private Label polCk;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label Imel;
        private CheckBox polZCk;
        private CheckBox polMCk;
        private TextBox emailTb;
        private TextBox zanimanjetxt;
        private TextBox adresaTb;
        private TextBox jmbgTb;
        private TextBox prezimeTb;
        private TextBox imeTb;
        private Button dodajBtn;
        private TextBox radnoMestoTxt;
    }
}