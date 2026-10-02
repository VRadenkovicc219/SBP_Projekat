namespace Skoslki_dnevnik.Forme.odeljenja
{
    partial class Ocene
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
            ((System.ComponentModel.ISupportInitialize)oceneDgv).BeginInit();
            SuspendLayout();
            // 
            // oceneDgv
            // 
            oceneDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oceneDgv.Location = new Point(12, 12);
            oceneDgv.MultiSelect = false;
            oceneDgv.Name = "oceneDgv";
            oceneDgv.ReadOnly = true;
            oceneDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oceneDgv.Size = new Size(314, 369);
            oceneDgv.TabIndex = 0;
            // 
            // Ocene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 386);
            Controls.Add(oceneDgv);
            Name = "Ocene";
            Text = "Ocene";
            Load += Ocene_Load;
            ((System.ComponentModel.ISupportInitialize)oceneDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView oceneDgv;
    }
}