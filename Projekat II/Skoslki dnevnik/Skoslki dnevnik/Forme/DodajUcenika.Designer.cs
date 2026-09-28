namespace Skoslki_dnevnik.Forme
{
    partial class DodajUcenika
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
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).BeginInit();
            SuspendLayout();
            // 
            // uceniciDgv
            // 
            uceniciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uceniciDgv.Location = new Point(12, 12);
            uceniciDgv.Name = "uceniciDgv";
            uceniciDgv.Size = new Size(423, 499);
            uceniciDgv.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(187, 517);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            // 
            // DodajUcenika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 552);
            Controls.Add(button1);
            Controls.Add(uceniciDgv);
            Name = "DodajUcenika";
            Text = "DodajUcenika";
            ((System.ComponentModel.ISupportInitialize)uceniciDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView uceniciDgv;
        private Button button1;
    }
}