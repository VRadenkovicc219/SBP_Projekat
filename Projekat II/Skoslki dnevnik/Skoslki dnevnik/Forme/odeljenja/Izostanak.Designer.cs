namespace Skoslki_dnevnik.Forme.odeljenja
{
    partial class Izostanak
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
            izostanciDgv = new DataGridView();
            opravdajBtn = new Button();
            neopravdaniChk = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)izostanciDgv).BeginInit();
            SuspendLayout();
            // 
            // izostanciDgv
            // 
            izostanciDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            izostanciDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            izostanciDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            izostanciDgv.Location = new Point(12, 12);
            izostanciDgv.Name = "izostanciDgv";
            izostanciDgv.ReadOnly = true;
            izostanciDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            izostanciDgv.Size = new Size(284, 426);
            izostanciDgv.TabIndex = 0;
            // 
            // opravdajBtn
            // 
            opravdajBtn.Location = new Point(302, 37);
            opravdajBtn.Name = "opravdajBtn";
            opravdajBtn.Size = new Size(147, 33);
            opravdajBtn.TabIndex = 1;
            opravdajBtn.Text = "Opravdaj";
            opravdajBtn.UseVisualStyleBackColor = true;
            opravdajBtn.Click += opravdajBtn_Click;
            // 
            // neopravdaniChk
            // 
            neopravdaniChk.AutoSize = true;
            neopravdaniChk.Location = new Point(302, 12);
            neopravdaniChk.Name = "neopravdaniChk";
            neopravdaniChk.Size = new Size(125, 19);
            neopravdaniChk.TabIndex = 2;
            neopravdaniChk.Text = "Samo neopravdani";
            neopravdaniChk.UseVisualStyleBackColor = true;
            neopravdaniChk.CheckedChanged += neopravdaniChk_CheckedChanged;
            // 
            // Izostanak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 450);
            Controls.Add(neopravdaniChk);
            Controls.Add(opravdajBtn);
            Controls.Add(izostanciDgv);
            Name = "Izostanak";
            Text = "Izostanak";
            Load += Izostanak_Load;
            ((System.ComponentModel.ISupportInitialize)izostanciDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView izostanciDgv;
        private Button opravdajBtn;
        private CheckBox neopravdaniChk;
    }
}