namespace FormManager
{
    partial class FormPlcSimAD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlcSimAD));
            this.Simulation_PLC_IP_4 = new System.Windows.Forms.TextBox();
            this.Simulation_PLC_IP_1 = new System.Windows.Forms.TextBox();
            this.Simulation_PLC_IP_2 = new System.Windows.Forms.TextBox();
            this.Simulation_PLC_IP_3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateInstance = new System.Windows.Forms.Button();
            this.Simulation_PLC_N = new System.Windows.Forms.Label();
            this.Simulation_PLC_Name = new System.Windows.Forms.TextBox();
            this.PowerOn = new System.Windows.Forms.Button();
            this.PowerOFF = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Simulation_PLC_IP_4
            // 
            this.Simulation_PLC_IP_4.Location = new System.Drawing.Point(252, 30);
            this.Simulation_PLC_IP_4.Margin = new System.Windows.Forms.Padding(4);
            this.Simulation_PLC_IP_4.Name = "Simulation_PLC_IP_4";
            this.Simulation_PLC_IP_4.Size = new System.Drawing.Size(31, 25);
            this.Simulation_PLC_IP_4.TabIndex = 8;
            this.Simulation_PLC_IP_4.Text = "80";
            // 
            // Simulation_PLC_IP_1
            // 
            this.Simulation_PLC_IP_1.Location = new System.Drawing.Point(120, 30);
            this.Simulation_PLC_IP_1.Margin = new System.Windows.Forms.Padding(4);
            this.Simulation_PLC_IP_1.Name = "Simulation_PLC_IP_1";
            this.Simulation_PLC_IP_1.Size = new System.Drawing.Size(31, 25);
            this.Simulation_PLC_IP_1.TabIndex = 5;
            this.Simulation_PLC_IP_1.Text = "192";
            // 
            // Simulation_PLC_IP_2
            // 
            this.Simulation_PLC_IP_2.Location = new System.Drawing.Point(164, 30);
            this.Simulation_PLC_IP_2.Margin = new System.Windows.Forms.Padding(4);
            this.Simulation_PLC_IP_2.Name = "Simulation_PLC_IP_2";
            this.Simulation_PLC_IP_2.Size = new System.Drawing.Size(31, 25);
            this.Simulation_PLC_IP_2.TabIndex = 6;
            this.Simulation_PLC_IP_2.Text = "168";
            // 
            // Simulation_PLC_IP_3
            // 
            this.Simulation_PLC_IP_3.Location = new System.Drawing.Point(208, 30);
            this.Simulation_PLC_IP_3.Margin = new System.Windows.Forms.Padding(4);
            this.Simulation_PLC_IP_3.Name = "Simulation_PLC_IP_3";
            this.Simulation_PLC_IP_3.Size = new System.Drawing.Size(31, 25);
            this.Simulation_PLC_IP_3.TabIndex = 7;
            this.Simulation_PLC_IP_3.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "实例IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = ".";
            // 
            // CreateInstance
            // 
            this.CreateInstance.Location = new System.Drawing.Point(32, 80);
            this.CreateInstance.Margin = new System.Windows.Forms.Padding(4);
            this.CreateInstance.Name = "CreateInstance";
            this.CreateInstance.Size = new System.Drawing.Size(100, 29);
            this.CreateInstance.TabIndex = 13;
            this.CreateInstance.Text = "创建实例";
            this.CreateInstance.UseVisualStyleBackColor = true;
            this.CreateInstance.Click += new System.EventHandler(this.CreateInstance_Click);
            // 
            // Simulation_PLC_N
            // 
            this.Simulation_PLC_N.AutoSize = true;
            this.Simulation_PLC_N.Location = new System.Drawing.Point(305, 34);
            this.Simulation_PLC_N.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Simulation_PLC_N.Name = "Simulation_PLC_N";
            this.Simulation_PLC_N.Size = new System.Drawing.Size(67, 15);
            this.Simulation_PLC_N.TabIndex = 20;
            this.Simulation_PLC_N.Text = "实例名称";
            // 
            // Simulation_PLC_Name
            // 
            this.Simulation_PLC_Name.Location = new System.Drawing.Point(387, 30);
            this.Simulation_PLC_Name.Margin = new System.Windows.Forms.Padding(4);
            this.Simulation_PLC_Name.Name = "Simulation_PLC_Name";
            this.Simulation_PLC_Name.Size = new System.Drawing.Size(148, 25);
            this.Simulation_PLC_Name.TabIndex = 19;
            this.Simulation_PLC_Name.Text = "Simulation_PLC";
            // 
            // PowerOn
            // 
            this.PowerOn.Location = new System.Drawing.Point(157, 80);
            this.PowerOn.Margin = new System.Windows.Forms.Padding(4);
            this.PowerOn.Name = "PowerOn";
            this.PowerOn.Size = new System.Drawing.Size(72, 29);
            this.PowerOn.TabIndex = 21;
            this.PowerOn.Text = "上电";
            this.PowerOn.UseVisualStyleBackColor = true;
            this.PowerOn.Click += new System.EventHandler(this.PowerOn_Click);
            // 
            // PowerOFF
            // 
            this.PowerOFF.Location = new System.Drawing.Point(252, 80);
            this.PowerOFF.Margin = new System.Windows.Forms.Padding(4);
            this.PowerOFF.Name = "PowerOFF";
            this.PowerOFF.Size = new System.Drawing.Size(72, 29);
            this.PowerOFF.TabIndex = 22;
            this.PowerOFF.Text = "下电";
            this.PowerOFF.UseVisualStyleBackColor = true;
            this.PowerOFF.Click += new System.EventHandler(this.PowerOFF_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(351, 80);
            this.Run.Margin = new System.Windows.Forms.Padding(4);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(72, 29);
            this.Run.TabIndex = 23;
            this.Run.Text = "运行";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(448, 80);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(72, 29);
            this.Stop.TabIndex = 24;
            this.Stop.Text = "停止";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(32, 142);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ReadOnly = true;
            this.MessageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageText.Size = new System.Drawing.Size(497, 283);
            this.MessageText.TabIndex = 28;
            this.MessageText.WordWrap = false;
            // 
            // FormPlcSimAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 458);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.PowerOFF);
            this.Controls.Add(this.PowerOn);
            this.Controls.Add(this.Simulation_PLC_N);
            this.Controls.Add(this.Simulation_PLC_Name);
            this.Controls.Add(this.CreateInstance);
            this.Controls.Add(this.Simulation_PLC_IP_1);
            this.Controls.Add(this.Simulation_PLC_IP_2);
            this.Controls.Add(this.Simulation_PLC_IP_3);
            this.Controls.Add(this.Simulation_PLC_IP_4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPlcSimAD";
            this.Text = "PLCSIM Advanced";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlcSimAD_FormClosing);
            this.Load += new System.EventHandler(this.FormPlcSimAD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Simulation_PLC_IP_4;
        private System.Windows.Forms.TextBox Simulation_PLC_IP_1;
        private System.Windows.Forms.TextBox Simulation_PLC_IP_2;
        private System.Windows.Forms.TextBox Simulation_PLC_IP_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateInstance;
        private System.Windows.Forms.Label Simulation_PLC_N;
        private System.Windows.Forms.TextBox Simulation_PLC_Name;
        private System.Windows.Forms.Button PowerOn;
        private System.Windows.Forms.Button PowerOFF;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.TextBox MessageText;
    }
}