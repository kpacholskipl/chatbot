using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public DataSet GetUsers() => GetUsersData();
        public DataSet GetUser(int id) => GetUsersData($"id = {id}");
        public DataSet Login(string email, string password)
        {
            DataSet data = GetUsersData($"email = '{email}' AND password = '{password}'");
            var test = new User().GetFromDataSet(data)[0];
            return GetUsersData($"email = '{email}' AND password = '{password}'");
        }
    }
}