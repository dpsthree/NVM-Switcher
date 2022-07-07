namespace NVM_Switcher
{
    partial class SwitcherLog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitcherLog));
            this.notificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.logEntries = new System.Windows.Forms.TextBox();
            this.notificationContextMenu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // notificationIcon
            // 
            this.notificationIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notificationIcon.Icon")));
            this.notificationIcon.Text = "notifyIcon1";
            this.notificationIcon.Visible = true;
            this.notificationIcon.DoubleClick += new System.EventHandler(this.notificationIcon_DoubleClick);
            // 
            // logEntries
            // 
            this.logEntries.Location = new System.Drawing.Point(12, 12);
            this.logEntries.Multiline = true;
            this.logEntries.Name = "logEntries";
            this.logEntries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logEntries.Size = new System.Drawing.Size(776, 372);
            this.logEntries.TabIndex = 0;
            // 
            // notificationContextMenu
            // 
            this.notificationContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.notificationContextMenu.Location = new System.Drawing.Point(0, 0);
            this.notificationContextMenu.Name = "notificationContextMenu";
            this.notificationContextMenu.Size = new System.Drawing.Size(800, 24);
            this.notificationContextMenu.TabIndex = 1;
            this.notificationContextMenu.Text = "menuStrip1";
            // 
            // SwitcherLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logEntries);
            this.Controls.Add(this.notificationContextMenu);
            this.MainMenuStrip = this.notificationContextMenu;
            this.Name = "SwitcherLog";
            this.Text = "NVM Switcher Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SwitcherLog_FormClosing);
            this.Load += new System.EventHandler(this.SwitcherLogLoad);
            this.Shown += new System.EventHandler(this.SwitcherLog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notificationIcon;
        private TextBox logEntries;
        private MenuStrip notificationContextMenu;
    }
}