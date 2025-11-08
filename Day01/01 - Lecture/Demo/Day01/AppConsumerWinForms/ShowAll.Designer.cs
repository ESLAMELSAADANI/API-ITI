namespace AppConsumerWinForms
{
    partial class frm_ShowAll
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
            btn_Courses = new Button();
            btn_Students = new Button();
            SuspendLayout();
            // 
            // btn_Courses
            // 
            btn_Courses.Location = new Point(411, 193);
            btn_Courses.Name = "btn_Courses";
            btn_Courses.Size = new Size(203, 29);
            btn_Courses.TabIndex = 0;
            btn_Courses.Text = "Manage Courses";
            btn_Courses.UseVisualStyleBackColor = true;
            btn_Courses.Click += btn_Courses_Click;
            // 
            // btn_Students
            // 
            btn_Students.Location = new Point(190, 193);
            btn_Students.Name = "btn_Students";
            btn_Students.Size = new Size(203, 29);
            btn_Students.TabIndex = 0;
            btn_Students.Text = "Manage Students";
            btn_Students.UseVisualStyleBackColor = true;
            btn_Students.Click += btn_Students_Click;
            // 
            // frm_ShowAll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Students);
            Controls.Add(btn_Courses);
            Name = "frm_ShowAll";
            Text = "ShowAll";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Courses;
        private Button btn_Students;
    }
}