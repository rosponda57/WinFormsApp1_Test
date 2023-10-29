namespace WinFormsApp1
{
    partial class Form1
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
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox2 = new GroupBox();
            btnJezykZmien = new Button();
            rbEn = new RadioButton();
            rbPL = new RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(45, 159);
            button1.Name = "button1";
            button1.Size = new Size(192, 43);
            button1.TabIndex = 0;
            button1.Text = "claSaPoli";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(45, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(49, 67);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(69, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "mono";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(49, 37);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(56, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "db1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(174, 256);
            button2.Name = "button2";
            button2.Size = new Size(176, 29);
            button2.TabIndex = 2;
            button2.Text = "Pokaz  ustawienia";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(174, 339);
            button3.Name = "button3";
            button3.Size = new Size(176, 29);
            button3.TabIndex = 3;
            button3.Text = "resetSettings";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(174, 291);
            button4.Name = "button4";
            button4.Size = new Size(176, 29);
            button4.TabIndex = 4;
            button4.Text = "Zapisz ustawienia User";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(356, 290);
            button5.Name = "button5";
            button5.Size = new Size(134, 29);
            button5.TabIndex = 5;
            button5.Text = "ZapiszGlobalne";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnJezykZmien);
            groupBox2.Controls.Add(rbEn);
            groupBox2.Controls.Add(rbPL);
            groupBox2.Location = new Point(268, 28);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(202, 125);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "jezyk";
            // 
            // btnJezykZmien
            // 
            btnJezykZmien.Location = new Point(17, 90);
            btnJezykZmien.Name = "btnJezykZmien";
            btnJezykZmien.Size = new Size(179, 29);
            btnJezykZmien.TabIndex = 8;
            btnJezykZmien.Text = "zmienJezyk";
            btnJezykZmien.UseVisualStyleBackColor = true;
            btnJezykZmien.Click += btnJezykZmien_Click_1;
            // 
            // rbEn
            // 
            rbEn.AutoSize = true;
            rbEn.Location = new Point(23, 60);
            rbEn.Name = "rbEn";
            rbEn.Size = new Size(88, 24);
            rbEn.TabIndex = 1;
            rbEn.Text = "angielski";
            rbEn.UseVisualStyleBackColor = true;
            // 
            // rbPL
            // 
            rbPL.AutoSize = true;
            rbPL.Checked = true;
            rbPL.Location = new Point(23, 30);
            rbPL.Name = "rbPL";
            rbPL.Size = new Size(69, 24);
            rbPL.TabIndex = 0;
            rbPL.TabStop = true;
            rbPL.Text = "polski";
            rbPL.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 380);
            Controls.Add(groupBox2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private GroupBox groupBox2;
        private RadioButton rbEn;
        private RadioButton rbPL;
        private Button btnJezykZmien;
    }
}