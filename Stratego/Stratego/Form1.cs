using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stratego.Game;
using System.Threading;

namespace Stratego
{
    
    public partial class Form1 : Form
    {
        Logic Game;

        public Form1()
        {
            InitializeComponent();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            searchPlayerPanel.Show();
            Server.Server server = new Server.Server();
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
            Server.Client client = new Server.Client();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();
            menuPanel.Show();
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("works");
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.DoDragDrop(button2.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.DoDragDrop(button3.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void button3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button3_DragDrop(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Data.GetData(DataFormats.Text).ToString());
        }
    }
}
