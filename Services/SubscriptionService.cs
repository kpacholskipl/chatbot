using System.Data;
using System.Data.SqlClient;
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

        public DataSet GetSubsciprtions() => GetSubsciprtionsData();
        public DataSet GetSubscription(int id) => GetSubsciprtionsData($"id = {id}");
    }
}