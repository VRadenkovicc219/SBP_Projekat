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
            email_tb = new TextBox();
            login_btn = new Button();
            SuspendLayout();
            // 
            // email_tb
            // 
            email_tb.Location = new Point(206, 179);
            email_tb.Name = "email_tb";
            email_tb.PlaceholderText = "example@email.com";
            email_tb.Size = new Size(393, 23);
            email_tb.TabIndex = 0;
            // 
            // login_btn
            // 
            login_btn.Location = new Point(351, 208);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(75, 23);
            login_btn.TabIndex = 1;
            login_btn.Text = "Prijavi se";
            login_btn.UseVisualStyleBackColor = true;
            login_btn.Click += login_btn_Click;
            // 
            // login_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pngtree_back_to_school_chalkboard_with_supplies_and_math_equations_for_classroom_image_16963243;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(807, 450);
            Controls.Add(login_btn);
            Controls.Add(email_tb);
            Name = "login_form";
            Text = "Skolski dnevnik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox email_tb;
        private Button login_btn;
    }
}
