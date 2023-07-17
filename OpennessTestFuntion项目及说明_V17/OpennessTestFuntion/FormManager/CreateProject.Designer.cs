namespace FormManager
{
    partial class CreateProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProject));
            this.Confirm = new System.Windows.Forms.Button();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.labelProjectPath = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.StatuseText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(16, 172);
            this.Confirm.Margin = new System.Windows.Forms.Padding(4);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(100, 29);
            this.Confirm.TabIndex = 9;
            this.Confirm.Text = "确认";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // ProjectPath
            // 
            this.ProjectPath.Location = new System.Drawing.Point(16, 118);
            this.ProjectPath.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(324, 25);
            this.ProjectPath.TabIndex = 8;
            this.ProjectPath.Text = "D:\\step7\\CreateOpennessProject";
            // 
            // labelProjectPath
            // 
            this.labelProjectPath.AutoSize = true;
            this.labelProjectPath.Location = new System.Drawing.Point(13, 84);
            this.labelProjectPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectPath.Name = "labelProjectPath";
            this.labelProjectPath.Size = new System.Drawing.Size(67, 15);
            this.labelProjectPath.TabIndex = 7;
            this.labelProjectPath.Text = "项目路径";
            // 
            // ProjectName
            // 
            this.ProjectName.Location = new System.Drawing.Point(16, 46);
            this.ProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(183, 25);
            this.ProjectName.TabIndex = 6;
            this.ProjectName.Text = "OpennessTest1";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(13, 19);
            this.labelProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(67, 15);
            this.labelProjectName.TabIndex = 5;
            this.labelProjectName.Text = "项目名称";
            // 
            // StatuseText
            // 
            this.StatuseText.Location = new System.Drawing.Point(16, 222);
            this.StatuseText.Margin = new System.Windows.Forms.Padding(4);
            this.StatuseText.Multiline = true;
            this.StatuseText.Name = "StatuseText";
            this.StatuseText.Size = new System.Drawing.Size(324, 103);
            this.StatuseText.TabIndex = 10;
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 341);
            this.Controls.Add(this.StatuseText);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.labelProjectPath);
            this.Controls.Add(this.ProjectName);
            this.Controls.Add(this.labelProjectName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateProject";
            this.Text = "创建项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.Label labelProjectPath;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.TextBox StatuseText;
    }
}