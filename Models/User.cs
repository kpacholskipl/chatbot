﻿using System;
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

        public string Password { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public string Name { get; set; }
    }
}
