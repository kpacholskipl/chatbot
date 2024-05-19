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
    public partial class SubscriptionsForm : Form
    {
        private readonly SubscriptionService _subscriptionService = new SubscriptionService();
        public SubscriptionsForm()
        {
            InitializeComponent();
        }

        private void SubscriptionsForm_Load(object sender, EventArgs e)
        {
            LoadSubscriptions();

            bindingNavigatorSubscriptions.BindingSource = bindingSourceSubscriptions;
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

                //_subscriptionService.de((int)userID);
                LoadSubscriptions();
            }
            else
            {
                MessageBox.Show("No row selected!");
            }
        }
    }
}
