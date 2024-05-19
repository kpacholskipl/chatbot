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
            return new DatabaseHelper().ExecuteQuery(query, "Subscriptions");
        }

        public List<Subscription> GetSubsciprtions() => SubscriptionHelper.GetFromDataSet(GetSubsciprtionsData());
        public Subscription GetSubsciprtion(int id) => SubscriptionHelper.GetFromDataSet(GetSubsciprtionsData($"id = {id}")).FirstOrDefault();
    }
}





