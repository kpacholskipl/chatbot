using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class SubscriptionHelper
    {
        public static List<Subscription> GetFromDataSet(DataSet ds)
        {
            List<Subscription> Subscriptions = new List<Subscription>();

            foreach (DataRow row in ds.Tables["Subscriptions"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                decimal role = Convert.ToDecimal(row["price"]);

                Subscription Subscription = new Subscription(id, name, role);
                Subscriptions.Add(Subscription);
            }

            return Subscriptions;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, Subscription Subscription)
        {
            //cmd.Parameters.AddWithValue("@subscriptionId", Subscription.SubscriptionId);
            //cmd.Parameters.AddWithValue("@email", Subscription.Email);
            //cmd.Parameters.AddWithValue("@password", Subscription.Password);
            //cmd.Parameters.AddWithValue("@role", Subscription.Name);
            //cmd.Parameters.AddWithValue("@name", Subscription.Name);

            return cmd;
        }
    }
}