﻿using System;
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
            return new DatabaseHelper().ExecuteQuery(query, "Users");
        }

        public List<User> GetUsers() => UserHelper.GetFromDataSet(GetUsersData());
        public User GetUser(int id) => UserHelper.GetFromDataSet(GetUsersData($"id = {id}")).FirstOrDefault();
        public User Login(string email, string password) => UserHelper.GetFromDataSet(GetUsersData($"email = '{email}' AND password = '{password}'")).FirstOrDefault();

        public bool CreateUser(User user)
        {
            SqlCommand cmd = new SqlCommand("Insert into users (subscription_id, email, password,role,name) VALUES (@subscriptionId,@email,@password,@role,@name)");
            cmd = UserHelper.AddParametrsToSqlCommand(cmd, user);
            return new DatabaseHelper().ExecuteNonCommand(cmd);
        }
    }
}