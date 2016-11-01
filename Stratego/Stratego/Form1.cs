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
        private GameBoard Board;
        private GameMode Mode;
        public string Clientname;


        public Form1()
        {
            InitializeComponent();
        }

        //public void EqualizeBoard()
        //{

        //}

        private void hostButton_Click(object sender, EventArgs e)
        {
            //menuPanel.Hide();
            //searchPlayerPanel.Show();
            ServerForm serverform = new ServerForm();
            serverform.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();

            //testcode
            Mode = GameMode.Normal;
            Clientname = "test";
            createBoard();

        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            searchHostPanel.Show();
            Server.Client client = new Server.Client("kaka");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();
            menuPanel.Show();
        }

        public void Selection(object sender, MouseEventArgs e)
        {
            Console.WriteLine("works");
        }

        public void createBoard()
        {
            //buttons create temp
            Board = new GameBoard(Clientname);
            if (Mode != GameMode.No_Mode)
            {
                Board.CreatePlayerCells(Mode);
            }
            else
            {
                return;
            }

            int k = 0;
            foreach (Cell C in Board.MyPieces)
            {
                System.Windows.Forms.Button Button = new System.Windows.Forms.Button();
                Button.Size = new System.Drawing.Size(77, 85);
                Button.MouseClick += Selection;
                Button.Text = "Piece " + k;
                k++;
                Button.Parent = ButtonPanel;
                //more button settings comming soon....

                C.CellButton = Button;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Tile Tile = new Tile(i, j);
                    Tile.panel.BorderStyle = BorderStyle.FixedSingle;
                    Tile.panel.Parent = BoardPanel;
                    Tile.panel.Size = new System.Drawing.Size(84, 90);
                    Tile.panel.MouseClick += Selection;
                }
            }
        }

    }
}
