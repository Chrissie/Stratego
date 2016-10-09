using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stratego
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            searchPlayerPanel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            searchHostPanel.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();
            menuPanel.Show();

        }
    }
}
