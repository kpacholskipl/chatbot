using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class SubscriptionService
    {
        private DataSet GetSubsciprtionsData(string where = "")
        {
            string query = "Select * from subscriptions";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().SelectQuery(query, "Subscriptions");
        }

        public List<Subscription> GetListSubsciprtions() => SubscriptionHelper.GetFromDataSet(GetSubsciprtionsData());
        public DataSet GetSubsciprtions() =>GetSubsciprtionsData();
        public Subscription GetSubsciprtion(int id) => SubscriptionHelper.GetFromDataSet(GetSubsciprtionsData($"id = {id}")).FirstOrDefault();
      
        public bool CreatSubscription(Subscription subscription)
        {
            SqlCommand cmd = new SqlCommand("Insert into subscriptions (name, price, model, period, limit_query, limit_conversation) VALUES (@name, @price, @model, @period, @limit, @conversation)");
            cmd = SubscriptionHelper.AddParametrsToSqlCommand(cmd, subscription);
            return new DatabaseHelper().InsertCommand(cmd);

        }
        public bool UpdateSubscription(Subscription subscription)
        {
            //SqlCommand cmd = new SqlCommand("Update subscriptions SET name = @name, price = @price, model = @model, period = @period, limit_query = @query, limit_conversation = @conversation WHERE id = @id");
            SqlCommand cmd = new SqlCommand("Update subscriptions SET name = @name, price = @price, model = @model, period = @period, limit_query = @limit WHERE id = @id");
            cmd = SubscriptionHelper.AddParametrsToSqlCommand(cmd, subscription);
            cmd.Parameters.AddWithValue("@id", subscription.Id);
           return new DatabaseHelper().UpdateCommand(cmd);
        }
        public bool DeleteSubscription(int id)
        {
            return new DatabaseHelper().DeleteQuery($"Delete from subscriptions where id = {id}");
        }
    }
}





