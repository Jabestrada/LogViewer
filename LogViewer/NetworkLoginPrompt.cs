using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class NetworkLoginPrompt : Form
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }

        public NetworkLoginPrompt()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SetCredentials(NetworkCredential creds) {
            if (creds != null)
            {
                UsernameTextbox.Text = creds.UserName;
                DomainTextbox.Text = creds.Domain;
                PasswordTextbox.Text = creds.Password;
            }
            else {
                UsernameTextbox.Text = Environment.UserName;
            }
        }
        private void NetworkLoginPrompt_Load(object sender, EventArgs e)
        {
            
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            UserName = UsernameTextbox.Text;
            Password = PasswordTextbox.Text;
            Domain = DomainTextbox.Text;
        }
    }
}
