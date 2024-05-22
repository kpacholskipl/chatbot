using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using OpenAI_API;
using System.Net.Http;
using System.Collections;
using ChatBot.Services;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.ApplicationServices;

namespace ChatBot.Helpers
{
    public class ChatHelper
    {
        public async Task Send(Conversation conversation, Models.User user)
        {
            if (conversation.Items.Count() == 0)
            {
                throw new Exception("Brak wiadomości");
            }
            if (conversation.Items.Count() % 2  == 0)
            {
                throw new Exception("Ostatnia wiadomość to nie twoja wiadomość");
            }
            string apiKey = user.ApiKey;
            string apiUrl = "https://api.openai.com/v1/chat/completions";

            string queryPrompt = conversation.Items.LastOrDefault().Message.ToString();

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            string model = GetModel(new SubscriptionService().GetSubsciprtion(user.SubscriptionId).Model.ToString());

            var request = new
            {
                model,
                messages = GetMessages(conversation),
            };

            var jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseContent);

                string msg = jsonResponse["choices"][0]["message"]["content"].ToString();

                ConversationItem conversationItem = new ConversationItem(conversation.Id, conversation.Items.Count() + 1, msg);
                new ConversationItemService().CreateConversationItem(conversationItem);

            }
            else
            {
                Console.WriteLine($"Error performing search. Status code: {response.StatusCode}");
            }
        }
        public static string GetModel(string model)
        {
            switch (model)
            {
                case "Model_4":
                    return "gpt-4";
                case "Model_3_5_Turbo":
                    return "gpt-3.5-turbo";
                default:
                    return "gpt-3.5-turbo";
            }
        }
        public static object GetMessages(Conversation conversation)
        {
            var sortedItems = conversation.Items.OrderBy(item => item.Order).ToList();


            string category = GetModel(new CategoryService().GetCategory(conversation.CategoryId).ToString());
            var messages = new List<object>
            {
                new
                {
                    role = "system",
                    content = $"Your are a helpful assistant in {category}. Allways says truth."
                }
            };

            messages.AddRange(sortedItems.Select((item, index) => new
            {
                role = index % 2 == 0 ? "user" : "assistant",
                content = item.Message
            }));
            return messages.ToArray();
        }
    }
}