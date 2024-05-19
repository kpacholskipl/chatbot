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
            this.loginAction();
        }

        private void loginAction()
        {
            string email = textBoxEmail.Text ?? "";
            string password = textBoxPassword.Text ?? "";

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var userService = new UserService();
                var userDataSet = userService.Login(email, password);

                if (userDataSet != null)
                {
                    var isAdmin = (int)userDataSet.Tables["Users"].Rows[0]["role"];

                    if (isAdmin == 1) {
                        var frm = new AdminForm();
                        frm.Show();
                    }
                    //else if (isAdmin == 0)
                    //{
                    //    var frm = new UserForm;
                    //    frm.Show();
                    //}
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("The data entered was incorrect");
            }
        }
    }
}
