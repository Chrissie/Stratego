using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratego
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void StartUpForm_Load(object sender, EventArgs e)
        {
            Pictures.CreatePictures();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            ClientStartupForm form = new ClientStartupForm();
            form.FormClosed += (s, args) => Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            ServerForm form = new ServerForm();
            form.FormClosed += (s, args) => Close();
            form.Show();
        }
    }
}
