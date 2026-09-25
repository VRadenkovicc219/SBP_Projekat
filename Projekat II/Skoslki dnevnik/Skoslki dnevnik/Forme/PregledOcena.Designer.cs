namespace Skoslki_dnevnik.Forme
{
    partial class PregledOcena
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            filterGroupBox = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            prvoPRB = new RadioButton();
            drugoPRB = new RadioButton();
            polugodjeGB = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            filterGroupBox.SuspendLayout();
            polugodjeGB.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(285, 367);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(309, 141);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 1;
            button1.Text = "Obrisi";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(309, 170);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 2;
            button2.Text = "Izmeni ";
            button2.UseVisualStyleBackColor = true;
            // 
            // filterGroupBox
            // 
            filterGroupBox.Controls.Add(radioButton4);
            filterGroupBox.Controls.Add(radioButton3);
            filterGroupBox.Controls.Add(radioButton2);
            filterGroupBox.Controls.Add(radioButton1);
            filterGroupBox.Location = new Point(12, 6);
            filterGroupBox.Name = "filterGroupBox";
            filterGroupBox.Size = new Size(285, 71);
            filterGroupBox.TabIndex = 3;
            filterGroupBox.TabStop = false;
            filterGroupBox.Text = "Tip ocene";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(75, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Aktivnost";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(166, 19);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(113, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Usmeni odgovor";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 44);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(102, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Pisana provera";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(166, 44);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(79, 19);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "Zakljucna ";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // prvoPRB
            // 
            prvoPRB.AutoSize = true;
            prvoPRB.Location = new Point(12, 19);
            prvoPRB.Name = "prvoPRB";
            prvoPRB.Size = new Size(49, 19);
            prvoPRB.TabIndex = 4;
            prvoPRB.TabStop = true;
            prvoPRB.Text = "Prvo";
            prvoPRB.UseVisualStyleBackColor = true;
            // 
            // drugoPRB
            // 
            drugoPRB.AutoSize = true;
            drugoPRB.Location = new Point(12, 44);
            drugoPRB.Name = "drugoPRB";
            drugoPRB.Size = new Size(58, 19);
            drugoPRB.TabIndex = 5;
            drugoPRB.TabStop = true;
            drugoPRB.Text = "Drugo";
            drugoPRB.UseVisualStyleBackColor = true;
            // 
            // polugodjeGB
            // 
            polugodjeGB.Controls.Add(drugoPRB);
            polugodjeGB.Controls.Add(prvoPRB);
            polugodjeGB.Location = new Point(309, 6);
            polugodjeGB.Name = "polugodjeGB";
            polugodjeGB.Size = new Size(121, 71);
            polugodjeGB.TabIndex = 6;
            polugodjeGB.TabStop = false;
            polugodjeGB.Text = "Polugodje";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(97, 83);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(97, 112);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 89);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 9;
            label1.Text = "Datum od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 118);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 10;
            label2.Text = "Datum do:";
            // 
            // PregledOcena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 520);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(polugodjeGB);
            Controls.Add(filterGroupBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "PregledOcena";
            Text = "PregledOcena";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            filterGroupBox.ResumeLayout(false);
            filterGroupBox.PerformLayout();
            polugodjeGB.ResumeLayout(false);
            polugodjeGB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private GroupBox filterGroupBox;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton prvoPRB;
        private RadioButton drugoPRB;
        private GroupBox polugodjeGB;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
    }
}