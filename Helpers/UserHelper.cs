using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

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
                string apiKey = row["api_key"].ToString();

                User user = new User(subscriptionId, email, role, password, name)
                {
                    CreatedAt = createdAt,
                    Id = id,
                    UpdatedAt = updatedAt,
                    ApiKey = apiKey
                };

                users.Add(user);
            }

            return users;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, User user, bool isCreate = false)
        {
            cmd.Parameters.AddWithValue("@subscriptionId", user.SubscriptionId);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@apiKey", user.ApiKey ?? string.Empty);
            if (user.Password.Count() < 33)
            {
                var password = HashPassword(user.Password);
                cmd.Parameters.AddWithValue("@password", password);
            }else
            {
                cmd.Parameters.AddWithValue("@password", user.Password);
            }

            return cmd;
        }
       public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = email.Trim();

                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
    }
}