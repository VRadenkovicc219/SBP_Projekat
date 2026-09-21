namespace Skoslki_dnevnik
{
    partial class login_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uceniciBtn = new Button();
            nastavniciBtn = new Button();
            odeljenjeBtn = new Button();
            predmetiBtn = new Button();
            roditeljiBtn = new Button();
            SuspendLayout();
            // 
            // uceniciBtn
            // 
            uceniciBtn.Location = new Point(12, 67);
            uceniciBtn.Name = "uceniciBtn";
            uceniciBtn.Size = new Size(246, 23);
            uceniciBtn.TabIndex = 0;
            uceniciBtn.Text = "Ucenici";
            uceniciBtn.UseVisualStyleBackColor = true;
            uceniciBtn.Click += uceniciBtn_Click;
            // 
            // nastavniciBtn
            // 
            nastavniciBtn.Location = new Point(12, 96);
            nastavniciBtn.Name = "nastavniciBtn";
            nastavniciBtn.Size = new Size(246, 23);
            nastavniciBtn.TabIndex = 1;
            nastavniciBtn.Text = "Nastavnici";
            nastavniciBtn.UseVisualStyleBackColor = true;
            nastavniciBtn.Click += nastavniciBtn_Click;
            // 
            // odeljenjeBtn
            // 
            odeljenjeBtn.Location = new Point(12, 125);
            odeljenjeBtn.Name = "odeljenjeBtn";
            odeljenjeBtn.Size = new Size(246, 23);
            odeljenjeBtn.TabIndex = 2;
            odeljenjeBtn.Text = "Odeljenja";
            odeljenjeBtn.UseVisualStyleBackColor = true;
            // 
            // predmetiBtn
            // 
            predmetiBtn.Location = new Point(12, 154);
            predmetiBtn.Name = "predmetiBtn";
            predmetiBtn.Size = new Size(246, 23);
            predmetiBtn.TabIndex = 3;
            predmetiBtn.Text = "Predmeti";
            predmetiBtn.UseVisualStyleBackColor = true;
            // 
            // roditeljiBtn
            // 
            roditeljiBtn.Location = new Point(12, 183);
            roditeljiBtn.Name = "roditeljiBtn";
            roditeljiBtn.Size = new Size(246, 23);
            roditeljiBtn.TabIndex = 4;
            roditeljiBtn.Text = "Roditelji";
            roditeljiBtn.UseVisualStyleBackColor = true;
            // 
            // login_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(272, 261);
            Controls.Add(roditeljiBtn);
            Controls.Add(predmetiBtn);
            Controls.Add(odeljenjeBtn);
            Controls.Add(nastavniciBtn);
            Controls.Add(uceniciBtn);
            Name = "login_form";
            Text = "Skolski dnevnik";
            ResumeLayout(false);
        }

        #endregion

        private Button uceniciBtn;
        private Button nastavniciBtn;
        private Button odeljenjeBtn;
        private Button predmetiBtn;
        private Button roditeljiBtn;
    }
}
