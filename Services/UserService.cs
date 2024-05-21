using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class UserService
    {
        private DataSet GetUsersData(string where = "")
        {
            string query = "Select * from users";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().SelectQuery(query, "Users");
        }

        public List<User> GetListUsers() => UserHelper.GetFromDataSet(GetUsersData());

        public List<User> GetUsersBySubscriptionId(int id) => UserHelper.GetFromDataSet(GetUsersData($"subscription_id = {id}"));

        public DataSet GetUsers() => GetUsersData();
        public User GetUser(int id) => UserHelper.GetFromDataSet(GetUsersData($"id = {id}")).FirstOrDefault();
        public User Login(string email, string password) => UserHelper.GetFromDataSet(GetUsersData($"email = '{email}' AND password = '{password}'")).FirstOrDefault();

        public bool CreateUser(User user)
        {
            SqlCommand cmd = new SqlCommand("Insert into users (subscription_id, email, password, role, name, api_key) VALUES (@subscriptionId, @email, @password, @role, @name, @apiKey)");
            cmd = UserHelper.AddParametrsToSqlCommand(cmd, user);
            return new DatabaseHelper().InsertCommand(cmd);
        }
        public bool UpdateUser(User user)
        {
            SqlCommand cmd = new SqlCommand("Update users SET subscription_id = @subscriptionId, email = @email, password = @password, role = @role,name = @name, api_key = @apiKey WHERE id = @id");
            cmd = UserHelper.AddParametrsToSqlCommand(cmd, user);
            cmd.Parameters.AddWithValue("@id", user.Id);
            return new DatabaseHelper().UpdateCommand(cmd);
        }
        public bool DeleteUser (int id)
        {
            return new DatabaseHelper().DeleteQuery($"Delete from users where id = {id}");
        }
    }
}