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
        string lastinfo = "";

        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new Server.Server();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
