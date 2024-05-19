using ChatBot.Forms.Views.User;
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
        private Form currentChildForm;

        public UserForm()
        {
            InitializeComponent();
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChatForm());
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HistoryForm());
        }

        private void buttonMyAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyAccountForm());
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
    }
}
