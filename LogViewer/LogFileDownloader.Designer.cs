namespace LogViewer
{
    partial class LogFileDownloader
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.downloadFile = new System.Windows.Forms.Button();
            this.FileList = new System.Windows.Forms.ListBox();
            this.getFiles = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkOverwriteFile = new System.Windows.Forms.CheckBox();
            this.lblFilenamePrefix = new System.Windows.Forms.Label();
            this.txtFilenamePrefix = new System.Windows.Forms.TextBox();
            this.dlProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnClearFile = new System.Windows.Forms.Button();
            this.LogUrlList = new System.Windows.Forms.ComboBox();
            this.DownloadStatusTextbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PercentageLabel = new System.Windows.Forms.Label();
            this.CancelDownloadButton = new System.Windows.Forms.Button();
            this.AddFileToDownloadButton = new System.Windows.Forms.Button();
            this.ManualFileAddTextbox = new System.Windows.Forms.TextBox();
            this.NetworkCredsButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Logs URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date From:";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(114, 15);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(181, 20);
            this.datePickerFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To:";
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(340, 15);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(188, 20);
            this.datePickerTo.TabIndex = 3;
            // 
            // downloadFile
            // 
            this.downloadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadFile.Enabled = false;
            this.downloadFile.FlatAppearance.BorderSize = 0;
            this.downloadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadFile.Image = global::LogViewer.Properties.Resources.download;
            this.downloadFile.Location = new System.Drawing.Point(492, 301);
            this.downloadFile.Name = "downloadFile";
            this.downloadFile.Size = new System.Drawing.Size(114, 23);
            this.downloadFile.TabIndex = 15;
            this.downloadFile.Text = "Download Logs";
            this.downloadFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.downloadFile, "Download Logs");
            this.downloadFile.UseVisualStyleBackColor = true;
            this.downloadFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileList
            // 
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(114, 117);
            this.FileList.Name = "FileList";
            this.FileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileList.Size = new System.Drawing.Size(492, 134);
            this.FileList.TabIndex = 7;
            this.FileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileList_KeyDown);
            // 
            // getFiles
            // 
            this.getFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getFiles.FlatAppearance.BorderSize = 0;
            this.getFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getFiles.Image = global::LogViewer.Properties.Resources.Refresh;
            this.getFiles.Location = new System.Drawing.Point(534, 42);
            this.getFiles.Name = "getFiles";
            this.getFiles.Size = new System.Drawing.Size(33, 29);
            this.getFiles.TabIndex = 6;
            this.toolTip1.SetToolTip(this.getFiles, "Get list of server log files");
            this.getFiles.UseVisualStyleBackColor = true;
            this.getFiles.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Download Folder:";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(114, 266);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(453, 20);
            this.txtFolder.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(31, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 17;
            // 
            // chkOverwriteFile
            // 
            this.chkOverwriteFile.AutoSize = true;
            this.chkOverwriteFile.Checked = true;
            this.chkOverwriteFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwriteFile.Location = new System.Drawing.Point(315, 305);
            this.chkOverwriteFile.Name = "chkOverwriteFile";
            this.chkOverwriteFile.Size = new System.Drawing.Size(130, 17);
            this.chkOverwriteFile.TabIndex = 13;
            this.chkOverwriteFile.Text = "Overwrite existing files";
            this.chkOverwriteFile.UseVisualStyleBackColor = true;
            // 
            // lblFilenamePrefix
            // 
            this.lblFilenamePrefix.AutoSize = true;
            this.lblFilenamePrefix.Location = new System.Drawing.Point(25, 307);
            this.lblFilenamePrefix.Name = "lblFilenamePrefix";
            this.lblFilenamePrefix.Size = new System.Drawing.Size(81, 13);
            this.lblFilenamePrefix.TabIndex = 11;
            this.lblFilenamePrefix.Text = "Filename Prefix:";
            // 
            // txtFilenamePrefix
            // 
            this.txtFilenamePrefix.Location = new System.Drawing.Point(114, 303);
            this.txtFilenamePrefix.Name = "txtFilenamePrefix";
            this.txtFilenamePrefix.Size = new System.Drawing.Size(181, 20);
            this.txtFilenamePrefix.TabIndex = 12;
            // 
            // dlProgressBar
            // 
            this.dlProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlProgressBar.Location = new System.Drawing.Point(114, 490);
            this.dlProgressBar.Name = "dlProgressBar";
            this.dlProgressBar.Size = new System.Drawing.Size(492, 19);
            this.dlProgressBar.TabIndex = 16;
            this.dlProgressBar.Visible = false;
            // 
            // btnClearFile
            // 
            this.btnClearFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFile.Location = new System.Drawing.Point(19, 394);
            this.btnClearFile.Name = "btnClearFile";
            this.btnClearFile.Size = new System.Drawing.Size(83, 29);
            this.btnClearFile.TabIndex = 14;
            this.btnClearFile.Text = "Clear";
            this.btnClearFile.UseVisualStyleBackColor = true;
            this.btnClearFile.Visible = false;
            this.btnClearFile.Click += new System.EventHandler(this.btnClearFile_Click);
            // 
            // LogUrlList
            // 
            this.LogUrlList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogUrlList.FormattingEnabled = true;
            this.LogUrlList.Location = new System.Drawing.Point(114, 47);
            this.LogUrlList.Name = "LogUrlList";
            this.LogUrlList.Size = new System.Drawing.Size(414, 21);
            this.LogUrlList.TabIndex = 5;
            this.LogUrlList.Leave += new System.EventHandler(this.LogUrlList_Leave);
            // 
            // DownloadStatusTextbox
            // 
            this.DownloadStatusTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadStatusTextbox.BackColor = System.Drawing.Color.Cornsilk;
            this.DownloadStatusTextbox.Location = new System.Drawing.Point(114, 342);
            this.DownloadStatusTextbox.Multiline = true;
            this.DownloadStatusTextbox.Name = "DownloadStatusTextbox";
            this.DownloadStatusTextbox.ReadOnly = true;
            this.DownloadStatusTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DownloadStatusTextbox.Size = new System.Drawing.Size(492, 144);
            this.DownloadStatusTextbox.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::LogViewer.Properties.Resources.folder_horizontal_open;
            this.button1.Location = new System.Drawing.Point(573, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 40);
            this.button1.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button1, "Open folder in Explorer");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PercentageLabel
            // 
            this.PercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PercentageLabel.AutoSize = true;
            this.PercentageLabel.BackColor = System.Drawing.Color.Transparent;
            this.PercentageLabel.ForeColor = System.Drawing.Color.Black;
            this.PercentageLabel.Location = new System.Drawing.Point(499, 520);
            this.PercentageLabel.Name = "PercentageLabel";
            this.PercentageLabel.Size = new System.Drawing.Size(10, 13);
            this.PercentageLabel.TabIndex = 21;
            this.PercentageLabel.Text = ".";
            this.PercentageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelDownloadButton
            // 
            this.CancelDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDownloadButton.Location = new System.Drawing.Point(479, 520);
            this.CancelDownloadButton.Name = "CancelDownloadButton";
            this.CancelDownloadButton.Size = new System.Drawing.Size(127, 31);
            this.CancelDownloadButton.TabIndex = 22;
            this.CancelDownloadButton.Text = "Cancel Download";
            this.CancelDownloadButton.UseVisualStyleBackColor = true;
            this.CancelDownloadButton.Visible = false;
            this.CancelDownloadButton.Click += new System.EventHandler(this.CancelDownloadButton_Click);
            // 
            // AddFileToDownloadButton
            // 
            this.AddFileToDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFileToDownloadButton.FlatAppearance.BorderSize = 0;
            this.AddFileToDownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFileToDownloadButton.Image = global::LogViewer.Properties.Resources.plus;
            this.AddFileToDownloadButton.Location = new System.Drawing.Point(573, 79);
            this.AddFileToDownloadButton.Name = "AddFileToDownloadButton";
            this.AddFileToDownloadButton.Size = new System.Drawing.Size(33, 24);
            this.AddFileToDownloadButton.TabIndex = 23;
            this.toolTip1.SetToolTip(this.AddFileToDownloadButton, "Add file to download list");
            this.AddFileToDownloadButton.UseVisualStyleBackColor = true;
            this.AddFileToDownloadButton.Click += new System.EventHandler(this.AddFileToDownloadButton_Click);
            // 
            // ManualFileAddTextbox
            // 
            this.ManualFileAddTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ManualFileAddTextbox.Location = new System.Drawing.Point(114, 83);
            this.ManualFileAddTextbox.Name = "ManualFileAddTextbox";
            this.ManualFileAddTextbox.Size = new System.Drawing.Size(453, 20);
            this.ManualFileAddTextbox.TabIndex = 24;
            // 
            // NetworkCredsButton
            // 
            this.NetworkCredsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkCredsButton.FlatAppearance.BorderSize = 0;
            this.NetworkCredsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NetworkCredsButton.Image = global::LogViewer.Properties.Resources.Hopstarter_3d_Cartoon_Vol3_Windows_Log_Off;
            this.NetworkCredsButton.Location = new System.Drawing.Point(573, 40);
            this.NetworkCredsButton.Name = "NetworkCredsButton";
            this.NetworkCredsButton.Size = new System.Drawing.Size(33, 34);
            this.NetworkCredsButton.TabIndex = 25;
            this.toolTip1.SetToolTip(this.NetworkCredsButton, "Change Network Account...");
            this.NetworkCredsButton.UseVisualStyleBackColor = true;
            this.NetworkCredsButton.Click += new System.EventHandler(this.NetworkCredsButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = global::LogViewer.Properties.Resources.gear;
            this.SettingsButton.Location = new System.Drawing.Point(573, 13);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(36, 23);
            this.SettingsButton.TabIndex = 26;
            this.toolTip1.SetToolTip(this.SettingsButton, "Log Viewer Settings ...");
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // LogFileDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 555);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.NetworkCredsButton);
            this.Controls.Add(this.ManualFileAddTextbox);
            this.Controls.Add(this.AddFileToDownloadButton);
            this.Controls.Add(this.CancelDownloadButton);
            this.Controls.Add(this.PercentageLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DownloadStatusTextbox);
            this.Controls.Add(this.LogUrlList);
            this.Controls.Add(this.btnClearFile);
            this.Controls.Add(this.dlProgressBar);
            this.Controls.Add(this.txtFilenamePrefix);
            this.Controls.Add(this.lblFilenamePrefix);
            this.Controls.Add(this.chkOverwriteFile);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.getFiles);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.downloadFile);
            this.Controls.Add(this.datePickerTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePickerFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LogFileDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log File Downloader";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileDownloader_FormClosing);
            this.Load += new System.EventHandler(this.LogFileDownloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Button downloadFile;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Button getFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkOverwriteFile;
        private System.Windows.Forms.Label lblFilenamePrefix;
        private System.Windows.Forms.TextBox txtFilenamePrefix;
        private System.Windows.Forms.ProgressBar dlProgressBar;
        private System.Windows.Forms.Button btnClearFile;
        private System.Windows.Forms.ComboBox LogUrlList;
        private System.Windows.Forms.TextBox DownloadStatusTextbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label PercentageLabel;
        private System.Windows.Forms.Button CancelDownloadButton;
        private System.Windows.Forms.Button AddFileToDownloadButton;
        private System.Windows.Forms.TextBox ManualFileAddTextbox;
        private System.Windows.Forms.Button NetworkCredsButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SettingsButton;
        //private System.Windows.Forms.Button cancelDownload;
    }
}

