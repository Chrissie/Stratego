using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratego
{
    public partial class ServerForm : Form
    {
        Server.Server server;
        string lastinfo = null;

        public ServerForm()
        {
            InitializeComponent();
            Show();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 300;
            t.Start();
            t.Tick += new EventHandler(TimerEventProcessor);

        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                lastinfo = server.lastinfo;
                textBox1.AppendText(lastinfo);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("nullpointer" + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new Server.Server();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = lastinfo;
        }
    }
}
