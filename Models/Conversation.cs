﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set;}

        public List<ConversationItem> Items { get; set; }

        public Conversation(int id, int userId, int categoryId, string title)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
        }

        public Conversation(int userId, int categoryId, string title)
        {
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
        }
    }
}
