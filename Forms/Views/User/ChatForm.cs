using ChatBot.Helpers;
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

namespace ChatBot.Forms.Views.User
{
    public partial class ChatForm : Form
    {
        private Models.User _loggedUser;
        private int _conversationId = -1;
        private Form currentChildForm;
        private readonly ConversationItemService _conversationItemService = new ConversationItemService();
        private readonly ConversationService _conversationService = new ConversationService();
        private string _title;
        private Category _category;

        public ChatForm(Models.User user)
        {
            InitializeComponent();
            _loggedUser = user;

            var frm = new ChatPropertiesForm(_loggedUser);
            frm.FormClosedEvent += ChatPropertiesForm_FormClosedEvent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _title = frm.Title;
                _category = frm.Category;
                Conversation conversation = new Conversation(_loggedUser.Id, _category.Id, _title);
                conversation = _conversationService.CreateAndGetConversation(conversation);
                _conversationId = conversation.Id;
            }
        }

        private void ChatPropertiesForm_FormClosedEvent(object sender, EventArgs e)
        {
            OpenChildForm(new MyAccountForm(_loggedUser));
        }

        public ChatForm(Models.User user, int conversationId)
        {
            InitializeComponent();
            _loggedUser = user;
            _conversationId = conversationId;

            PrintMessages();
        }

        public void PrintMessages()
        {
            textBoxMessages.Text = "";

            var conversationItems = _conversationItemService.GetListConversationItemsByConversationId(_conversationId);

            conversationItems.OrderBy(item => item.Order).ToList().ForEach(item =>
            {
                if (item.Order % 2 == 0)
                {
                    textBoxMessages.Text += "Assistant:" + Environment.NewLine + item.Message + Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    textBoxMessages.Text += "User:" + Environment.NewLine + item.Message + Environment.NewLine + Environment.NewLine;
                }
            });

            textBoxMessages.SelectionStart = textBoxMessages.Text.Length;
            textBoxMessages.ScrollToCaret();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_loggedUser.ApiKey))
            {
                MessageBox.Show("Please enter an api key");
                OpenChildForm(new MyAccountForm(_loggedUser));
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

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                Conversation conversation = _conversationService.GetConversation(_conversationId);
                if (conversation.Items.Count % 2 == 1)
                {
                    return;
                }
                ConversationItem conversationItem = new ConversationItem(conversation.Id, conversation.Items.Count() + 1, textBoxPrompt.Text);
                _conversationItemService.CreateConversationItem(conversationItem);
                conversation = _conversationService.GetConversation(_conversationId);

                await new ChatHelper().Send(conversation, _loggedUser);

                PrintMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBoxPrompt.Text = "";
            }
        }
    }
}
