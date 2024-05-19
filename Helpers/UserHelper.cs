using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class UserHelper
    {
        public static List<User> GetFromDataSet(DataSet ds)
        {
            List<User> users = new List<User>();

            foreach (DataRow row in ds.Tables["Users"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int subscriptionId = Convert.ToInt32(row["subscription_id"]);
                string email = row["email"].ToString();
                int role = Convert.ToInt32(row["role"]);
                string password = row["password"].ToString();
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();
                string name = row["name"].ToString();

                User user = new User(id, subscriptionId, email, role, password, createdAt, updatedAt, name);
                users.Add(user);
            }

            return users;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, User user)
        {
            cmd.Parameters.AddWithValue("@subscriptionId", user.SubscriptionId);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Name);
            cmd.Parameters.AddWithValue("@name", user.Name);

            return cmd;
        }
    }
}