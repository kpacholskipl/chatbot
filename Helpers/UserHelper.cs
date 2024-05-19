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
                int id = Convert.ToInt32(row["Id"]);
                int subscriptionId = Convert.ToInt32(row["SubscriptionId"]);
                string email = row["Email"].ToString();
                int role = Convert.ToInt32(row["Role"]);
                string password = row["Password"].ToString();
                string createdAt = row["CreatedAt"].ToString();
                string updatedAt = row["UpdatedAt"].ToString();
                string name = row["Name"].ToString();

                User user = new User(id, subscriptionId, email, role, password, createdAt, updatedAt, name);
                users.Add(user);
            }

            return users;
        }
     }
}