using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot.Forms
{
    public partial class LoaderForm : Form
    {
        public Func<Task> Worker { get; set; }

        public LoaderForm(Func<Task> worker)
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            if (worker == null)
            {
                throw new ArgumentNullException(nameof(worker));
            }

            Worker = worker;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Worker();
            this.Close();
        }
    }
}
