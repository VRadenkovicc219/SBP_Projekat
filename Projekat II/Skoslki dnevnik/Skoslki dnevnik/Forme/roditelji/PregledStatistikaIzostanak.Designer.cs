namespace Skoslki_dnevnik.Forme
{
    partial class PregledStatistikaIzostanak
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
            skoslkaGodinaCmb = new ComboBox();
            statistikaDgv = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            datumDoDtp = new DateTimePicker();
            datumOdDtp = new DateTimePicker();
            tipCheckedListBox = new GroupBox();
            neopravdaniCB = new CheckBox();
            opravdaniCB = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)statistikaDgv).BeginInit();
            tipCheckedListBox.SuspendLayout();
            SuspendLayout();
            // 
            // skoslkaGodinaCmb
            // 
            skoslkaGodinaCmb.FormattingEnabled = true;
            skoslkaGodinaCmb.Location = new Point(12, 78);
            skoslkaGodinaCmb.Name = "skoslkaGodinaCmb";
            skoslkaGodinaCmb.Size = new Size(401, 23);
            skoslkaGodinaCmb.TabIndex = 34;
            skoslkaGodinaCmb.SelectedIndexChanged += skolskaGodinaCmb_SelectedIndexChanged;
            // 
            // statistikaDgv
            // 
            statistikaDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            statistikaDgv.Location = new Point(12, 107);
            statistikaDgv.Name = "statistikaDgv";
            statistikaDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            statistikaDgv.Size = new Size(401, 470);
            statistikaDgv.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 52);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 33;
            label2.Text = "Datum do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 27);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 32;
            label1.Text = "Datum od:";
            // 
            // datumDoDtp
            // 
            datumDoDtp.Format = DateTimePickerFormat.Short;
            datumDoDtp.Location = new Point(79, 46);
            datumDoDtp.Name = "datumDoDtp";
            datumDoDtp.Size = new Size(99, 23);
            datumDoDtp.TabIndex = 31;
            datumDoDtp.ValueChanged += datumDoDtp_ValueChanged;
            // 
            // datumOdDtp
            // 
            datumOdDtp.Format = DateTimePickerFormat.Short;
            datumOdDtp.Location = new Point(79, 21);
            datumOdDtp.Name = "datumOdDtp";
            datumOdDtp.Size = new Size(99, 23);
            datumOdDtp.TabIndex = 30;
            datumOdDtp.ValueChanged += datumOdDtp_ValueChanged;
            // 
            // tipCheckedListBox
            // 
            tipCheckedListBox.Controls.Add(neopravdaniCB);
            tipCheckedListBox.Controls.Add(opravdaniCB);
            tipCheckedListBox.Location = new Point(184, 12);
            tipCheckedListBox.Name = "tipCheckedListBox";
            tipCheckedListBox.Size = new Size(229, 60);
            tipCheckedListBox.TabIndex = 35;
            tipCheckedListBox.TabStop = false;
            tipCheckedListBox.Text = "Tip izostanka";
            // 
            // neopravdaniCB
            // 
            neopravdaniCB.AutoSize = true;
            neopravdaniCB.Location = new Point(129, 26);
            neopravdaniCB.Name = "neopravdaniCB";
            neopravdaniCB.Size = new Size(94, 19);
            neopravdaniCB.TabIndex = 1;
            neopravdaniCB.Text = "Neopravdani";
            neopravdaniCB.UseVisualStyleBackColor = true;
            neopravdaniCB.CheckedChanged += neopravdaniCb_CheckedChanged;
            // 
            // opravdaniCB
            // 
            opravdaniCB.AutoSize = true;
            opravdaniCB.Location = new Point(6, 26);
            opravdaniCB.Name = "opravdaniCB";
            opravdaniCB.Size = new Size(81, 19);
            opravdaniCB.TabIndex = 0;
            opravdaniCB.Text = "Opravdani";
            opravdaniCB.UseVisualStyleBackColor = true;
            opravdaniCB.CheckedChanged += opravdaniCb_CheckedChanged;
            // 
            // PregledStatistikaIzostanak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 598);
            Controls.Add(tipCheckedListBox);
            Controls.Add(skoslkaGodinaCmb);
            Controls.Add(statistikaDgv);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumDoDtp);
            Controls.Add(datumOdDtp);
            Name = "PregledStatistikaIzostanak";
            Text = "PregledStatistikaIzostanak";
            Load += PregledStatistikaIzostanak_Load_1;
            ((System.ComponentModel.ISupportInitialize)statistikaDgv).EndInit();
            tipCheckedListBox.ResumeLayout(false);
            tipCheckedListBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox skoslkaGodinaCmb;
        private DataGridView statistikaDgv;
        private Label label2;
        private Label label1;
        private DateTimePicker datumDoDtp;
        private DateTimePicker datumOdDtp;
        private GroupBox tipCheckedListBox;
        private CheckBox neopravdaniCB;
        private CheckBox opravdaniCB;
    }
}