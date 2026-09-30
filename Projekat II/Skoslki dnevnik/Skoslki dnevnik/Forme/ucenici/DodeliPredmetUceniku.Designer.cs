namespace Skoslki_dnevnik.Forme
{
    partial class DodeliPredmetUceniku
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
            predmetiDGV = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)predmetiDGV).BeginInit();
            SuspendLayout();
            // 
            // predmetiDGV
            // 
            predmetiDGV.AllowUserToAddRows = false;
            predmetiDGV.AllowUserToDeleteRows = false;
            predmetiDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predmetiDGV.ImeMode = ImeMode.NoControl;
            predmetiDGV.Location = new Point(12, 12);
            predmetiDGV.Name = "predmetiDGV";
            predmetiDGV.ReadOnly = true;
            predmetiDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            predmetiDGV.Size = new Size(336, 426);
            predmetiDGV.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(144, 461);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DodeliPredmetUceniku
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 496);
            Controls.Add(button1);
            Controls.Add(predmetiDGV);
            Name = "DodeliPredmetUceniku";
            Text = "DodeliPredmetUceniku";
            Load += DodeliPredmetUceniku_Load;
            ((System.ComponentModel.ISupportInitialize)predmetiDGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView predmetiDGV;
        private Button button1;
    }
}