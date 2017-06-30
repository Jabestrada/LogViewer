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
            this.SourceDirTextbox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.FileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FileTypeFilterTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.LogViewerDisplay = new System.Windows.Forms.RichTextBox();
            this.LineNumberStart = new System.Windows.Forms.NumericUpDown();
            this.LineNumberEnd = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ApplyLineFilterButton = new System.Windows.Forms.Button();
            this.OpenFileProgram = new System.Windows.Forms.TextBox();
            this.SetupListenerButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnApplyFilterAllFiles = new System.Windows.Forms.Button();
            this.btnShowLogFileDownloader = new System.Windows.Forms.Button();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.GetFilesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumberStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumberEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceDirTextbox
            // 
            this.SourceDirTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceDirTextbox.Location = new System.Drawing.Point(106, 16);
            this.SourceDirTextbox.Name = "SourceDirTextbox";
            this.SourceDirTextbox.Size = new System.Drawing.Size(335, 20);
            this.SourceDirTextbox.TabIndex = 1;
            this.SourceDirTextbox.Text = "D:\\Web\\ACN21338\\Data\\logs";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(154, 234);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(540, 20);
            this.textBox2.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(707, 718);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Word wrap";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FileList
            // 
            this.FileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(12, 79);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(773, 108);
            this.FileList.TabIndex = 6;
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            this.FileList.DoubleClick += new System.EventHandler(this.FileList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File content line filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filename filter:";
            // 
            // FileTypeFilterTextbox
            // 
            this.FileTypeFilterTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTypeFilterTextbox.Location = new System.Drawing.Point(104, 43);
            this.FileTypeFilterTextbox.Name = "FileTypeFilterTextbox";
            this.FileTypeFilterTextbox.Size = new System.Drawing.Size(119, 20);
            this.FileTypeFilterTextbox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Source directory:";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(12, 192);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(136, 32);
            this.OpenFileButton.TabIndex = 7;
            this.OpenFileButton.Text = "Open selected file using";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // LogViewerDisplay
            // 
            this.LogViewerDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogViewerDisplay.BackColor = System.Drawing.Color.Cornsilk;
            this.LogViewerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogViewerDisplay.HideSelection = false;
            this.LogViewerDisplay.Location = new System.Drawing.Point(12, 294);
            this.LogViewerDisplay.Name = "LogViewerDisplay";
            this.LogViewerDisplay.ReadOnly = true;
            this.LogViewerDisplay.Size = new System.Drawing.Size(776, 418);
            this.LogViewerDisplay.TabIndex = 20;
            this.LogViewerDisplay.Text = "";
            this.LogViewerDisplay.WordWrap = false;
            // 
            // LineNumberStart
            // 
            this.LineNumberStart.Location = new System.Drawing.Point(84, 265);
            this.LineNumberStart.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.LineNumberStart.Name = "LineNumberStart";
            this.LineNumberStart.Size = new System.Drawing.Size(64, 20);
            this.LineNumberStart.TabIndex = 15;
            // 
            // LineNumberEnd
            // 
            this.LineNumberEnd.Location = new System.Drawing.Point(229, 265);
            this.LineNumberEnd.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.LineNumberEnd.Name = "LineNumberEnd";
            this.LineNumberEnd.Size = new System.Drawing.Size(56, 20);
            this.LineNumberEnd.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Line # Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Line # End";
            // 
            // ApplyLineFilterButton
            // 
            this.ApplyLineFilterButton.Location = new System.Drawing.Point(293, 264);
            this.ApplyLineFilterButton.Name = "ApplyLineFilterButton";
            this.ApplyLineFilterButton.Size = new System.Drawing.Size(123, 23);
            this.ApplyLineFilterButton.TabIndex = 18;
            this.ApplyLineFilterButton.Text = "Apply Line Filter";
            this.ApplyLineFilterButton.UseVisualStyleBackColor = true;
            this.ApplyLineFilterButton.Click += new System.EventHandler(this.ApplyLineFilterButton_Click);
            // 
            // OpenFileProgram
            // 
            this.OpenFileProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileProgram.Location = new System.Drawing.Point(154, 199);
            this.OpenFileProgram.Name = "OpenFileProgram";
            this.OpenFileProgram.Size = new System.Drawing.Size(540, 20);
            this.OpenFileProgram.TabIndex = 22;
            // 
            // SetupListenerButton
            // 
            this.SetupListenerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SetupListenerButton.Location = new System.Drawing.Point(571, 262);
            this.SetupListenerButton.Name = "SetupListenerButton";
            this.SetupListenerButton.Size = new System.Drawing.Size(123, 23);
            this.SetupListenerButton.TabIndex = 23;
            this.SetupListenerButton.Text = "Set up listener...";
            this.SetupListenerButton.UseVisualStyleBackColor = true;
            this.SetupListenerButton.Click += new System.EventHandler(this.SetupListenerButton_Click);
            // 
            // btnApplyFilterAllFiles
            // 
            this.btnApplyFilterAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilterAllFiles.FlatAppearance.BorderSize = 0;
            this.btnApplyFilterAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilterAllFiles.Image = global::LogViewer.Properties.Resources.magnifier_zoom_in;
            this.btnApplyFilterAllFiles.Location = new System.Drawing.Point(744, 231);
            this.btnApplyFilterAllFiles.Name = "btnApplyFilterAllFiles";
            this.btnApplyFilterAllFiles.Size = new System.Drawing.Size(41, 23);
            this.btnApplyFilterAllFiles.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnApplyFilterAllFiles, "Apply filter to all files");
            this.btnApplyFilterAllFiles.UseVisualStyleBackColor = true;
            this.btnApplyFilterAllFiles.Click += new System.EventHandler(this.btnApplyFilterAllFiles_Click);
            // 
            // btnShowLogFileDownloader
            // 
            this.btnShowLogFileDownloader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowLogFileDownloader.FlatAppearance.BorderSize = 0;
            this.btnShowLogFileDownloader.Image = global::LogViewer.Properties.Resources.arrow_curve_270;
            this.btnShowLogFileDownloader.Location = new System.Drawing.Point(621, 12);
            this.btnShowLogFileDownloader.Name = "btnShowLogFileDownloader";
            this.btnShowLogFileDownloader.Size = new System.Drawing.Size(164, 40);
            this.btnShowLogFileDownloader.TabIndex = 8;
            this.btnShowLogFileDownloader.Text = "Log Files Downloader...";
            this.btnShowLogFileDownloader.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.btnShowLogFileDownloader, "Launch Log Files Downloader");
            this.btnShowLogFileDownloader.UseVisualStyleBackColor = true;
            this.btnShowLogFileDownloader.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFolderButton.FlatAppearance.BorderSize = 0;
            this.OpenFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFolderButton.Image = global::LogViewer.Properties.Resources.folder_horizontal_open;
            this.OpenFolderButton.Location = new System.Drawing.Point(447, 15);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(31, 23);
            this.OpenFolderButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.OpenFolderButton, "Open folder in Explorer");
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // GetFilesButton
            // 
            this.GetFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetFilesButton.FlatAppearance.BorderSize = 0;
            this.GetFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetFilesButton.Image = global::LogViewer.Properties.Resources.magnifier_zoom;
            this.GetFilesButton.Location = new System.Drawing.Point(229, 42);
            this.GetFilesButton.Name = "GetFilesButton";
            this.GetFilesButton.Size = new System.Drawing.Size(29, 23);
            this.GetFilesButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.GetFilesButton, "List files");
            this.GetFilesButton.UseVisualStyleBackColor = true;
            this.GetFilesButton.Click += new System.EventHandler(this.GetFilesButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::LogViewer.Properties.Resources.magnifier_zoom;
            this.button1.Location = new System.Drawing.Point(696, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 29);
            this.button1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button1, "Apply filter to selected file");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 741);
            this.Controls.Add(this.SetupListenerButton);
            this.Controls.Add(this.OpenFileProgram);
            this.Controls.Add(this.btnApplyFilterAllFiles);
            this.Controls.Add(this.btnShowLogFileDownloader);
            this.Controls.Add(this.ApplyLineFilterButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LineNumberEnd);
            this.Controls.Add(this.LineNumberStart);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.LogViewerDisplay);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FileTypeFilterTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GetFilesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.SourceDirTextbox);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LineNumberStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineNumberEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SourceDirTextbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetFilesButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileTypeFilterTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.RichTextBox LogViewerDisplay;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.NumericUpDown LineNumberStart;
        private System.Windows.Forms.NumericUpDown LineNumberEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ApplyLineFilterButton;
        private System.Windows.Forms.Button btnShowLogFileDownloader;
        private System.Windows.Forms.Button btnApplyFilterAllFiles;
        private System.Windows.Forms.TextBox OpenFileProgram;
        private System.Windows.Forms.Button SetupListenerButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

