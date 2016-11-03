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
using System.Runtime.InteropServices;

namespace Stratego
{

    public partial class Form1 : Form
    {
        private GameBoard Board;
        private GameMode Mode;
        public string Clientname;
        private Control[] SelectedControls = new Control[2];
        bool console = true;

        private readonly Color SELECTIONCOLOR = Color.FromArgb(255, 192, 128);
        private readonly Color DESELECTCOLOR = Color.Transparent;

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
            if (console)
            {
                AllocConsole();
            }
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
            Server.Client client = new Server.Client();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            searchHostPanel.Hide();
            searchPlayerPanel.Hide();
            menuPanel.Show();
        }

        public void SelectionControl(object sender, MouseEventArgs e)
        {
            //check if button is already selected
            Control C = sender as Control;
            if (C.Equals(SelectedControls[0]))
            {
                SelectedControls[0].BackColor = DESELECTCOLOR;
                SelectedControls[0] = null;
                return;
            }
            else if (C.Equals(SelectedControls[1]))
            {

                SelectedControls[1].BackColor = DESELECTCOLOR;
                SelectedControls[1] = null;
                return;
            }

            //selecting the button
            if (SelectedControls[0] == null)
            {
                SelectedControls[0] = C;
                SelectedControls[0].BackColor = SELECTIONCOLOR;
            }
            else if (SelectedControls[0] != null && SelectedControls[1] == null)
            {
                SelectedControls[1] = C;
                SelectedControls[1].BackColor = SELECTIONCOLOR;
            }
            if (SelectedControls[0] != null && SelectedControls[1] != null)
            {
                SelectMove();
            }
        }

        public void SelectMove()
        {
            ///als er iets in de panel staat dan moet die button gecheckt worden
            ///lege panels heeft geen zin
            ///button en dan panel kan verplaatsen
            ///2 volle panels kunnen slaan
            ///

            //wanneer 2 buttons geselecteerd zijn
            if (SelectedControls[0] is Button && SelectedControls[1] is Button)
            { 
                Console.WriteLine("rip");
            }
            //wanneer 2 panels geselecteerd zijn
            else if (SelectedControls[0] is FlowLayoutPanel && SelectedControls[1] is FlowLayoutPanel)
            {
                Console.WriteLine("rip2");
            }
            //wanneer een button en een panel zijn geseleteerd
            else if (SelectedControls[0] is Button && SelectedControls[1] is FlowLayoutPanel)
            {
                MovePieces(SelectedControls[0] as Button, SelectedControls[1] as FlowLayoutPanel);
            }
            //wanneer een panel en een button zijn geselecteerd
            else if (SelectedControls[0] is FlowLayoutPanel && SelectedControls[1] is Button)
            {
                MovePieces(SelectedControls[1] as Button, SelectedControls[0] as FlowLayoutPanel);
            }
        }

        public void MovePieces(Button button, FlowLayoutPanel panel)
        {
            if (panel.Controls.Count > 0)
            {
                Console.WriteLine("Panel must be empty");
            }
            else
            {
                //check op  volle panel
                button.Parent = panel;
            }

            SelectionControl(button, null);
            SelectionControl(panel, null);
        }

        public void HitPieces()
        {

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
                Button.MouseClick += SelectionControl;
                Button.Text = "Piece_" + k;
                Button.FlatStyle = FlatStyle.Flat;
                Button.Parent = ButtonPanel;
                //more button settings comming soon....
                
                Button.Tag = C;
                Button.Name = "Piece_" + k;
                k++;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Tile Tile = new Tile(i, j);
                    FlowLayoutPanel Panel = new FlowLayoutPanel();
                    Panel.BorderStyle = BorderStyle.FixedSingle;
                    Panel.Parent = BoardPanel;
                    Panel.Size = new System.Drawing.Size(84, 92);
                    Panel.MouseClick += SelectionControl;
                    Panel.Tag = Tile;
                    Panel.Name = "Tile_" + i + "," + j;
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}

