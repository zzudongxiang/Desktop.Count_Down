namespace CountDown
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbCountDown = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始计时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止计时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.iPV4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port18459ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerRefresh = new System.Windows.Forms.Timer(this.components);
            this.TimerSys = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCountDown
            // 
            this.lbCountDown.AutoSize = true;
            this.lbCountDown.ContextMenuStrip = this.MenuStrip;
            this.lbCountDown.Font = new System.Drawing.Font("Consolas", 35F);
            this.lbCountDown.ForeColor = System.Drawing.Color.Red;
            this.lbCountDown.Location = new System.Drawing.Point(0, 0);
            this.lbCountDown.Name = "lbCountDown";
            this.lbCountDown.Size = new System.Drawing.Size(154, 55);
            this.lbCountDown.TabIndex = 0;
            this.lbCountDown.Text = "00:00";
            this.lbCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCountDown.TextChanged += new System.EventHandler(this.lbCountDown_TextChanged);
            this.lbCountDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbCountDown_MouseDown);
            this.lbCountDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbCountDown_MouseMove);
            this.lbCountDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbCountDown_MouseUp);
            this.lbCountDown.Resize += new System.EventHandler(this.lbCountDown_Resize);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始计时ToolStripMenuItem,
            this.停止计时ToolStripMenuItem,
            this.toolStripSeparator2,
            this.iPV4ToolStripMenuItem,
            this.port18459ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(149, 126);
            // 
            // 开始计时ToolStripMenuItem
            // 
            this.开始计时ToolStripMenuItem.Name = "开始计时ToolStripMenuItem";
            this.开始计时ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.开始计时ToolStripMenuItem.Text = "开始计时";
            this.开始计时ToolStripMenuItem.Click += new System.EventHandler(this.开始计时ToolStripMenuItem_Click);
            // 
            // 停止计时ToolStripMenuItem
            // 
            this.停止计时ToolStripMenuItem.Name = "停止计时ToolStripMenuItem";
            this.停止计时ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.停止计时ToolStripMenuItem.Text = "停止计时";
            this.停止计时ToolStripMenuItem.Click += new System.EventHandler(this.停止计时ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // iPV4ToolStripMenuItem
            // 
            this.iPV4ToolStripMenuItem.Enabled = false;
            this.iPV4ToolStripMenuItem.Name = "iPV4ToolStripMenuItem";
            this.iPV4ToolStripMenuItem.ShowShortcutKeys = false;
            this.iPV4ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.iPV4ToolStripMenuItem.Text = "IPV4:127.0.0.1";
            // 
            // port18459ToolStripMenuItem
            // 
            this.port18459ToolStripMenuItem.Enabled = false;
            this.port18459ToolStripMenuItem.Name = "port18459ToolStripMenuItem";
            this.port18459ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.port18459ToolStripMenuItem.Text = "Port:18459";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // TimerRefresh
            // 
            this.TimerRefresh.Interval = 48;
            this.TimerRefresh.Tick += new System.EventHandler(this.TimerRefresh_Tick);
            // 
            // TimerSys
            // 
            this.TimerSys.Enabled = true;
            this.TimerSys.Tick += new System.EventHandler(this.TimerSys_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(154, 55);
            this.Controls.Add(this.lbCountDown);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "倒计时";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCountDown;
        private System.Windows.Forms.Timer TimerRefresh;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 开始计时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止计时ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem iPV4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port18459ToolStripMenuItem;
        private System.Windows.Forms.Timer TimerSys;
    }
}

