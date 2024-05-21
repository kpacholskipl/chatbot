using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Models
{
    public class User
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }

        public string Email { get; set; }
        public int Role { get; set; }

        public string Password { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public string Name { get; set; }

        public string ApiKey { get; set; }
        public User(int subscriptionId, string email, int role, string password, string name)
        {
            SubscriptionId = subscriptionId;
            Email = email;
            Role = role;
            Password = password;
            Name = name;
        }

        public User(int id, int subscriptionId, string email, int role, string password, string name)
        {
            Id = id;
            SubscriptionId = subscriptionId;
            Email = email;
            Role = role;
            Password = password;
            Name = name;
        }

        public User(int id, int subscriptionId, string email, int role, string password, string name, string apiKey)
        {
            Id = id;
            SubscriptionId = subscriptionId;
            Email = email;
            Role = role;
            Password = password;
            Name = name;
            ApiKey = apiKey;
        }

        public User(int subscriptionId, string email, int role, string password, string name, string apiKey)
        {
            SubscriptionId = subscriptionId;
            Email = email;
            Role = role;
            Password = password;
            Name = name;
            ApiKey = apiKey;
        }
    }
}
