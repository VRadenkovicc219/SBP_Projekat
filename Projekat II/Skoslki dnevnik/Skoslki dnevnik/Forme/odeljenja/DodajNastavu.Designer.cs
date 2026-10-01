namespace Skoslki_dnevnik.Forme
{
    partial class DodajNastavu
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
            nastavaDgv = new DataGridView();
            dodajBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)nastavaDgv).BeginInit();
            SuspendLayout();
            // 
            // nastavaDgv
            // 
            nastavaDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nastavaDgv.Location = new Point(12, 12);
            nastavaDgv.Name = "nastavaDgv";
            nastavaDgv.ReadOnly = true;
            nastavaDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            nastavaDgv.Size = new Size(379, 483);
            nastavaDgv.TabIndex = 0;
            // 
            // dodajBtn
            // 
            dodajBtn.Location = new Point(159, 501);
            dodajBtn.Name = "dodajBtn";
            dodajBtn.Size = new Size(75, 23);
            dodajBtn.TabIndex = 1;
            dodajBtn.Text = "Dodaj";
            dodajBtn.UseVisualStyleBackColor = true;
            dodajBtn.Click += dodajBtn_Click;
            // 
            // DodajNastavu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 536);
            Controls.Add(dodajBtn);
            Controls.Add(nastavaDgv);
            Name = "DodajNastavu";
            Text = "DodajNastavu";
            Load += DodajNastavu_Load;
            ((System.ComponentModel.ISupportInitialize)nastavaDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView nastavaDgv;
        private Button dodajBtn;
    }
}