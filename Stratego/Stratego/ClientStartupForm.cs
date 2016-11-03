using Stratego.Game;
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
    public partial class ClientStartupForm : Form
    {
        public ClientStartupForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gebruikersnaam_Textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ipAdress_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            //Player p = new Player(gebruikersnaam_Textbox.Text);
            Server.Client client = new Server.Client(ipAdress_textbox.Text ,gebruikersnaam_Textbox.Text);
            Hide();
            Form1 form = new Form1(client);
            form.Show();
        }

        private void ipAdress_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            ipAdress_textbox.Text = "";
        }
    }
}
