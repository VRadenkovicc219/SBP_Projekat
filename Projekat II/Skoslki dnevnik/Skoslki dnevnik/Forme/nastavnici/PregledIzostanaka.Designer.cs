namespace Skoslki_dnevnik.Forme
{
    partial class PregledIzostanaka
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
            izmeniBtn = new Button();
            obrisiBtn = new Button();
            izostanciDgv = new DataGridView();
            dodajIzostanakBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            datumDoDtp = new DateTimePicker();
            datumOdDtp = new DateTimePicker();
            opravdaniCB = new CheckBox();
            neopravdaniCB = new CheckBox();
            tipCheckedListBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)izostanciDgv).BeginInit();
            tipCheckedListBox.SuspendLayout();
            SuspendLayout();
            // 
            // izmeniBtn
            // 
            izmeniBtn.Location = new Point(392, 114);
            izmeniBtn.Name = "izmeniBtn";
            izmeniBtn.Size = new Size(130, 23);
            izmeniBtn.TabIndex = 14;
            izmeniBtn.Text = "Izmeni ";
            izmeniBtn.UseVisualStyleBackColor = true;
            izmeniBtn.Click += izmeniBtn_Click;
            // 
            // obrisiBtn
            // 
            obrisiBtn.Location = new Point(392, 143);
            obrisiBtn.Name = "obrisiBtn";
            obrisiBtn.Size = new Size(130, 23);
            obrisiBtn.TabIndex = 13;
            obrisiBtn.Text = "Obrisi";
            obrisiBtn.UseVisualStyleBackColor = true;
            obrisiBtn.Click += obrisiBtn_Click;
            // 
            // izostanciDgv
            // 
            izostanciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            izostanciDgv.Location = new Point(12, 85);
            izostanciDgv.MultiSelect = false;
            izostanciDgv.Name = "izostanciDgv";
            izostanciDgv.ReadOnly = true;
            izostanciDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            izostanciDgv.Size = new Size(374, 428);
            izostanciDgv.TabIndex = 12;
            // 
            // dodajIzostanakBtn
            // 
            dodajIzostanakBtn.Location = new Point(392, 85);
            dodajIzostanakBtn.Name = "dodajIzostanakBtn";
            dodajIzostanakBtn.Size = new Size(130, 23);
            dodajIzostanakBtn.TabIndex = 21;
            dodajIzostanakBtn.Text = "Dodaj";
            dodajIzostanakBtn.UseVisualStyleBackColor = true;
            dodajIzostanakBtn.Click += dodajIzostanakBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 20;
            label2.Text = "Datum do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 19;
            label1.Text = "Datum od:";
            // 
            // datumDoDtp
            // 
            datumDoDtp.Format = DateTimePickerFormat.Short;
            datumDoDtp.Location = new Point(97, 47);
            datumDoDtp.Name = "datumDoDtp";
            datumDoDtp.Size = new Size(162, 23);
            datumDoDtp.TabIndex = 18;
            datumDoDtp.ValueChanged += datumDoDtp_ValueChanged;
            // 
            // datumOdDtp
            // 
            datumOdDtp.Format = DateTimePickerFormat.Short;
            datumOdDtp.Location = new Point(97, 18);
            datumOdDtp.Name = "datumOdDtp";
            datumOdDtp.Size = new Size(162, 23);
            datumOdDtp.TabIndex = 17;
            datumOdDtp.ValueChanged += datumOdDtp_ValueChanged;
            // 
            // opravdaniCB
            // 
            opravdaniCB.AutoSize = true;
            opravdaniCB.Location = new Point(6, 22);
            opravdaniCB.Name = "opravdaniCB";
            opravdaniCB.Size = new Size(81, 19);
            opravdaniCB.TabIndex = 0;
            opravdaniCB.Text = "Opravdani";
            opravdaniCB.UseVisualStyleBackColor = true;
            opravdaniCB.CheckedChanged += opravdaniCB_CheckedChanged;
            // 
            // neopravdaniCB
            // 
            neopravdaniCB.AutoSize = true;
            neopravdaniCB.Location = new Point(6, 46);
            neopravdaniCB.Name = "neopravdaniCB";
            neopravdaniCB.Size = new Size(94, 19);
            neopravdaniCB.TabIndex = 1;
            neopravdaniCB.Text = "Neopravdani";
            neopravdaniCB.UseVisualStyleBackColor = true;
            neopravdaniCB.CheckedChanged += neopravdaniCB_CheckedChanged;
            // 
            // tipCheckedListBox
            // 
            tipCheckedListBox.Controls.Add(neopravdaniCB);
            tipCheckedListBox.Controls.Add(opravdaniCB);
            tipCheckedListBox.Location = new Point(265, 12);
            tipCheckedListBox.Name = "tipCheckedListBox";
            tipCheckedListBox.Size = new Size(121, 67);
            tipCheckedListBox.TabIndex = 15;
            tipCheckedListBox.TabStop = false;
            tipCheckedListBox.Text = "Tip izostanka";
            // 
            // PregledIzostanaka
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 530);
            Controls.Add(tipCheckedListBox);
            Controls.Add(izmeniBtn);
            Controls.Add(obrisiBtn);
            Controls.Add(izostanciDgv);
            Controls.Add(dodajIzostanakBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumDoDtp);
            Controls.Add(datumOdDtp);
            Name = "PregledIzostanaka";
            Text = "PregledIzostanaka";
            Load += PregledIzostanaka_Load;
            ((System.ComponentModel.ISupportInitialize)izostanciDgv).EndInit();
            tipCheckedListBox.ResumeLayout(false);
            tipCheckedListBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button izmeniBtn;
        private Button obrisiBtn;
        private DataGridView izostanciDgv;
        private Button dodajIzostanakBtn;
        private Label label2;
        private Label label1;
        private DateTimePicker datumDoDtp;
        private DateTimePicker datumOdDtp;
        private CheckBox opravdaniCB;
        private CheckBox neopravdaniCB;
        private GroupBox tipCheckedListBox;
    }
}