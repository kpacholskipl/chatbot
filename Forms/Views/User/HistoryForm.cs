using ChatBot.Helpers;
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
    public partial class HistoryForm : Form
    {
        private Models.User _loggedUser;
        private readonly ConversationService _conversationService = new ConversationService();
        private Form currentChildForm;
        public HistoryForm(Models.User loggedUser)
        {
            InitializeComponent();
            _loggedUser = loggedUser;
        }

        public void LoadData()
        {
            var conversations = _conversationService.GetConversationsByUser(_loggedUser.Id);
            dataGridViewHistory.DataSource = conversations;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadData();

            DataGridViewButtonColumn btnShowColumn = new DataGridViewButtonColumn();
            btnShowColumn.HeaderText = "Action";
            btnShowColumn.Text = "Show";
            btnShowColumn.Name = "btnShow";
            btnShowColumn.UseColumnTextForButtonValue = true;
            dataGridViewHistory.Columns.Add(btnShowColumn);

            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.HeaderText = "Delete";
            btnDeleteColumn.Text = "Delete";
            btnDeleteColumn.Name = "btnDelete";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            dataGridViewHistory.Columns.Add(btnDeleteColumn);

            dataGridViewHistory.CellContentClick += DataGridViewHistory_CellContentClick;

            dataGridViewHistory.Columns[0].Visible = false;
            dataGridViewHistory.Columns[1].Visible = false;
            dataGridViewHistory.Columns[2].Visible = false;
        }

        private void DataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewHistory.Columns["btnShow"].Index)
            {
                var id = (int)dataGridViewHistory.Rows[e.RowIndex].Cells["id"].Value;
                OpenChildForm(new ChatForm(_loggedUser, id));
            }

            if (e.ColumnIndex == dataGridViewHistory.Columns["btnDelete"].Index)
            {
                var id = (int)dataGridViewHistory.Rows[e.RowIndex].Cells["id"].Value;
                _conversationService.DeleteConversation(id);
                LoadData();
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
