using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Models
{
    public class ConversationItem
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public int Order { get; set; }
        public string Message { get; set; }

       


    }
}
