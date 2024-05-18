using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatBot.Helpers;
using ChatBot.Services;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var test = new DatabaseHelper().GetByAdapter("Select * from Users", "Users");
            Console.WriteLine(test.ToString());
            Console.WriteLine("hehe");
        }
    }
}
