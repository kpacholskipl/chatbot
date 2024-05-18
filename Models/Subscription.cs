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
        public string Name { get; set; }
        public decimal Price { get; set; }

        public enum Period
        {
            Month,
            Year
        }
        public enum Model
        {
            Model_3_5,
            Model_3_5_Turbo,
            Model_4
        }
    }
}
