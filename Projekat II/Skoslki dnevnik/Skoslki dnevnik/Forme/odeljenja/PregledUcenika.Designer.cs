namespace Skoslki_dnevnik.Forme.odeljenja
{
    partial class PregledUcenika
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
            izostanciBtn = new Button();
            oceneBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).BeginInit();
            SuspendLayout();
            // 
            // uceniciDgv
            // 
            uceniciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uceniciDgv.Location = new Point(12, 12);
            uceniciDgv.MultiSelect = false;
            uceniciDgv.Name = "uceniciDgv";
            uceniciDgv.ReadOnly = true;
            uceniciDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uceniciDgv.Size = new Size(309, 426);
            uceniciDgv.TabIndex = 0;
            // 
            // izostanciBtn
            // 
            izostanciBtn.Location = new Point(327, 12);
            izostanciBtn.Name = "izostanciBtn";
            izostanciBtn.Size = new Size(177, 23);
            izostanciBtn.TabIndex = 1;
            izostanciBtn.Text = "Pogledaj izostanke";
            izostanciBtn.UseVisualStyleBackColor = true;
            izostanciBtn.Click += izostanciBtn_Click;
            // 
            // oceneBtn
            // 
            oceneBtn.Location = new Point(327, 41);
            oceneBtn.Name = "oceneBtn";
            oceneBtn.Size = new Size(177, 23);
            oceneBtn.TabIndex = 2;
            oceneBtn.Text = "Pogledaj ocene";
            oceneBtn.UseVisualStyleBackColor = true;
            oceneBtn.Click += oceneBtn_Click;
            // 
            // PregledUcenika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 450);
            Controls.Add(oceneBtn);
            Controls.Add(izostanciBtn);
            Controls.Add(uceniciDgv);
            Name = "PregledUcenika";
            Text = "PregledUcenika";
            Load += PregledUcenika_Load;
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView uceniciDgv;
        private Button izostanciBtn;
        private Button oceneBtn;
    }
}