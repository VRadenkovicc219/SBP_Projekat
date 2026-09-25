namespace Skoslki_dnevnik.Forme
{
    partial class DodelaPredmetaFrom
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
            predmetiOdabirDgv = new DataGridView();
            dodeliBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)predmetiOdabirDgv).BeginInit();
            SuspendLayout();
            // 
            // predmetiOdabirDgv
            // 
            predmetiOdabirDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predmetiOdabirDgv.Location = new Point(12, 12);
            predmetiOdabirDgv.Name = "predmetiOdabirDgv";
            predmetiOdabirDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            predmetiOdabirDgv.Size = new Size(352, 426);
            predmetiOdabirDgv.TabIndex = 0;
            predmetiOdabirDgv.SelectionChanged += predmetiOdabirDgv_SelectionChanged;
            // 
            // dodeliBtn
            // 
            dodeliBtn.Location = new Point(147, 511);
            dodeliBtn.Name = "dodeliBtn";
            dodeliBtn.Size = new Size(75, 23);
            dodeliBtn.TabIndex = 1;
            dodeliBtn.Text = "Dodeli";
            dodeliBtn.UseVisualStyleBackColor = true;
            dodeliBtn.Click += dodeliBtn_Click;
            // 
            // DodelaPredmetaFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 546);
            Controls.Add(dodeliBtn);
            Controls.Add(predmetiOdabirDgv);
            Name = "DodelaPredmetaFrom";
            Text = "DodelaPredmetaFrom";
            Load += DodelaPredmetaFrom_Load;
            ((System.ComponentModel.ISupportInitialize)predmetiOdabirDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView predmetiOdabirDgv;
        private Button dodeliBtn;
    }
}