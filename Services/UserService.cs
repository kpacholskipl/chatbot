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
            return new DatabaseHelper().GetByAdapter(query, "Users");
        }

        public DataSet GetUsers()
        {
            return GetUsersData();
        }
        public DataSet GetUser(string id)
        {
            return GetUsersData("id = " + id);
        }
      
    }
}