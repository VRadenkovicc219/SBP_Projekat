namespace Skoslki_dnevnik.Forme.nastavnici
{
    partial class DodelaRazrednogOdeljenju
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
            odeljenjaDgv = new DataGridView();
            dodajBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)odeljenjaDgv).BeginInit();
            SuspendLayout();
            // 
            // odeljenjaDgv
            // 
            odeljenjaDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            odeljenjaDgv.Location = new Point(12, 12);
            odeljenjaDgv.MultiSelect = false;
            odeljenjaDgv.Name = "odeljenjaDgv";
            odeljenjaDgv.ReadOnly = true;
            odeljenjaDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            odeljenjaDgv.Size = new Size(274, 395);
            odeljenjaDgv.TabIndex = 0;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(112, 415);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 1;
            dodajBtn.Text = "dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // DodelaRazrednogOdeljenju
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 450);
            Controls.Add(dodajBtn);
            Controls.Add(odeljenjaDgv);
            Name = "DodelaRazrednogOdeljenju";
            Text = "DodelaRazrednogOdeljenju";
            Load += DodelaRazrednogOdeljenju_Load;
            ((System.ComponentModel.ISupportInitialize)odeljenjaDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView odeljenjaDgv;
        private Button dodajBtn;
    }
}