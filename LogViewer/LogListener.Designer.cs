namespace LogViewer
{
    partial class LogListenerForm
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
            this.ListenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogsFolderTextbox = new System.Windows.Forms.TextBox();
            this.InputPagesTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputTextbox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TraceMessagesTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LogUrlsTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListenButton
            // 
            this.ListenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListenButton.Location = new System.Drawing.Point(750, 211);
            this.ListenButton.Name = "ListenButton";
            this.ListenButton.Size = new System.Drawing.Size(132, 33);
            this.ListenButton.TabIndex = 0;
            this.ListenButton.Text = "Start Listening";
            this.ListenButton.UseVisualStyleBackColor = true;
            this.ListenButton.Click += new System.EventHandler(this.ListenButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logs Folder";
            // 
            // LogsFolderTextbox
            // 
            this.LogsFolderTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsFolderTextbox.Location = new System.Drawing.Point(103, 22);
            this.LogsFolderTextbox.Name = "LogsFolderTextbox";
            this.LogsFolderTextbox.Size = new System.Drawing.Size(779, 20);
            this.LogsFolderTextbox.TabIndex = 2;
            // 
            // InputPagesTextbox
            // 
            this.InputPagesTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputPagesTextbox.Location = new System.Drawing.Point(105, 54);
            this.InputPagesTextbox.Multiline = true;
            this.InputPagesTextbox.Name = "InputPagesTextbox";
            this.InputPagesTextbox.Size = new System.Drawing.Size(777, 65);
            this.InputPagesTextbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pages to Monitor";
            // 
            // OutputTextbox
            // 
            this.OutputTextbox.BackColor = System.Drawing.SystemColors.Info;
            this.OutputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextbox.Location = new System.Drawing.Point(0, 0);
            this.OutputTextbox.Multiline = true;
            this.OutputTextbox.Name = "OutputTextbox";
            this.OutputTextbox.ReadOnly = true;
            this.OutputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextbox.Size = new System.Drawing.Size(779, 73);
            this.OutputTextbox.TabIndex = 4;
            this.OutputTextbox.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(103, 271);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TraceMessagesTextbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputTextbox);
            this.splitContainer1.Size = new System.Drawing.Size(779, 346);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 6;
            // 
            // TraceMessagesTextbox
            // 
            this.TraceMessagesTextbox.BackColor = System.Drawing.SystemColors.Info;
            this.TraceMessagesTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TraceMessagesTextbox.Location = new System.Drawing.Point(0, 0);
            this.TraceMessagesTextbox.Multiline = true;
            this.TraceMessagesTextbox.Name = "TraceMessagesTextbox";
            this.TraceMessagesTextbox.ReadOnly = true;
            this.TraceMessagesTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TraceMessagesTextbox.Size = new System.Drawing.Size(779, 269);
            this.TraceMessagesTextbox.TabIndex = 4;
            this.TraceMessagesTextbox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Log URLs";
            // 
            // LogUrlsTextbox
            // 
            this.LogUrlsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogUrlsTextbox.Location = new System.Drawing.Point(103, 136);
            this.LogUrlsTextbox.Multiline = true;
            this.LogUrlsTextbox.Name = "LogUrlsTextbox";
            this.LogUrlsTextbox.Size = new System.Drawing.Size(777, 65);
            this.LogUrlsTextbox.TabIndex = 3;
            // 
            // LogListenerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 632);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.LogUrlsTextbox);
            this.Controls.Add(this.InputPagesTextbox);
            this.Controls.Add(this.LogsFolderTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListenButton);
            this.Name = "LogListenerForm";
            this.Text = "Logs Listener";
            this.Load += new System.EventHandler(this.LogListener_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ListenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LogsFolderTextbox;
        private System.Windows.Forms.TextBox InputPagesTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputTextbox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TraceMessagesTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogUrlsTextbox;
    }
}