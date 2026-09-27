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
            button2 = new Button();
            button1 = new Button();
            oceneDgv = new DataGridView();
            dodajOcenuBtn = new Button();
            label2 = new Label();
            label1 = new Label();
            datumDoDtp = new DateTimePicker();
            datumOdDtp = new DateTimePicker();
            opravdaniCB = new CheckBox();
            neopravdaniCB = new CheckBox();
            tipCheckedListBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)oceneDgv).BeginInit();
            tipCheckedListBox.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(392, 114);
            button2.Name = "button2";
            button2.Size = new Size(130, 23);
            button2.TabIndex = 14;
            button2.Text = "Izmeni ";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(392, 143);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 13;
            button1.Text = "Obrisi";
            button1.UseVisualStyleBackColor = true;
            // 
            // oceneDgv
            // 
            oceneDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oceneDgv.Location = new Point(12, 85);
            oceneDgv.Name = "oceneDgv";
            oceneDgv.Size = new Size(374, 428);
            oceneDgv.TabIndex = 12;
            // 
            // dodajOcenuBtn
            // 
            dodajOcenuBtn.Location = new Point(392, 85);
            dodajOcenuBtn.Name = "dodajOcenuBtn";
            dodajOcenuBtn.Size = new Size(130, 23);
            dodajOcenuBtn.TabIndex = 21;
            dodajOcenuBtn.Text = "Dodaj";
            dodajOcenuBtn.UseVisualStyleBackColor = true;
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
            // 
            // datumOdDtp
            // 
            datumOdDtp.Format = DateTimePickerFormat.Short;
            datumOdDtp.Location = new Point(97, 18);
            datumOdDtp.Name = "datumOdDtp";
            datumOdDtp.Size = new Size(162, 23);
            datumOdDtp.TabIndex = 17;
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
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(oceneDgv);
            Controls.Add(dodajOcenuBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(datumDoDtp);
            Controls.Add(datumOdDtp);
            Name = "PregledIzostanaka";
            Text = "PregledIzostanaka";
            Load += PregledIzostanaka_Load;
            ((System.ComponentModel.ISupportInitialize)oceneDgv).EndInit();
            tipCheckedListBox.ResumeLayout(false);
            tipCheckedListBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private DataGridView oceneDgv;
        private Button dodajOcenuBtn;
        private Label label2;
        private Label label1;
        private DateTimePicker datumDoDtp;
        private DateTimePicker datumOdDtp;
        private CheckBox opravdaniCB;
        private CheckBox neopravdaniCB;
        private GroupBox tipCheckedListBox;
    }
}