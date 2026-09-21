namespace Skoslki_dnevnik.Forme
{
    partial class DodajTelefonForm
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
            acceptBtn = new Button();
            dataGridView1 = new DataGridView();
            unesiTelefonBtn = new Button();
            obrisiBtn = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // acceptBtn
            // 
            acceptBtn.Location = new Point(127, 219);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(132, 23);
            acceptBtn.TabIndex = 0;
            acceptBtn.Text = "Prihvati izmene";
            acceptBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(232, 198);
            dataGridView1.TabIndex = 1;
            // 
            // unesiTelefonBtn
            // 
            unesiTelefonBtn.Location = new Point(250, 12);
            unesiTelefonBtn.Name = "unesiTelefonBtn";
            unesiTelefonBtn.Size = new Size(124, 23);
            unesiTelefonBtn.TabIndex = 2;
            unesiTelefonBtn.Text = "Unesi broj";
            unesiTelefonBtn.UseVisualStyleBackColor = true;
            // 
            // obrisiBtn
            // 
            obrisiBtn.Location = new Point(250, 41);
            obrisiBtn.Name = "obrisiBtn";
            obrisiBtn.Size = new Size(124, 23);
            obrisiBtn.TabIndex = 3;
            obrisiBtn.Text = "Obrisi";
            obrisiBtn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(250, 70);
            button2.Name = "button2";
            button2.Size = new Size(124, 23);
            button2.TabIndex = 4;
            button2.Text = "Izmeni";
            button2.UseVisualStyleBackColor = true;
            // 
            // DodajTelefonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 254);
            Controls.Add(button2);
            Controls.Add(obrisiBtn);
            Controls.Add(unesiTelefonBtn);
            Controls.Add(dataGridView1);
            Controls.Add(acceptBtn);
            Name = "DodajTelefonForm";
            Text = "DodajTelefonForm";
            Load += DodajTelefonForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button acceptBtn;
        private DataGridView dataGridView1;
        private Button unesiTelefonBtn;
        private Button obrisiBtn;
        private Button button2;
    }
}