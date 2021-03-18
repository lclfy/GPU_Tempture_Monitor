namespace WindowsFormsApplication1
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.highTemp_tb = new System.Windows.Forms.TextBox();
            this.processName_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.processName_tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.killProcess_btn = new System.Windows.Forms.Button();
            this.GPUList_lv = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // highTemp_tb
            // 
            this.highTemp_tb.Location = new System.Drawing.Point(208, 35);
            this.highTemp_tb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.highTemp_tb.Name = "highTemp_tb";
            this.highTemp_tb.Size = new System.Drawing.Size(122, 41);
            this.highTemp_tb.TabIndex = 1;
            this.highTemp_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.highTemp_tb_KeyPress);
            // 
            // processName_lbl
            // 
            this.processName_lbl.AutoSize = true;
            this.processName_lbl.Location = new System.Drawing.Point(7, 82);
            this.processName_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processName_lbl.Name = "processName_lbl";
            this.processName_lbl.Size = new System.Drawing.Size(178, 24);
            this.processName_lbl.TabIndex = 2;
            this.processName_lbl.Text = "关闭的进程名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "温度阈值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "℃";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(455, 31);
            this.save_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(132, 83);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "保存设置";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // processName_tb
            // 
            this.processName_tb.Location = new System.Drawing.Point(208, 82);
            this.processName_tb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.processName_tb.Name = "processName_tb";
            this.processName_tb.Size = new System.Drawing.Size(209, 41);
            this.processName_tb.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.killProcess_btn);
            this.groupBox1.Controls.Add(this.save_btn);
            this.groupBox1.Controls.Add(this.processName_lbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.processName_tb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.highTemp_tb);
            this.groupBox1.Location = new System.Drawing.Point(65, 531);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(742, 145);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "(不用加.exe)";
            // 
            // killProcess_btn
            // 
            this.killProcess_btn.Location = new System.Drawing.Point(595, 31);
            this.killProcess_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.killProcess_btn.Name = "killProcess_btn";
            this.killProcess_btn.Size = new System.Drawing.Size(132, 83);
            this.killProcess_btn.TabIndex = 7;
            this.killProcess_btn.Text = "杀进程测试";
            this.killProcess_btn.UseVisualStyleBackColor = true;
            this.killProcess_btn.Click += new System.EventHandler(this.killProcess_btn_Click);
            // 
            // GPUList_lv
            // 
            this.GPUList_lv.HideSelection = false;
            this.GPUList_lv.Location = new System.Drawing.Point(65, 125);
            this.GPUList_lv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GPUList_lv.Name = "GPUList_lv";
            this.GPUList_lv.Size = new System.Drawing.Size(741, 377);
            this.GPUList_lv.TabIndex = 8;
            this.GPUList_lv.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "GPU温度";
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.time_lbl.Location = new System.Drawing.Point(588, 78);
            this.time_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(106, 24);
            this.time_lbl.TabIndex = 7;
            this.time_lbl.Text = "当前时间";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AMD.png");
            this.imageList1.Images.SetKeyName(1, "NVIDIA.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 713);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GPUList_lv);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Main";
            this.Text = "GPU温度监控器";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox highTemp_tb;
        private System.Windows.Forms.Label processName_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox processName_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView GPUList_lv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button killProcess_btn;
        private System.Windows.Forms.Label label1;
    }
}