using System.Windows.Forms;

namespace QLTTBCNTT_WinForm
{
    partial class FormMain
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
            this.AccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accMgrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccToolStripMenuItem
            // 
            this.AccToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accMgrToolStripMenuItem});
            this.AccToolStripMenuItem.Name = "AccToolStripMenuItem";
            this.AccToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.AccToolStripMenuItem.Text = "Tài khoản";
            // 
            // accMgrToolStripMenuItem
            // 
            this.accMgrToolStripMenuItem.Name = "accMgrToolStripMenuItem";
            this.accMgrToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.accMgrToolStripMenuItem.Text = "Quản lý tài khoản";
            this.accMgrToolStripMenuItem.Visible = false;
            this.accMgrToolStripMenuItem.Click += new System.EventHandler(this.accMgrToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDesktopPane.Location = new System.Drawing.Point(166, 7);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(960, 654);
            this.panelDesktopPane.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 660);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "Quản lý Trang thiết bị CNTT";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStripMenuItem AccToolStripMenuItem;
        private ToolStripMenuItem accMgrToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Panel panelDesktopPane;
    }
}

