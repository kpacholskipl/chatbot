using ChatBot.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatBot.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            var subscriptionService = new SubscriptionService();
            var subscriptions = subscriptionService.GetSubsciprtions();

            subscriptions.ForEach(subscription =>
            {
                comboBoxSubscriptionPlan.Items.Add(subscription);
            });

            comboBoxSubscriptionPlan.DisplayMember = "name";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text ?? "";
            string name = textBoxName.Text ?? "";
            string password = textBoxPassword.Text ?? "";
            string passwordRepeat = textBoxPasswordRepeat.Text ?? "";
            Subscription subscriptionPlan = (Subscription)comboBoxSubscriptionPlan.SelectedItem;

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            if (password != passwordRepeat)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (subscriptionPlan == null)
            {
                MessageBox.Show("Please select a subscription plan.");
                return;
            }

            var newUser = new User(subscriptionPlan.Id, email, 0, password, name);

            var userService = new UserService();
            var isAccountCreated = userService.CreateUser(newUser);

            if (isAccountCreated)
            {
                var frm = new UserForm();
                frm.Show();
                frm.FormClosed += (s, args) => this.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
                return;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
