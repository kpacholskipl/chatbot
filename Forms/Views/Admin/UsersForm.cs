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

namespace ChatBot.Forms.Views.Admin
{
    public partial class UsersForm : Form
    {
        private readonly UserService _userService;
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();

            bindingNavigatorUsers.BindingSource = bindingSourceUsers;
        }

        private void LoadUsers()
        {
            DataSet dataSet = _userService.GetUsers();
            bindingSourceUsers.DataSource = dataSet.Tables["cos tam"];
            dataGridViewUsers.DataSource = bindingSourceUsers;
        }
    }
}
