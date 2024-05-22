using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class ConversationItemService
    {
        private DataSet GetConversationItems(string where = "")
        {
            string query = "Select * from conversation_items";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().SelectQuery(query, "conversation_items");
        }

        public List<ConversationItem> GetListConversationItems() => ConversationItemHelper.GetFromDataSet(GetConversationItems());
        
        public DataSet GetConversationItems() => GetConversationItems();
        public ConversationItem GetConversationItem(int id) => ConversationItemHelper.GetFromDataSet(GetConversationItems($"id = {id}")).FirstOrDefault();

        public List<ConversationItem> GetListConversationItemsByConversationId(int conversationId) => ConversationItemHelper.GetFromDataSet(GetConversationItems($"conversation_id = {conversationId}"));

        public bool CreateConversationItem(ConversationItem conversationItem)
        {
            SqlCommand cmd = new SqlCommand("Insert into conversation_items (conversation_id, [order], message) VALUES (@conversationId, @order, @message)");
            cmd = ConversationItemHelper.AddParametrsToSqlCommand(cmd, conversationItem);
            return new DatabaseHelper().InsertCommand(cmd);
        }
    }
}





