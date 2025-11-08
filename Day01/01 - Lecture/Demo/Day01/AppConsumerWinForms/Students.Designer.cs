namespace AppConsumerWinForms
{
    partial class frm_Students
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
            dgv_Students = new DataGridView();
            txt_lName = new TextBox();
            txt_fName = new TextBox();
            txt_Address = new TextBox();
            txt_Age = new TextBox();
            lbl_FName = new Label();
            lbl_LName = new Label();
            lbl_Address = new Label();
            lbl_Age = new Label();
            btn_Add = new Button();
            cb_Dept = new ComboBox();
            lbl_DeptId = new Label();
            txt_Id = new TextBox();
            lbl_Id = new Label();
            lbl_Super = new Label();
            cb_Supervisor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Students).BeginInit();
            SuspendLayout();
            // 
            // dgv_Students
            // 
            dgv_Students.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Students.Location = new Point(22, 319);
            dgv_Students.Name = "dgv_Students";
            dgv_Students.RowHeadersWidth = 51;
            dgv_Students.Size = new Size(968, 119);
            dgv_Students.TabIndex = 0;
            // 
            // txt_lName
            // 
            txt_lName.Location = new Point(517, 84);
            txt_lName.Name = "txt_lName";
            txt_lName.Size = new Size(125, 27);
            txt_lName.TabIndex = 1;
            // 
            // txt_fName
            // 
            txt_fName.Location = new Point(517, 51);
            txt_fName.Name = "txt_fName";
            txt_fName.Size = new Size(125, 27);
            txt_fName.TabIndex = 1;
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(517, 117);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(125, 27);
            txt_Address.TabIndex = 1;
            // 
            // txt_Age
            // 
            txt_Age.Location = new Point(517, 150);
            txt_Age.Name = "txt_Age";
            txt_Age.Size = new Size(125, 27);
            txt_Age.TabIndex = 1;
            // 
            // lbl_FName
            // 
            lbl_FName.AutoSize = true;
            lbl_FName.Location = new Point(436, 54);
            lbl_FName.Name = "lbl_FName";
            lbl_FName.Size = new Size(56, 20);
            lbl_FName.TabIndex = 2;
            lbl_FName.Text = "FName";
            // 
            // lbl_LName
            // 
            lbl_LName.AutoSize = true;
            lbl_LName.Location = new Point(436, 91);
            lbl_LName.Name = "lbl_LName";
            lbl_LName.Size = new Size(56, 20);
            lbl_LName.TabIndex = 2;
            lbl_LName.Text = "LName";
            // 
            // lbl_Address
            // 
            lbl_Address.AutoSize = true;
            lbl_Address.Location = new Point(436, 124);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new Size(62, 20);
            lbl_Address.TabIndex = 2;
            lbl_Address.Text = "Address";
            // 
            // lbl_Age
            // 
            lbl_Age.AutoSize = true;
            lbl_Age.Location = new Point(436, 157);
            lbl_Age.Name = "lbl_Age";
            lbl_Age.Size = new Size(36, 20);
            lbl_Age.TabIndex = 2;
            lbl_Age.Text = "Age";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(526, 270);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(94, 29);
            btn_Add.TabIndex = 3;
            btn_Add.Text = "Add";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // cb_Dept
            // 
            cb_Dept.FormattingEnabled = true;
            cb_Dept.Location = new Point(517, 183);
            cb_Dept.Name = "cb_Dept";
            cb_Dept.Size = new Size(125, 28);
            cb_Dept.TabIndex = 4;
            // 
            // lbl_DeptId
            // 
            lbl_DeptId.AutoSize = true;
            lbl_DeptId.Location = new Point(436, 191);
            lbl_DeptId.Name = "lbl_DeptId";
            lbl_DeptId.Size = new Size(42, 20);
            lbl_DeptId.TabIndex = 2;
            lbl_DeptId.Text = "Dept";
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(517, 18);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(125, 27);
            txt_Id.TabIndex = 1;
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(436, 25);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(22, 20);
            lbl_Id.TabIndex = 2;
            lbl_Id.Text = "Id";
            // 
            // lbl_Super
            // 
            lbl_Super.AutoSize = true;
            lbl_Super.Location = new Point(436, 221);
            lbl_Super.Name = "lbl_Super";
            lbl_Super.Size = new Size(78, 20);
            lbl_Super.TabIndex = 2;
            lbl_Super.Text = "Supervisor";
            // 
            // cb_Supervisor
            // 
            cb_Supervisor.FormattingEnabled = true;
            cb_Supervisor.Location = new Point(517, 217);
            cb_Supervisor.Name = "cb_Supervisor";
            cb_Supervisor.Size = new Size(125, 28);
            cb_Supervisor.TabIndex = 4;
            // 
            // frm_Students
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 450);
            Controls.Add(cb_Supervisor);
            Controls.Add(cb_Dept);
            Controls.Add(btn_Add);
            Controls.Add(lbl_Super);
            Controls.Add(lbl_DeptId);
            Controls.Add(lbl_Age);
            Controls.Add(lbl_Address);
            Controls.Add(lbl_LName);
            Controls.Add(lbl_Id);
            Controls.Add(lbl_FName);
            Controls.Add(txt_Id);
            Controls.Add(txt_fName);
            Controls.Add(txt_Age);
            Controls.Add(txt_Address);
            Controls.Add(txt_lName);
            Controls.Add(dgv_Students);
            Name = "frm_Students";
            Text = "Manage Students";
            Load += frm_Students_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Students).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Students;
        private TextBox txt_lName;
        private TextBox txt_fName;
        private TextBox txt_Address;
        private TextBox txt_Age;
        private Label lbl_FName;
        private Label lbl_LName;
        private Label lbl_Address;
        private Label lbl_Age;
        private Button btn_Add;
        private ComboBox cb_Dept;
        private Label lbl_DeptId;
        private TextBox txt_Id;
        private Label lbl_Id;
        private Label lbl_Super;
        private ComboBox cb_Supervisor;
    }
}
