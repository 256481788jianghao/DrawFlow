namespace DrawFlow
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_menuleft = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_down = new System.Windows.Forms.Panel();
            this.Buttom_Tip = new System.Windows.Forms.TextBox();
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl_Context = new System.Windows.Forms.TabControl();
            this.treeView_leftmenu = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.panel_menuleft.SuspendLayout();
            this.panel_down.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // panel_menuleft
            // 
            this.panel_menuleft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_menuleft.Controls.Add(this.treeView_leftmenu);
            this.panel_menuleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menuleft.Location = new System.Drawing.Point(0, 25);
            this.panel_menuleft.Name = "panel_menuleft";
            this.panel_menuleft.Size = new System.Drawing.Size(128, 557);
            this.panel_menuleft.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(128, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 557);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel_down
            // 
            this.panel_down.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_down.Controls.Add(this.Buttom_Tip);
            this.panel_down.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_down.Location = new System.Drawing.Point(131, 555);
            this.panel_down.Name = "panel_down";
            this.panel_down.Size = new System.Drawing.Size(879, 27);
            this.panel_down.TabIndex = 4;
            // 
            // Buttom_Tip
            // 
            this.Buttom_Tip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Buttom_Tip.Enabled = false;
            this.Buttom_Tip.Location = new System.Drawing.Point(0, 0);
            this.Buttom_Tip.Multiline = true;
            this.Buttom_Tip.Name = "Buttom_Tip";
            this.Buttom_Tip.Size = new System.Drawing.Size(879, 27);
            this.Buttom_Tip.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(131, 25);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(879, 25);
            this.panel_top.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl_Context);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(131, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 505);
            this.panel1.TabIndex = 6;
            // 
            // tabControl_Context
            // 
            this.tabControl_Context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Context.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Context.Name = "tabControl_Context";
            this.tabControl_Context.SelectedIndex = 0;
            this.tabControl_Context.Size = new System.Drawing.Size(879, 505);
            this.tabControl_Context.TabIndex = 0;
            // 
            // treeView_leftmenu
            // 
            this.treeView_leftmenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_leftmenu.Location = new System.Drawing.Point(0, 0);
            this.treeView_leftmenu.Name = "treeView_leftmenu";
            this.treeView_leftmenu.Size = new System.Drawing.Size(128, 557);
            this.treeView_leftmenu.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_down);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_menuleft);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DrawFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_menuleft.ResumeLayout(false);
            this.panel_down.ResumeLayout(false);
            this.panel_down.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_menuleft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_down;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl_Context;
        private System.Windows.Forms.TextBox Buttom_Tip;
        private System.Windows.Forms.TreeView treeView_leftmenu;
    }
}

