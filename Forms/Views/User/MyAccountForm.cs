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

namespace ChatBot.Forms.Views.User
{
    public partial class MyAccountForm : Form
    {
        private Models.User _loggedUser;
        private readonly UserService _userService = new UserService();
        public MyAccountForm(Models.User user)
        {
            InitializeComponent();
            _loggedUser = user;
            textBoxApiKey.Text = _loggedUser.ApiKey;
            textBoxName.Text = _loggedUser.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var apiKey = textBoxApiKey.Text;
            var name = textBoxName.Text;

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Please enter an api key");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name");
                return;
            }

            _loggedUser.ApiKey = apiKey;
            _loggedUser.Name = name;
            _userService.UpdateUser(_loggedUser);
        }

        private void MyAccountForm_Load(object sender, EventArgs e)
        {

        }
    }
}
