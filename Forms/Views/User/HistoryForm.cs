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

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            var conversations = _conversationService.GetConversationsByUser(_loggedUser.Id);
            dataGridViewHistory.DataSource = conversations;

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Action";
            btnColumn.Text = "Show"; 
            btnColumn.Name = "btnAction"; 
            btnColumn.UseColumnTextForButtonValue = true; 
            dataGridViewHistory.Columns.Add(btnColumn);

            dataGridViewHistory.CellContentClick += DataGridViewHistory_CellContentClick;

            dataGridViewHistory.Columns[0].Visible = false;
            dataGridViewHistory.Columns[1].Visible = false;
            dataGridViewHistory.Columns[2].Visible = false;
        }

        private void DataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewHistory.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                var id = (int)dataGridViewHistory.Rows[e.RowIndex].Cells["id"].Value;

                OpenChildForm(new ChatForm(_loggedUser, id));
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
