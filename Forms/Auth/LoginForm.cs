using ChatBot.Services;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.LoginAction();
        }

        private void LoginAction()
        {
            string email = textBoxEmail.Text ?? "";
            string password = textBoxPassword.Text ?? "";

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
               
                var userService = new UserService();
                var user = userService.Login(email, password);


                if (user != null)
                {
                    if (user.Role == 1)
                    {
                        var frm = new AdminForm();
                        frm.Show();
                        frm.FormClosed += (s, args) => this.Close();
                    }
                    else if (user.Role == 0)
                    {
                        var frm = new UserForm();
                        frm.Show();
                        frm.FormClosed += (s, args) => this.Close();
                    }
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("The data entered was incorrect");
            }
        }

        private void buttonFillAdmin_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "user4@example.com";
            textBoxPassword.Text = "password4";
        }

        private void buttonFillUser_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "user1@example.com";
            textBoxPassword.Text = "password1";
        }
    }
}
