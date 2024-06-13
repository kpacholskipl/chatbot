using ChatBot.Models;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChatBot.Models.Subscription;

namespace ChatBot.Forms.Views.Admin
{
    public partial class SubscriptionsForm : Form
    {
        private readonly SubscriptionService _subscriptionService = new SubscriptionService();
        public SubscriptionsForm()
        {
            InitializeComponent();
        }

        private void SubscriptionsForm_Load(object sender, EventArgs e)
        {
            PrepareDataGridView();
            LoadSubscriptions();

            bindingNavigatorSubscriptions.BindingSource = bindingSourceSubscriptions;
        }
        private void PrepareDataGridView()
        {
            var periodTypes = Enum.GetValues(typeof(PeriodTypes)).Cast<PeriodTypes>().Select((e, index) => new { Id = index, Name = e.ToString() }).ToList();

            DataGridViewComboBoxColumn periodTypeColumn = new DataGridViewComboBoxColumn();
            periodTypeColumn.HeaderText = "Period";
            periodTypeColumn.DataPropertyName = "period";
            periodTypeColumn.DataSource = periodTypes;
            periodTypeColumn.DisplayMember = "Name";
            periodTypeColumn.ValueMember = "Name";

            var modelTypes = Enum.GetValues(typeof(ModelTypes)).Cast<ModelTypes>().Select((e, index) => new { Id = index, Name = e.ToString() }).ToList();

            DataGridViewComboBoxColumn modelTypeColumn = new DataGridViewComboBoxColumn();
            modelTypeColumn.HeaderText = "Model";
            modelTypeColumn.DataPropertyName = "model";
            modelTypeColumn.DataSource = modelTypes;
            modelTypeColumn.DisplayMember = "Name";
            modelTypeColumn.ValueMember = "Name";

            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "name" });
            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "price" });
            dataGridViewSubscriptions.Columns.Add(periodTypeColumn);
            dataGridViewSubscriptions.Columns.Add(modelTypeColumn);
            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Limit of queries", DataPropertyName = "limit_query" });
            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Limit of conversations", DataPropertyName = "limit_conversation" });
        }

        private void LoadSubscriptions()
        {
            DataSet dataSet = _subscriptionService.GetSubsciprtions();
            bindingSourceSubscriptions.DataSource = dataSet.Tables["subscriptions"];
            dataGridViewSubscriptions.DataSource = bindingSourceSubscriptions;
            dataGridViewSubscriptions.Columns[0].Visible = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewSubscriptions.EndEdit();

            if (dataGridViewSubscriptions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSubscriptions.SelectedRows[0];

                if (selectedRow.IsNewRow || selectedRow.Index == dataGridViewSubscriptions.Rows.Count - 1)
                {
                    MessageBox.Show("Select not empty row!");
                    return;
                }

                var subscriptionID = selectedRow.Cells["id"].Value;

                if (subscriptionID == null || string.IsNullOrEmpty(subscriptionID.ToString()))
                {
                    MessageBox.Show("You cannot delete a subscription with an empty or null ID!");
                    return;
                }

                var userService = new UserService();
                if (userService.GetUsersBySubscriptionId((int)subscriptionID).Count() > 0)
                {
                    MessageBox.Show("You cannot delete a subscription, the subscription is assigned to the user");
                    return;
                }

                _subscriptionService.DeleteSubscription((int)subscriptionID);
                LoadSubscriptions();
            }
            else
            {
                MessageBox.Show("No row selected!");
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewSubscriptions.EndEdit();

            if (dataGridViewSubscriptions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSubscriptions.SelectedRows[0];

                if (selectedRow.IsNewRow || selectedRow.Index == dataGridViewSubscriptions.Rows.Count - 1)
                {
                    MessageBox.Show("Select not empty row!");
                    return;
                }

                var name = selectedRow.Cells[1].Value?.ToString();
                decimal price;
                if (!decimal.TryParse(selectedRow.Cells[2].Value?.ToString(), out price))
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }

                var period = selectedRow.Cells[3].Value?.ToString();
                var model = selectedRow.Cells[4].Value?.ToString();
                var limitQuery = (int)selectedRow.Cells[5]?.Value;
                var limitConversation = (int)selectedRow.Cells[6]?.Value;
                var subscriptionID = selectedRow.Cells[0].Value;
                if (subscriptionID == null || string.IsNullOrEmpty(subscriptionID.ToString()))
                {
                    MessageBox.Show("You cannot update, first add this to data base");
                    return;
                }

                if (ValidateFields(name, price, period, model, limitQuery, limitConversation))
                {
                    Subscription.PeriodTypes periodType;
                    if (!Enum.TryParse(period, out periodType))
                    {
                        MessageBox.Show("Invalid period type.");
                        return;
                    }

                    Subscription.ModelTypes modelType;
                    if (!Enum.TryParse(model, out modelType))
                    {
                        MessageBox.Show("Invalid model type.");
                        return;
                    }

                    var subscription = new Subscription((int)subscriptionID, name, price, periodType, modelType, limitQuery, limitConversation);

                    _subscriptionService.UpdateSubscription(subscription);
                    LoadSubscriptions();
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewSubscriptions.EndEdit();

            if (dataGridViewSubscriptions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSubscriptions.SelectedRows[0];

                int selectedIndex = selectedRow.Index;
                int lastIndex = dataGridViewSubscriptions.Rows.Count - 2;

                if (selectedIndex != lastIndex)
                {
                    MessageBox.Show("You can't do it, start typing new values and then try to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var name = selectedRow.Cells[1].Value?.ToString();
                decimal price;
                if (!decimal.TryParse(selectedRow.Cells[2].Value?.ToString(), out price))
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }

                var period = selectedRow.Cells[3].Value?.ToString();
                var model = selectedRow.Cells[4].Value?.ToString();
                var limitQuery = (int)selectedRow.Cells[5]?.Value;
                var limitConversation = (int)selectedRow.Cells[6]?.Value;

                if (ValidateFields(name, price, period, model, limitQuery, limitConversation))
                {
                    Subscription.PeriodTypes periodType;
                    if (!Enum.TryParse(period, out periodType))
                    {
                        MessageBox.Show("Invalid period type.");
                        return;
                    }

                    Subscription.ModelTypes modelType;
                    if (!Enum.TryParse(model, out modelType))
                    {
                        MessageBox.Show("Invalid model type.");
                        return;
                    }

                    var subscription = new Subscription(name, price, periodType, modelType, limitQuery, limitConversation);

                    _subscriptionService.CreatSubscription(subscription);
                    LoadSubscriptions();
                }
            }
        }

        private bool ValidateFields(string name, decimal price, string period, string model, int limitQuery, int limitConversation)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }

            if (price <= 0)
            {
                MessageBox.Show("Please enter a valid price.");
                return false;
            }

            if (string.IsNullOrEmpty(period) || !Enum.IsDefined(typeof(Subscription.PeriodTypes), period))
            {
                MessageBox.Show("Please select a valid period.");
                return false;
            }

            if (string.IsNullOrEmpty(model) || !Enum.IsDefined(typeof(Subscription.ModelTypes), model))
            {
                MessageBox.Show("Please select a valid model.");
                return false;
            }

            if (limitQuery <= 0 || limitConversation <= 0)
            {
                MessageBox.Show("Please enter a valid limit.");
                return false;
            }

            return true;
        }
    }
}
