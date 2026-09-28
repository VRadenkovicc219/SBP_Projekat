namespace Skoslki_dnevnik.Forme
{
    partial class KreirajOdeljenjeForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            razredNum = new NumericUpDown();
            label1 = new Label();
            kreirajBtn = new Button();
            label2 = new Label();
            Razred = new Label();
            ((System.ComponentModel.ISupportInitialize)razredNum).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(123, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(123, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(120, 23);
            textBox2.TabIndex = 1;
            // 
            // razredNum
            // 
            razredNum.Location = new Point(206, 70);
            razredNum.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            razredNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            razredNum.Name = "razredNum";
            razredNum.Size = new Size(37, 23);
            razredNum.TabIndex = 2;
            razredNum.TextAlign = HorizontalAlignment.Right;
            razredNum.ThousandsSeparator = true;
            razredNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 3;
            label1.Text = "Oznaka";
            // 
            // kreirajBtn
            // 
            kreirajBtn.Location = new Point(89, 165);
            kreirajBtn.Name = "kreirajBtn";
            kreirajBtn.Size = new Size(75, 23);
            kreirajBtn.TabIndex = 4;
            kreirajBtn.Text = "Kreiraj ";
            kreirajBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 5;
            label2.Text = "Skolska godina";
            // 
            // Razred
            // 
            Razred.AutoSize = true;
            Razred.Location = new Point(12, 72);
            Razred.Name = "Razred";
            Razred.Size = new Size(42, 15);
            Razred.TabIndex = 6;
            Razred.Text = "Razred";
            // 
            // KreirajOdeljenjeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 200);
            Controls.Add(Razred);
            Controls.Add(label2);
            Controls.Add(kreirajBtn);
            Controls.Add(label1);
            Controls.Add(razredNum);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "KreirajOdeljenjeForm";
            Text = "KreirajOdeljenjeForm";
            ((System.ComponentModel.ISupportInitialize)razredNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private NumericUpDown razredNum;
        private Label label1;
        private Button kreirajBtn;
        private Label label2;
        private Label Razred;
    }
}