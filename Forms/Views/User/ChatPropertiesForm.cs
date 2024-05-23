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
    public partial class ChatPropertiesForm : Form
    {
        private Models.User _loggedUser;
        private Form currentChildForm;
        public event EventHandler FormClosedEvent;
        public string Title { get; set; }
        public Category Category { get; set; }

        public ChatPropertiesForm(Models.User loggedUser)
        {
            InitializeComponent();
            _loggedUser = loggedUser;
        }

        private void ChatPropertiesForm_Load(object sender, EventArgs e)
        {
            var categoryService = new CategoryService();
            var categories = categoryService.GetListCategories();

            categories.ForEach(subscription =>
            {
                comboBoxCategory.Items.Add(subscription);
            });

            comboBoxCategory.DisplayMember = "name";
            this.ControlBox = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var title = textBoxTitle.Text;
            var category = (Category)comboBoxCategory.SelectedItem;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Enter a title");
                return;
            }

            if (category == null)
            {
                MessageBox.Show("Select a category");
                return;
            }

            Title = title;
            Category = category;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
            this.Close();
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
