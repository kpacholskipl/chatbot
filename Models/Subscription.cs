using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int LimitQuery { get; set; }
        public int LimitConversation { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public enum PeriodTypes
        {
            Month,
            Year
        }
        public enum ModelTypes
        {
            Model_3_5_Turbo,
            Model_4
        }
        public PeriodTypes Period { get; set; }
        public ModelTypes Model { get; set; }
        public Subscription(int id, string name, decimal price, PeriodTypes period, ModelTypes model)
        {
            Id = id;
            Name = name;
            Price = price;
            Period = period;
            Model = model;      
        }
        public Subscription(int id, string name, decimal price, PeriodTypes period, ModelTypes model, int limitQuery, int limitConversation)
        {
            Id = id;
            Name = name;
            Price = price;
            Period = period;
            Model = model;
            LimitConversation = limitConversation;
            LimitQuery = limitQuery;

        }
        public Subscription(string name, decimal price, PeriodTypes period, ModelTypes model)
        {
            Name = name;
            Price = price;
            Period = period;
            Model = model;
        }
    }
}
