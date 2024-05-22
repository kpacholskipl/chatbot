using ChatBot.Forms.Views.User;
using ChatBot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot.Forms
{
    public partial class UserForm : Form
    {
        private Models.User _loggedUser;
        private Form currentChildForm;

        public UserForm(Models.User user)
        {
            InitializeComponent();
            _loggedUser = user;
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChatForm(_loggedUser));
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HistoryForm(_loggedUser));
        }

        private void buttonMyAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyAccountForm(_loggedUser));
        }
        private void OpenChildForm(Form childForm)
        {
            currentChildForm?.Close();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new ChatForm(_loggedUser));
        }
    }
}
