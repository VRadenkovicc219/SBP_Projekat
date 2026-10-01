namespace Skoslki_dnevnik.Forme.nastavnici
{
    partial class UlogaNastavnika
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
            razredniBtn = new Button();
            dodajSSaradnika = new Button();
            dodajRukovodecegBtn = new Button();
            SuspendLayout();
            // 
            // razredniBtn
            // 
            razredniBtn.Location = new Point(12, 12);
            razredniBtn.Name = "razredniBtn";
            razredniBtn.Size = new Size(480, 23);
            razredniBtn.TabIndex = 0;
            razredniBtn.Text = "dodaj razrednog";
            razredniBtn.UseVisualStyleBackColor = true;
            razredniBtn.Click += razredniBtn_Click;
            // 
            // dodajSSaradnika
            // 
            dodajSSaradnika.Location = new Point(12, 41);
            dodajSSaradnika.Name = "dodajSSaradnika";
            dodajSSaradnika.Size = new Size(480, 23);
            dodajSSaradnika.TabIndex = 1;
            dodajSSaradnika.Text = "dodaj strucnog saradnika";
            dodajSSaradnika.UseVisualStyleBackColor = true;
            dodajSSaradnika.Click += dodajSSaradnika_Click;
            // 
            // dodajRukovodecegBtn
            // 
            dodajRukovodecegBtn.Location = new Point(12, 70);
            dodajRukovodecegBtn.Name = "dodajRukovodecegBtn";
            dodajRukovodecegBtn.Size = new Size(480, 27);
            dodajRukovodecegBtn.TabIndex = 2;
            dodajRukovodecegBtn.Text = "dodaj rukovodeci organ";
            dodajRukovodecegBtn.UseVisualStyleBackColor = true;
            dodajRukovodecegBtn.Click += button3_Click;
            // 
            // UlogaNastavnika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 108);
            Controls.Add(dodajRukovodecegBtn);
            Controls.Add(dodajSSaradnika);
            Controls.Add(razredniBtn);
            Name = "UlogaNastavnika";
            Text = "UlogaNastavnika";
            ResumeLayout(false);
        }

        #endregion

        private Button razredniBtn;
        private Button dodajSSaradnika;
        private Button dodajRukovodecegBtn;
    }
}