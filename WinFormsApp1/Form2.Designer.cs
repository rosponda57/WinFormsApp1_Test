namespace WinFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            groupBox2 = new GroupBox();
            rbEn = new RadioButton();
            rbPL = new RadioButton();
            btnJezykZmien = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbEn);
            groupBox2.Controls.Add(rbPL);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // rbEn
            // 
            resources.ApplyResources(rbEn, "rbEn");
            rbEn.Name = "rbEn";
            rbEn.UseVisualStyleBackColor = true;
            // 
            // rbPL
            // 
            resources.ApplyResources(rbPL, "rbPL");
            rbPL.Checked = true;
            rbPL.Name = "rbPL";
            rbPL.TabStop = true;
            rbPL.UseVisualStyleBackColor = true;
            // 
            // btnJezykZmien
            // 
            resources.ApplyResources(btnJezykZmien, "btnJezykZmien");
            btnJezykZmien.Name = "btnJezykZmien";
            btnJezykZmien.UseVisualStyleBackColor = true;
            btnJezykZmien.Click += btnJezykZmien_Click;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(btnJezykZmien);
            Name = "Form2";
            Load += Form2_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox2;
        private RadioButton rbEn;
        private RadioButton rbPL;
        private Button btnJezykZmien;
    }
}