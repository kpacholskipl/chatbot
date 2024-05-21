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
            PrepareDataGridView();
            LoadUsers();

            bindingNavigatorUsers.BindingSource = bindingSourceUsers;
        }

        private void PrepareDataGridView()
        {
            var subscriptionService = new SubscriptionService();
            var subscriptions = subscriptionService.GetListSubsciprtions();
            DataGridViewComboBoxColumn subscriptionColumn = new DataGridViewComboBoxColumn();
            subscriptionColumn.HeaderText = "Subscription";
            subscriptionColumn.DataPropertyName = "subscription_id";
            subscriptionColumn.DataSource = subscriptions;
            subscriptionColumn.DisplayMember = "Name";
            subscriptionColumn.ValueMember = "Id";

            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 0, Name = "User" }
            };

            DataGridViewComboBoxColumn roleColumn = new DataGridViewComboBoxColumn();
            roleColumn.HeaderText = "Role";
            roleColumn.DataPropertyName = "role";
            roleColumn.DataSource = roles;
            roleColumn.DisplayMember = "Name";
            roleColumn.ValueMember = "Id";

            dataGridViewUsers.Columns.Add(subscriptionColumn);
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "email" });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Password", DataPropertyName = "password" });
            dataGridViewUsers.Columns.Add(roleColumn);
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "name" });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "API Key", DataPropertyName = "api_key" });
        }

        private void LoadUsers()
        {
            DataSet dataSet = _userService.GetUsers();
            bindingSourceUsers.DataSource = dataSet.Tables["users"];
            dataGridViewUsers.DataSource = bindingSourceUsers;
            dataGridViewUsers.Columns[0].Visible = false;
            dataGridViewUsers.Columns[5].Visible = false;
            dataGridViewUsers.Columns[6].Visible = false;
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

                var userID = (int)selectedRow.Cells[0].Value;
                var subscriptionId = (int)selectedRow.Cells[1].Value;
                var email = (string)selectedRow.Cells[2].Value;
                var password = (string)selectedRow.Cells[3].Value;
                var role = (int)selectedRow.Cells[4].Value;
                var name = (string)selectedRow.Cells[7].Value;
                var apiKey = selectedRow.Cells[8]?.Value?.ToString() ?? "";

                var user = new Models.User(userID, subscriptionId, email, role, password, name, apiKey);

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

                var subscriptionId = (int)selectedRow.Cells[1].Value;
                var email = (string)selectedRow.Cells[2].Value;
                var password = (string)selectedRow.Cells[3].Value;
                var role = (int)selectedRow.Cells[4].Value;
                var name = (string)selectedRow.Cells[7].Value;
                var apiKey = selectedRow.Cells[8]?.Value?.ToString() ?? "";

                var user = new Models.User(subscriptionId, email, role, password, name, apiKey);

                _userService.CreateUser(user);
            }
        }
    }
}
