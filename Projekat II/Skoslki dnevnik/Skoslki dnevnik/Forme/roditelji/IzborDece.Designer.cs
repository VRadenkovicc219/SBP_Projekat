namespace Skoslki_dnevnik.Forme.roditelji
{
    partial class IzborDece
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
            uceniciDgv = new DataGridView();
            label3 = new Label();
            jmbgTb = new TextBox();
            dodajBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).BeginInit();
            SuspendLayout();
            // 
            // uceniciDgv
            // 
            uceniciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uceniciDgv.Location = new Point(12, 35);
            uceniciDgv.Name = "uceniciDgv";
            uceniciDgv.ReadOnly = true;
            uceniciDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uceniciDgv.Size = new Size(430, 604);
            uceniciDgv.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(97, 15);
            label3.TabIndex = 20;
            label3.Text = "Pretrazi po jmbg:";
            // 
            // jmbgTb
            // 
            jmbgTb.Location = new Point(131, 6);
            jmbgTb.Name = "jmbgTb";
            jmbgTb.Size = new Size(311, 23);
            jmbgTb.TabIndex = 19;
            jmbgTb.Leave += jmbgTb_Leave;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(186, 658);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 21;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // IzborDece
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 693);
            Controls.Add(dodajBtn);
            Controls.Add(label3);
            Controls.Add(jmbgTb);
            Controls.Add(uceniciDgv);
            Name = "IzborDece";
            Text = "IzborDece";
            Load += IzborDece_Load;
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView uceniciDgv;
        private Label label3;
        private TextBox jmbgTb;
        private Button dodajBtn;
    }
}