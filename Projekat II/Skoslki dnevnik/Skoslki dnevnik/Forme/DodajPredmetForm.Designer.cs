namespace Skoslki_dnevnik.Forme
{
    partial class DodajPredmetForm
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
            label1 = new Label();
            nazivTxt = new TextBox();
            skolskaGodinaTxt = new TextBox();
            label2 = new Label();
            razredTxt = new TextBox();
            label3 = new Label();
            fondTxt = new TextBox();
            label4 = new Label();
            Opis = new Label();
            label6 = new Label();
            label7 = new Label();
            tipCb = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            komentarTxt = new RichTextBox();
            OpisTxt = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv";
            // 
            // nazivTxt
            // 
            nazivTxt.Location = new Point(130, 6);
            nazivTxt.Name = "nazivTxt";
            nazivTxt.Size = new Size(197, 23);
            nazivTxt.TabIndex = 1;
            // 
            // skolskaGodinaTxt
            // 
            skolskaGodinaTxt.Location = new Point(130, 35);
            skolskaGodinaTxt.Name = "skolskaGodinaTxt";
            skolskaGodinaTxt.Size = new Size(197, 23);
            skolskaGodinaTxt.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Skoslka godina";
            // 
            // razredTxt
            // 
            razredTxt.Location = new Point(130, 64);
            razredTxt.Name = "razredTxt";
            razredTxt.Size = new Size(197, 23);
            razredTxt.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 4;
            label3.Text = "Razred";
            // 
            // fondTxt
            // 
            fondTxt.Location = new Point(130, 93);
            fondTxt.Name = "fondTxt";
            fondTxt.Size = new Size(197, 23);
            fondTxt.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Nedeljni fond";
            // 
            // Opis
            // 
            Opis.AutoSize = true;
            Opis.Location = new Point(12, 125);
            Opis.Name = "Opis";
            Opis.Size = new Size(86, 15);
            Opis.TabIndex = 8;
            Opis.Text = "Opis (opciono)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 154);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 10;
            label6.Text = "Komentar (opciono)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 183);
            label7.Name = "label7";
            label7.Size = new Size(24, 15);
            label7.TabIndex = 12;
            label7.Text = "Tip";
            // 
            // tipCb
            // 
            tipCb.FormattingEnabled = true;
            tipCb.Location = new Point(130, 180);
            tipCb.Name = "tipCb";
            tipCb.Size = new Size(197, 23);
            tipCb.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(97, 249);
            button1.Name = "button1";
            button1.Size = new Size(152, 35);
            button1.TabIndex = 14;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(130, 209);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 15;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(249, 208);
            button3.Name = "button3";
            button3.Size = new Size(78, 24);
            button3.TabIndex = 16;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // komentarTxt
            // 
            komentarTxt.Location = new Point(130, 151);
            komentarTxt.Name = "komentarTxt";
            komentarTxt.Size = new Size(197, 23);
            komentarTxt.TabIndex = 17;
            komentarTxt.Text = "";
            // 
            // OpisTxt
            // 
            OpisTxt.Location = new Point(130, 122);
            OpisTxt.Name = "OpisTxt";
            OpisTxt.Size = new Size(197, 23);
            OpisTxt.TabIndex = 18;
            OpisTxt.Text = "";
            // 
            // DodajPredmetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 296);
            Controls.Add(OpisTxt);
            Controls.Add(komentarTxt);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tipCb);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(Opis);
            Controls.Add(fondTxt);
            Controls.Add(label4);
            Controls.Add(razredTxt);
            Controls.Add(label3);
            Controls.Add(skolskaGodinaTxt);
            Controls.Add(label2);
            Controls.Add(nazivTxt);
            Controls.Add(label1);
            Name = "DodajPredmetForm";
            Text = "DodajPredmetForm";
            Load += DodajPredmetForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nazivTxt;
        private TextBox skolskaGodinaTxt;
        private Label label2;
        private TextBox razredTxt;
        private Label label3;
        private TextBox fondTxt;
        private Label label4;
        private Label Opis;
        private Label label6;
        private Label label7;
        private ComboBox tipCb;
        private Button button1;
        private Button button2;
        private Button button3;
        private RichTextBox komentarTxt;
        private RichTextBox OpisTxt;
    }
}