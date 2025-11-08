namespace AppConsumerWinForms
{
    partial class frm_Courses
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
            dgv_Courses = new DataGridView();
            txt_Id = new TextBox();
            txt_Name = new TextBox();
            txt_Duration = new TextBox();
            cb_Topic = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btn_Add = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Courses).BeginInit();
            SuspendLayout();
            // 
            // dgv_Courses
            // 
            dgv_Courses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Courses.Location = new Point(325, 250);
            dgv_Courses.Name = "dgv_Courses";
            dgv_Courses.RowHeadersWidth = 51;
            dgv_Courses.Size = new Size(654, 188);
            dgv_Courses.TabIndex = 0;
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(594, 25);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(125, 27);
            txt_Id.TabIndex = 1;
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(594, 58);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(125, 27);
            txt_Name.TabIndex = 1;
            // 
            // txt_Duration
            // 
            txt_Duration.Location = new Point(594, 91);
            txt_Duration.Name = "txt_Duration";
            txt_Duration.Size = new Size(125, 27);
            txt_Duration.TabIndex = 1;
            // 
            // cb_Topic
            // 
            cb_Topic.FormattingEnabled = true;
            cb_Topic.Location = new Point(594, 124);
            cb_Topic.Name = "cb_Topic";
            cb_Topic.Size = new Size(125, 28);
            cb_Topic.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(513, 32);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 3;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(513, 65);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(513, 98);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 3;
            label3.Text = "Duration";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(513, 132);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 3;
            label4.Text = "Topic";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(604, 169);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(94, 29);
            btn_Add.TabIndex = 4;
            btn_Add.Text = "Add";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // frm_Courses
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 450);
            Controls.Add(btn_Add);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cb_Topic);
            Controls.Add(txt_Duration);
            Controls.Add(txt_Name);
            Controls.Add(txt_Id);
            Controls.Add(dgv_Courses);
            Name = "frm_Courses";
            Text = "Manage Courses";
            Load += frm_Courses_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Courses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Courses;
        private TextBox txt_Id;
        private TextBox txt_Name;
        private TextBox txt_Duration;
        private ComboBox cb_Topic;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btn_Add;
    }
}