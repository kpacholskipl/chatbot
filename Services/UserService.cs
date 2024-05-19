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

        public DataSet GetUsers() => GetUsersData();
        public DataSet GetUser(int id) => GetUsersData($"id = {id}");
        public User Login(string email, string password) => UserHelper.GetFromDataSet(GetUsersData($"email = '{email}' AND password = '{password}'")).FirstOrDefault();
    }
}