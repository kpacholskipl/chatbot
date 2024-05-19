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
        private readonly UserService _userService = new UserService();
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
            bindingSourceUsers.DataSource = dataSet.Tables["users"];
            dataGridViewUsers.DataSource = bindingSourceUsers;
            dataGridViewUsers.Columns[0].Visible = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewUsers.EndEdit();

            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];

                if (selectedRow.IsNewRow || selectedRow.Index == dataGridViewUsers.Rows.Count - 1)
                {
                    MessageBox.Show("Select not empty row!");
                    return;
                }

                var userID = selectedRow.Cells["id"].Value;

                if (userID == null || string.IsNullOrEmpty(userID.ToString()))
                {
                    MessageBox.Show("You cannot delete a user with an empty or null ID!");
                    return;
                }
  
                _userService.DeleteUser((int)userID);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("No row selected!");
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewUsers.EndEdit();

            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];

                var email = (string)selectedRow.Cells["email"].Value;
                var password = (string)selectedRow.Cells["password"].Value;
                var name = (string)selectedRow.Cells["name"].Value;
                var role = (int)selectedRow.Cells["role"].Value;
                var subscriptionId = (int)selectedRow.Cells["subscription_id"].Value;
                var userID = (int)selectedRow.Cells["id"].Value;

                var user = new Models.User(userID, subscriptionId, email, role, password, name);

                _userService.UpdateUser(user);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewUsers.EndEdit();

            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];

                var email = (string)selectedRow.Cells["email"].Value;
                var password = (string)selectedRow.Cells["password"].Value;
                var name = (string)selectedRow.Cells["name"].Value;
                var role = (int)selectedRow.Cells["role"].Value;
                var subscriptionId = (int)selectedRow.Cells["subscription_id"].Value;

                var user = new Models.User(subscriptionId, email, role, password, name);

                _userService.CreateUser(user);
            }
        }
    }
}
