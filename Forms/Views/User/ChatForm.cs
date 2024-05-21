using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot.Forms.Views.User
{
    public partial class ChatForm : Form
    {
        private Models.User _loggedUser;
        private Form currentChildForm;

        public ChatForm(Models.User user)
        {
            InitializeComponent();
            _loggedUser = user;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_loggedUser.ApiKey))
            {
                MessageBox.Show("Please enter an api key");
                OpenChildForm(new MyAccountForm(_loggedUser));
            }

        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
