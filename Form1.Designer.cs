using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameWindowLib
{
    partial class LogConsole
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        // Token: 0x04000006 RID: 6
        private IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaveCurrentButton = new System.Windows.Forms.Button();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.ClearCurrentButton = new System.Windows.Forms.Button();
            this.LogContainerFailureEvent = new System.Windows.Forms.TabPage();
            this.RTBConsoleTypeFailureEvent = new System.Windows.Forms.RichTextBox();
            this.LogContainerAll = new System.Windows.Forms.TabPage();
            this.RTBConsoleTypeAll = new System.Windows.Forms.RichTextBox();
            this.GameConsoleTab = new System.Windows.Forms.TabControl();
            this.LogContainerSuccessEvent = new System.Windows.Forms.TabPage();
            this.RTBConsoleTypeSuccessEvent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.LogContainerFailureEvent.SuspendLayout();
            this.LogContainerAll.SuspendLayout();
            this.GameConsoleTab.SuspendLayout();
            this.LogContainerSuccessEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveCurrentButton);
            this.panel1.Controls.Add(this.ClearAllButton);
            this.panel1.Controls.Add(this.ClearCurrentButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 1352);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 134);
            this.panel1.TabIndex = 3;
            // 
            // SaveCurrentButton
            // 
            this.SaveCurrentButton.BackColor = System.Drawing.Color.White;
            this.SaveCurrentButton.Location = new System.Drawing.Point(723, 15);
            this.SaveCurrentButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveCurrentButton.Name = "SaveCurrentButton";
            this.SaveCurrentButton.Size = new System.Drawing.Size(286, 106);
            this.SaveCurrentButton.TabIndex = 2;
            this.SaveCurrentButton.Text = "保存当前";
            this.SaveCurrentButton.UseVisualStyleBackColor = false;
            this.SaveCurrentButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.BackColor = System.Drawing.Color.White;
            this.ClearAllButton.Location = new System.Drawing.Point(368, 14);
            this.ClearAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(286, 106);
            this.ClearAllButton.TabIndex = 1;
            this.ClearAllButton.Text = "清空所有";
            this.ClearAllButton.UseVisualStyleBackColor = false;
            this.ClearAllButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClearCurrentButton
            // 
            this.ClearCurrentButton.BackColor = System.Drawing.Color.White;
            this.ClearCurrentButton.Location = new System.Drawing.Point(12, 15);
            this.ClearCurrentButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearCurrentButton.Name = "ClearCurrentButton";
            this.ClearCurrentButton.Size = new System.Drawing.Size(286, 106);
            this.ClearCurrentButton.TabIndex = 0;
            this.ClearCurrentButton.Text = "清除当前";
            this.ClearCurrentButton.UseVisualStyleBackColor = false;
            this.ClearCurrentButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogContainerFailureEvent
            // 
            this.LogContainerFailureEvent.Controls.Add(this.RTBConsoleTypeFailureEvent);
            this.LogContainerFailureEvent.Location = new System.Drawing.Point(4, 50);
            this.LogContainerFailureEvent.Margin = new System.Windows.Forms.Padding(4);
            this.LogContainerFailureEvent.Name = "LogContainerFailureEvent";
            this.LogContainerFailureEvent.Size = new System.Drawing.Size(1026, 1298);
            this.LogContainerFailureEvent.TabIndex = 2;
            this.LogContainerFailureEvent.Text = "失败事件";
            this.LogContainerFailureEvent.UseVisualStyleBackColor = true;
            // 
            // RTBConsoleTypeFailureEvent
            // 
            this.RTBConsoleTypeFailureEvent.BackColor = System.Drawing.Color.Black;
            this.RTBConsoleTypeFailureEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBConsoleTypeFailureEvent.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTBConsoleTypeFailureEvent.ForeColor = System.Drawing.SystemColors.Window;
            this.RTBConsoleTypeFailureEvent.Location = new System.Drawing.Point(0, 0);
            this.RTBConsoleTypeFailureEvent.Margin = new System.Windows.Forms.Padding(4);
            this.RTBConsoleTypeFailureEvent.Name = "RTBConsoleTypeFailureEvent";
            this.RTBConsoleTypeFailureEvent.Size = new System.Drawing.Size(1026, 1298);
            this.RTBConsoleTypeFailureEvent.TabIndex = 2;
            this.RTBConsoleTypeFailureEvent.Text = "";
            // 
            // LogContainerAll
            // 
            this.LogContainerAll.Controls.Add(this.RTBConsoleTypeAll);
            this.LogContainerAll.Location = new System.Drawing.Point(4, 50);
            this.LogContainerAll.Margin = new System.Windows.Forms.Padding(0);
            this.LogContainerAll.Name = "LogContainerAll";
            this.LogContainerAll.Size = new System.Drawing.Size(1026, 1298);
            this.LogContainerAll.TabIndex = 0;
            this.LogContainerAll.Text = "全部";
            this.LogContainerAll.UseVisualStyleBackColor = true;
            // 
            // RTBConsoleTypeAll
            // 
            this.RTBConsoleTypeAll.BackColor = System.Drawing.Color.Black;
            this.RTBConsoleTypeAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBConsoleTypeAll.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTBConsoleTypeAll.ForeColor = System.Drawing.SystemColors.Window;
            this.RTBConsoleTypeAll.Location = new System.Drawing.Point(0, 0);
            this.RTBConsoleTypeAll.Margin = new System.Windows.Forms.Padding(4);
            this.RTBConsoleTypeAll.Name = "RTBConsoleTypeAll";
            this.RTBConsoleTypeAll.Size = new System.Drawing.Size(1026, 1298);
            this.RTBConsoleTypeAll.TabIndex = 2;
            this.RTBConsoleTypeAll.Text = "";
            // 
            // GameConsoleTab
            // 
            this.GameConsoleTab.Controls.Add(this.LogContainerAll);
            this.GameConsoleTab.Controls.Add(this.LogContainerSuccessEvent);
            this.GameConsoleTab.Controls.Add(this.LogContainerFailureEvent);
            this.GameConsoleTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameConsoleTab.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GameConsoleTab.Location = new System.Drawing.Point(0, 0);
            this.GameConsoleTab.Margin = new System.Windows.Forms.Padding(0);
            this.GameConsoleTab.Multiline = true;
            this.GameConsoleTab.Name = "GameConsoleTab";
            this.GameConsoleTab.SelectedIndex = 0;
            this.GameConsoleTab.Size = new System.Drawing.Size(1034, 1352);
            this.GameConsoleTab.TabIndex = 1;
            // 
            // LogContainerSuccessEvent
            // 
            this.LogContainerSuccessEvent.Controls.Add(this.RTBConsoleTypeSuccessEvent);
            this.LogContainerSuccessEvent.Location = new System.Drawing.Point(4, 50);
            this.LogContainerSuccessEvent.Margin = new System.Windows.Forms.Padding(0);
            this.LogContainerSuccessEvent.Name = "LogContainerSuccessEvent";
            this.LogContainerSuccessEvent.Size = new System.Drawing.Size(1026, 1298);
            this.LogContainerSuccessEvent.TabIndex = 1;
            this.LogContainerSuccessEvent.Text = "成功事件";
            this.LogContainerSuccessEvent.UseVisualStyleBackColor = true;
            // 
            // RTBConsoleTypeSuccessEvent
            // 
            this.RTBConsoleTypeSuccessEvent.BackColor = System.Drawing.Color.Black;
            this.RTBConsoleTypeSuccessEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTBConsoleTypeSuccessEvent.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTBConsoleTypeSuccessEvent.ForeColor = System.Drawing.SystemColors.Window;
            this.RTBConsoleTypeSuccessEvent.Location = new System.Drawing.Point(0, 0);
            this.RTBConsoleTypeSuccessEvent.Margin = new System.Windows.Forms.Padding(4);
            this.RTBConsoleTypeSuccessEvent.Name = "RTBConsoleTypeSuccessEvent";
            this.RTBConsoleTypeSuccessEvent.Size = new System.Drawing.Size(1026, 1298);
            this.RTBConsoleTypeSuccessEvent.TabIndex = 2;
            this.RTBConsoleTypeSuccessEvent.Text = "";
            // 
            // LogConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1034, 1486);
            this.Controls.Add(this.GameConsoleTab);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogConsole";
            this.Text = "LogConsole";
            this.panel1.ResumeLayout(false);
            this.LogContainerFailureEvent.ResumeLayout(false);
            this.LogContainerAll.ResumeLayout(false);
            this.GameConsoleTab.ResumeLayout(false);
            this.LogContainerSuccessEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private Button SaveCurrentButton;
        private Button ClearAllButton;
        private Button ClearCurrentButton;
        private TabPage LogContainerFailureEvent;
        private RichTextBox RTBConsoleTypeFailureEvent;
        private TabPage LogContainerAll;
        private RichTextBox RTBConsoleTypeAll;
        private TabControl GameConsoleTab;
        private TabPage LogContainerSuccessEvent;
        private RichTextBox RTBConsoleTypeSuccessEvent;
    }
}

