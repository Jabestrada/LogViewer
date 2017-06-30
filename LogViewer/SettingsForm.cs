﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class SettingsForm : Form
    {
        public LogsDownloaderUserSettings UserSettings;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            UserSettings = new LogsDownloaderUserSettings();
            UserSettings.WindowTitle = WindowTitleTextbox.Text;
        }
    }
}
