namespace Skoslki_dnevnik.Forme
{
    partial class DodajUcenikaForma
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            JMBG_tb = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            Imel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(174, 326);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(140, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(140, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(264, 23);
            textBox2.TabIndex = 2;
            // 
            // JMBG_tb
            // 
            JMBG_tb.Location = new Point(140, 80);
            JMBG_tb.Name = "JMBG_tb";
            JMBG_tb.Size = new Size(264, 23);
            JMBG_tb.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(140, 109);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(264, 23);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(140, 167);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(264, 23);
            textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(140, 138);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(264, 23);
            textBox6.TabIndex = 6;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(140, 193);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(37, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "M";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(183, 193);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(33, 19);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Z";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Imel
            // 
            Imel.AutoSize = true;
            Imel.Location = new Point(15, 25);
            Imel.Name = "Imel";
            Imel.Size = new Size(33, 15);
            Imel.TabIndex = 10;
            Imel.Text = "Ime: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 11;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 83);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(37, 15);
            label3.TabIndex = 12;
            label3.Text = "JMBG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 112);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 13;
            label4.Text = "Adresa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 141);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 14;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 170);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 15;
            label6.Text = "Dodattni komentar";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 193);
            label7.Name = "label7";
            label7.Size = new Size(27, 15);
            label7.TabIndex = 16;
            label7.Text = "Pol:";
            // 
            // DodajUcenikaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 361);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Imel);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(JMBG_tb);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "DodajUcenikaForma";
            Text = "DodajUcenikaForma";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox JMBG_tb;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label Imel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}