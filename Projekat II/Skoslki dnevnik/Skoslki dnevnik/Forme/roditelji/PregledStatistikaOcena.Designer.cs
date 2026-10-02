namespace Skoslki_dnevnik.Forme
{
    partial class PregledStatistikaOcena
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
            tipCheckedListBox = new GroupBox();
            zakljucnaCb = new CheckBox();
            pisanaProveraCb = new CheckBox();
            usmeniOdgovorCB = new CheckBox();
            aktivnostCB = new CheckBox();
            statistikaDgv = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            datumDoDtp = new DateTimePicker();
            datumOdDtp = new DateTimePicker();
            predmetCmb = new ComboBox();
            tipCheckedListBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)statistikaDgv).BeginInit();
            SuspendLayout();
            // 
            // tipCheckedListBox
            // 
            tipCheckedListBox.Controls.Add(zakljucnaCb);
            tipCheckedListBox.Controls.Add(pisanaProveraCb);
            tipCheckedListBox.Controls.Add(usmeniOdgovorCB);
            tipCheckedListBox.Controls.Add(aktivnostCB);
            tipCheckedListBox.Location = new Point(186, 12);
            tipCheckedListBox.Name = "tipCheckedListBox";
            tipCheckedListBox.Size = new Size(229, 67);
            tipCheckedListBox.TabIndex = 22;
            tipCheckedListBox.TabStop = false;
            tipCheckedListBox.Text = "Tip ocene";
            // 
            // zakljucnaCb
            // 
            zakljucnaCb.AutoSize = true;
            zakljucnaCb.Location = new Point(118, 41);
            zakljucnaCb.Name = "zakljucnaCb";
            zakljucnaCb.Size = new Size(77, 19);
            zakljucnaCb.TabIndex = 3;
            zakljucnaCb.Text = "Zakljucna";
            zakljucnaCb.UseVisualStyleBackColor = true;
            zakljucnaCb.CheckedChanged += zakljucnaCb_CheckedChanged;
            // 
            // pisanaProveraCb
            // 
            pisanaProveraCb.AutoSize = true;
            pisanaProveraCb.Location = new Point(118, 16);
            pisanaProveraCb.Name = "pisanaProveraCb";
            pisanaProveraCb.Size = new Size(103, 19);
            pisanaProveraCb.TabIndex = 2;
            pisanaProveraCb.Text = "Pisana provera";
            pisanaProveraCb.UseVisualStyleBackColor = true;
            pisanaProveraCb.CheckedChanged += pisanaProveraCb_CheckedChanged;
            // 
            // usmeniOdgovorCB
            // 
            usmeniOdgovorCB.AutoSize = true;
            usmeniOdgovorCB.Location = new Point(6, 41);
            usmeniOdgovorCB.Name = "usmeniOdgovorCB";
            usmeniOdgovorCB.Size = new Size(114, 19);
            usmeniOdgovorCB.TabIndex = 1;
            usmeniOdgovorCB.Text = "Usmeni odgovor";
            usmeniOdgovorCB.UseVisualStyleBackColor = true;
            usmeniOdgovorCB.CheckedChanged += usmeniOdgovorCb_CheckedChanged;
            // 
            // aktivnostCB
            // 
            aktivnostCB.AutoSize = true;
            aktivnostCB.Location = new Point(6, 16);
            aktivnostCB.Name = "aktivnostCB";
            aktivnostCB.Size = new Size(76, 19);
            aktivnostCB.TabIndex = 0;
            aktivnostCB.Text = "Aktivnost";
            aktivnostCB.UseVisualStyleBackColor = true;
            aktivnostCB.CheckedChanged += aktivnostCb_CheckedChanged;
            // 
            // statistikaDgv
            // 
            statistikaDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            statistikaDgv.Location = new Point(14, 114);
            statistikaDgv.Name = "statistikaDgv";
            statistikaDgv.Size = new Size(401, 470);
            statistikaDgv.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 26;
            label2.Text = "Datum do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 25;
            label1.Text = "Datum od:";
            // 
            // datumDoDtp
            // 
            datumDoDtp.Format = DateTimePickerFormat.Short;
            datumDoDtp.Location = new Point(81, 53);
            datumDoDtp.Name = "datumDoDtp";
            datumDoDtp.Size = new Size(99, 23);
            datumDoDtp.TabIndex = 24;
            datumDoDtp.ValueChanged += datumDoDtp_ValueChanged;
            // 
            // datumOdDtp
            // 
            datumOdDtp.Format = DateTimePickerFormat.Short;
            datumOdDtp.Location = new Point(81, 28);
            datumOdDtp.Name = "datumOdDtp";
            datumOdDtp.Size = new Size(99, 23);
            datumOdDtp.TabIndex = 23;
            datumOdDtp.ValueChanged += datumOdDtp_ValueChanged;
            // 
            // predmetCmb
            // 
            predmetCmb.FormattingEnabled = true;
            predmetCmb.Location = new Point(14, 85);
            predmetCmb.Name = "predmetCmb";
            predmetCmb.Size = new Size(401, 23);
            predmetCmb.TabIndex = 27;
            predmetCmb.SelectedIndexChanged += predmetCmb_SelectedIndexChanged;
            // 
            // PregledStatistikaOcena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 593);
            Controls.Add(predmetCmb);
            Controls.Add(tipCheckedListBox);
            Controls.Add(statistikaDgv);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumDoDtp);
            Controls.Add(datumOdDtp);
            Name = "PregledStatistikaOcena";
            Text = "Pregled ocena";
            Load += zakljucnaCb_CheckedChanged;
            tipCheckedListBox.ResumeLayout(false);
            tipCheckedListBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)statistikaDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox tipCheckedListBox;
        private CheckBox usmeniOdgovorCB;
        private CheckBox aktivnostCB;
        private DataGridView statistikaDgv;
        private Label label2;
        private Label label1;
        private DateTimePicker datumDoDtp;
        private DateTimePicker datumOdDtp;
        private ComboBox predmetCmb;
        private CheckBox zakljucnaCb;
        private CheckBox pisanaProveraCb;
    }
}