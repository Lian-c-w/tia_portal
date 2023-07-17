namespace FormManager
{
    partial class AddStations
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
            this.labelName = new System.Windows.Forms.Label();
            this.dName = new System.Windows.Forms.TextBox();
            this.labelOrderNo = new System.Windows.Forms.Label();
            this.OrderNo = new System.Windows.Forms.TextBox();
            this.labelFirmware = new System.Windows.Forms.Label();
            this.Firmware = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.StatusMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddModules = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddIOStation = new System.Windows.Forms.Button();
            this.AddV90 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "设备名称";
            // 
            // dName
            // 
            this.dName.Location = new System.Drawing.Point(14, 43);
            this.dName.Name = "dName";
            this.dName.Size = new System.Drawing.Size(141, 21);
            this.dName.TabIndex = 1;
            this.dName.Text = "PLC1";
            // 
            // labelOrderNo
            // 
            this.labelOrderNo.AutoSize = true;
            this.labelOrderNo.Location = new System.Drawing.Point(12, 72);
            this.labelOrderNo.Name = "labelOrderNo";
            this.labelOrderNo.Size = new System.Drawing.Size(41, 12);
            this.labelOrderNo.TabIndex = 2;
            this.labelOrderNo.Text = "订货号";
            // 
            // OrderNo
            // 
            this.OrderNo.Location = new System.Drawing.Point(14, 94);
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Size = new System.Drawing.Size(141, 21);
            this.OrderNo.TabIndex = 3;
            this.OrderNo.Text = "6ES7 516-3AN01-0AB0";
            // 
            // labelFirmware
            // 
            this.labelFirmware.AutoSize = true;
            this.labelFirmware.Location = new System.Drawing.Point(12, 123);
            this.labelFirmware.Name = "labelFirmware";
            this.labelFirmware.Size = new System.Drawing.Size(53, 12);
            this.labelFirmware.TabIndex = 4;
            this.labelFirmware.Text = "固件版本";
            // 
            // Firmware
            // 
            this.Firmware.Location = new System.Drawing.Point(14, 147);
            this.Firmware.Name = "Firmware";
            this.Firmware.Size = new System.Drawing.Size(141, 21);
            this.Firmware.TabIndex = 5;
            this.Firmware.Text = "V2.1";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(14, 174);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "确认";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // StatusMessage
            // 
            this.StatusMessage.Location = new System.Drawing.Point(12, 249);
            this.StatusMessage.Multiline = true;
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(430, 56);
            this.StatusMessage.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 236);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.AddModules);
            this.groupBox2.Location = new System.Drawing.Point(171, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 96);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IO模块";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "使用Excel表格添加模块";
            // 
            // AddModules
            // 
            this.AddModules.Location = new System.Drawing.Point(20, 59);
            this.AddModules.Name = "AddModules";
            this.AddModules.Size = new System.Drawing.Size(75, 23);
            this.AddModules.TabIndex = 0;
            this.AddModules.Text = "添加模块";
            this.AddModules.UseVisualStyleBackColor = true;
            this.AddModules.Click += new System.EventHandler(this.AddModules_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.AddIOStation);
            this.groupBox3.Location = new System.Drawing.Point(171, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 96);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IO分站";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "使用Excel表格添加模块";
            // 
            // AddIOStation
            // 
            this.AddIOStation.Location = new System.Drawing.Point(20, 59);
            this.AddIOStation.Name = "AddIOStation";
            this.AddIOStation.Size = new System.Drawing.Size(75, 23);
            this.AddIOStation.TabIndex = 0;
            this.AddIOStation.Text = "添加分站";
            this.AddIOStation.UseVisualStyleBackColor = true;
            this.AddIOStation.Click += new System.EventHandler(this.AddIOStation_Click);
            // 
            // AddV90
            // 
            this.AddV90.Location = new System.Drawing.Point(414, 26);
            this.AddV90.Name = "AddV90";
            this.AddV90.Size = new System.Drawing.Size(75, 23);
            this.AddV90.TabIndex = 12;
            this.AddV90.Text = "添加V90";
            this.AddV90.UseVisualStyleBackColor = true;
            this.AddV90.Click += new System.EventHandler(this.AddV90_Click);
            // 
            // AddStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 317);
            this.Controls.Add(this.AddV90);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StatusMessage);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Firmware);
            this.Controls.Add(this.labelFirmware);
            this.Controls.Add(this.OrderNo);
            this.Controls.Add(this.labelOrderNo);
            this.Controls.Add(this.dName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddStations";
            this.Text = "AddStations";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox dName;
        private System.Windows.Forms.Label labelOrderNo;
        private System.Windows.Forms.TextBox OrderNo;
        private System.Windows.Forms.Label labelFirmware;
        private System.Windows.Forms.TextBox Firmware;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.TextBox StatusMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddModules;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddIOStation;
        private System.Windows.Forms.Button AddV90;
    }
}