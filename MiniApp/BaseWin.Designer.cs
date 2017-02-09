namespace MiniApp
{
    partial class BaseWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWin));
            this.lv_TeeTiem = new System.Windows.Forms.ListView();
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // lv_TeeTiem
            // 
            this.lv_TeeTiem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.description});
            this.lv_TeeTiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_TeeTiem.Location = new System.Drawing.Point(0, 0);
            this.lv_TeeTiem.Name = "lv_TeeTiem";
            this.lv_TeeTiem.Size = new System.Drawing.Size(324, 184);
            this.lv_TeeTiem.TabIndex = 0;
            this.lv_TeeTiem.UseCompatibleStateImageBehavior = false;
            this.lv_TeeTiem.View = System.Windows.Forms.View.Details;
            // 
            // time
            // 
            this.time.Text = "时间";
            this.time.Width = 120;
            // 
            // description
            // 
            this.description.Text = "日志";
            this.description.Width = 200;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Teetime小程序";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // BaseWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 184);
            this.Controls.Add(this.lv_TeeTiem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update & Download TeeTime";
            this.Load += new System.EventHandler(this.BaseWin_Load);
            this.SizeChanged += new System.EventHandler(this.BaseWin_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_TeeTiem;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}