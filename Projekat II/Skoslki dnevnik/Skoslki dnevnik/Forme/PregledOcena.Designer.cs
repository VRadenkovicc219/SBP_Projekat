namespace Skoslki_dnevnik.Forme
{
    partial class PregledOcena
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
            oceneDgv = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            filterGroupBox = new GroupBox();
            usmeniCB = new CheckBox();
            pisanaCB = new CheckBox();
            zakljucnaCB = new CheckBox();
            aktivnostCB = new CheckBox();
            polugodjeGB = new GroupBox();
            drugoCB = new CheckBox();
            prvoCB = new CheckBox();
            datumOdDtp = new DateTimePicker();
            datumDoDtp = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dodajOcenuBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)oceneDgv).BeginInit();
            filterGroupBox.SuspendLayout();
            polugodjeGB.SuspendLayout();
            SuspendLayout();
            // 
            // oceneDgv
            // 
            oceneDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oceneDgv.Location = new Point(12, 141);
            oceneDgv.Name = "oceneDgv";
            oceneDgv.Size = new Size(285, 367);
            oceneDgv.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(309, 170);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 1;
            button1.Text = "Obrisi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(309, 199);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 2;
            button2.Text = "Izmeni ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // filterGroupBox
            // 
            filterGroupBox.Controls.Add(usmeniCB);
            filterGroupBox.Controls.Add(pisanaCB);
            filterGroupBox.Controls.Add(zakljucnaCB);
            filterGroupBox.Controls.Add(aktivnostCB);
            filterGroupBox.Location = new Point(12, 6);
            filterGroupBox.Name = "filterGroupBox";
            filterGroupBox.Size = new Size(285, 71);
            filterGroupBox.TabIndex = 3;
            filterGroupBox.TabStop = false;
            filterGroupBox.Text = "Tip ocene";
            // 
            // usmeniCB
            // 
            usmeniCB.AutoSize = true;
            usmeniCB.Location = new Point(165, 44);
            usmeniCB.Name = "usmeniCB";
            usmeniCB.Size = new Size(114, 19);
            usmeniCB.TabIndex = 3;
            usmeniCB.Text = "Usmeni odgovor";
            usmeniCB.UseVisualStyleBackColor = true;
            usmeniCB.CheckedChanged += usmeniCB_CheckedChanged;
            // 
            // pisanaCB
            // 
            pisanaCB.AutoSize = true;
            pisanaCB.Location = new Point(165, 19);
            pisanaCB.Name = "pisanaCB";
            pisanaCB.Size = new Size(103, 19);
            pisanaCB.TabIndex = 2;
            pisanaCB.Text = "Pisana provera";
            pisanaCB.UseVisualStyleBackColor = true;
            pisanaCB.CheckedChanged += pisanaCB_CheckedChanged;
            // 
            // zakljucnaCB
            // 
            zakljucnaCB.AutoSize = true;
            zakljucnaCB.Location = new Point(6, 44);
            zakljucnaCB.Name = "zakljucnaCB";
            zakljucnaCB.Size = new Size(77, 19);
            zakljucnaCB.TabIndex = 1;
            zakljucnaCB.Text = "Zakljucna";
            zakljucnaCB.UseVisualStyleBackColor = true;
            zakljucnaCB.CheckedChanged += zakljucnaCB_CheckedChanged;
            // 
            // aktivnostCB
            // 
            aktivnostCB.AutoSize = true;
            aktivnostCB.Location = new Point(6, 20);
            aktivnostCB.Name = "aktivnostCB";
            aktivnostCB.Size = new Size(76, 19);
            aktivnostCB.TabIndex = 0;
            aktivnostCB.Text = "Aktivnost";
            aktivnostCB.UseVisualStyleBackColor = true;
            aktivnostCB.CheckedChanged += aktivnostCB_CheckedChanged;
            // 
            // polugodjeGB
            // 
            polugodjeGB.Controls.Add(drugoCB);
            polugodjeGB.Controls.Add(prvoCB);
            polugodjeGB.Location = new Point(309, 6);
            polugodjeGB.Name = "polugodjeGB";
            polugodjeGB.Size = new Size(121, 71);
            polugodjeGB.TabIndex = 6;
            polugodjeGB.TabStop = false;
            polugodjeGB.Text = "Polugodje";
            // 
            // drugoCB
            // 
            drugoCB.AutoSize = true;
            drugoCB.Location = new Point(6, 44);
            drugoCB.Name = "drugoCB";
            drugoCB.Size = new Size(59, 19);
            drugoCB.TabIndex = 2;
            drugoCB.Text = "Drugo";
            drugoCB.UseVisualStyleBackColor = true;
            drugoCB.CheckedChanged += drugoCB_CheckedChanged;
            // 
            // prvoCB
            // 
            prvoCB.AutoSize = true;
            prvoCB.Location = new Point(6, 19);
            prvoCB.Name = "prvoCB";
            prvoCB.Size = new Size(50, 19);
            prvoCB.TabIndex = 1;
            prvoCB.Text = "Prvo";
            prvoCB.UseVisualStyleBackColor = true;
            prvoCB.CheckedChanged += prvoCB_CheckedChanged;
            // 
            // datumOdDtp
            // 
            datumOdDtp.Location = new Point(97, 83);
            datumOdDtp.Name = "datumOdDtp";
            datumOdDtp.Size = new Size(200, 23);
            datumOdDtp.TabIndex = 7;
            datumOdDtp.ValueChanged += datumOdDtp_ValueChanged;
            // 
            // datumDoDtp
            // 
            datumDoDtp.Location = new Point(97, 112);
            datumDoDtp.Name = "datumDoDtp";
            datumDoDtp.Size = new Size(200, 23);
            datumDoDtp.TabIndex = 8;
            datumDoDtp.ValueChanged += datumDoDtp_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 89);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 9;
            label1.Text = "Datum od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 118);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 10;
            label2.Text = "Datum do:";
            // 
            // dodajOcenuBtn
            // 
            dodajOcenuBtn.Location = new Point(309, 141);
            dodajOcenuBtn.Name = "dodajOcenuBtn";
            dodajOcenuBtn.Size = new Size(127, 23);
            dodajOcenuBtn.TabIndex = 11;
            dodajOcenuBtn.Text = "Dodaj";
            dodajOcenuBtn.UseVisualStyleBackColor = true;
            dodajOcenuBtn.Click += dodajOcenuBtn_Click;
            // 
            // PregledOcena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 520);
            Controls.Add(dodajOcenuBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumDoDtp);
            Controls.Add(datumOdDtp);
            Controls.Add(polugodjeGB);
            Controls.Add(filterGroupBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(oceneDgv);
            Name = "PregledOcena";
            Text = "PregledOcena";
            Load += PregledOcena_Load;
            ((System.ComponentModel.ISupportInitialize)oceneDgv).EndInit();
            filterGroupBox.ResumeLayout(false);
            filterGroupBox.PerformLayout();
            polugodjeGB.ResumeLayout(false);
            polugodjeGB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView oceneDgv;
        private Button button1;
        private Button button2;
        private GroupBox filterGroupBox;
        private GroupBox polugodjeGB;
        private DateTimePicker datumOdDtp;
        private DateTimePicker datumDoDtp;
        private Label label1;
        private Label label2;
        private CheckBox aktivnostCB;
        private CheckBox drugoCB;
        private CheckBox prvoCB;
        private CheckBox usmeniCB;
        private CheckBox pisanaCB;
        private CheckBox zakljucnaCB;
        private Button dodajOcenuBtn;
    }
}