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
        private int _conversationId;
        private Form currentChildForm;
        private readonly ConversationItemService _conversationItemService = new ConversationItemService();
        private readonly ConversationService _conversationService = new ConversationService();

        public ChatForm(Models.User user)
        {
            InitializeComponent();
            _loggedUser = user;
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
            labelMessages.Text = "";
            textBoxMessages.Text = "";

            var conversationItems = _conversationItemService.GetListConversationItemsByConversationId(_conversationId);

            conversationItems.OrderBy(item => item.Order).ToList().ForEach(item =>
            {
                if (item.Order % 2 == 0)
                {
                    labelMessages.Text += "Assistant:\n" + item.Message + "\n\n";
                    textBoxMessages.Text += "Assistant:\n" + item.Message + "\n\n";
                }
                else
                {
                    labelMessages.Text += "User:\n" + item.Message + "\n\n";
                    textBoxMessages.Text += "User:\n" + item.Message + "\n\n";
                }
            });
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
                ConversationItem conversationItem = new ConversationItem(conversation.Id, conversation.Items.Count() + 1, textBoxPrompt.Text);
                _conversationItemService.CreateConversationItem(conversationItem);
                conversation.Items.Add(conversationItem);

                await new ChatHelper().Send(conversation, _loggedUser);

                PrintMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBoxPrompt.Text = "";
            }
        }
    }
}
