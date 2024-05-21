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
            periodTypeColumn.ValueMember = "Id";

            var modelTypes = Enum.GetValues(typeof(ModelTypes)).Cast<ModelTypes>().Select((e, index) => new { Id = index, Name = e.ToString() }).ToList();

            DataGridViewComboBoxColumn modelTypeColumn = new DataGridViewComboBoxColumn();
            modelTypeColumn.HeaderText = "Model";
            modelTypeColumn.DataPropertyName = "model";
            modelTypeColumn.DataSource = modelTypes;
            modelTypeColumn.DisplayMember = "Name";
            modelTypeColumn.ValueMember = "Id";

            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "name" });
            dataGridViewSubscriptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "price" });
            dataGridViewSubscriptions.Columns.Add(periodTypeColumn);
            dataGridViewSubscriptions.Columns.Add(modelTypeColumn);
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

                var name = (string)selectedRow.Cells["name"].Value;
                var price = (decimal)selectedRow.Cells["price"].Value;
                var period = (string)selectedRow.Cells["period"].Value;
                Subscription.PeriodTypes periodType = (Subscription.PeriodTypes)Enum.Parse(typeof(Subscription.PeriodTypes), period);
                var model = (string)selectedRow.Cells["model"].Value;
                Subscription.ModelTypes modelType = (Subscription.ModelTypes)Enum.Parse(typeof(Subscription.ModelTypes), model);
                var subscriptionID = (int)selectedRow.Cells["id"].Value;

                var subscription = new Subscription(subscriptionID, name, price, periodType, modelType);

                _subscriptionService.UpdateSubscription(subscription);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewSubscriptions.EndEdit();

            if (dataGridViewSubscriptions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewSubscriptions.SelectedRows[0];

                var name = (string)selectedRow.Cells["name"].Value;
                var price = (decimal)selectedRow.Cells["price"].Value;
                var period = (string)selectedRow.Cells["period"].Value;
                Subscription.PeriodTypes periodType = (Subscription.PeriodTypes)Enum.Parse(typeof(Subscription.PeriodTypes), period);
                var model = (string)selectedRow.Cells["model"].Value;
                Subscription.ModelTypes modelType = (Subscription.ModelTypes)Enum.Parse(typeof(Subscription.ModelTypes), model);

                var subscription = new Subscription(name, price, periodType, modelType);

                _subscriptionService.UpdateSubscription(subscription);
            }
        }
    }
}
