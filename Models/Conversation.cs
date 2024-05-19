using System;
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        public List<ConversationItem> Items { get; set; }

        public Conversation(int id, int userId, int categoryId, string title)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
        }
    }
}
