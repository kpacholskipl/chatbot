using ChatBot.Forms.Views.Admin;
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
    public partial class AdminForm : Form
    {
        private Form currentChildForm;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UsersForm());
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoriesForm());
        }

        private void buttonSubscriptions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubscriptionsForm());
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new UsersForm());
        }
    }
}
