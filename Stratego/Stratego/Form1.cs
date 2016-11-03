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
        private GameMode Mode;
        private Server.Client Client;
        private Control[] SelectedControls = new Control[2];

        private readonly Color SELECTIONCOLOR = Color.FromArgb(255, 192, 128);
        private readonly Color DESELECTCOLOR = Color.Transparent;

        public Form1(Server.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //testcode
            Mode = GameMode.Normal;
            createBoard();
            Client.PlayerBoard.Test();
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

        public void UpdateGameboard()
        {
            Client.PlayerBoard.board = new Cell[10, 10];
            foreach (FlowLayoutPanel f in BoardPanel.Controls)
            {
                if (f.Controls.Count > 0)
                {
                    Tile tile = f.Tag as Tile;
                    Cell cell = f.Controls[0].Tag as Cell;

                    Client.PlayerBoard.board[tile.PosX, tile.PosY] = cell;
                }
                if (Client.IsPlayersTurn)
                {
                    Client.SendGameBoard();
                }
            }
        }

        public void UpdateGUI()
        {
            foreach (FlowLayoutPanel f in BoardPanel.Controls)
            {
                f.Controls.Clear();
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string a = "" + i + j;
                    int q = int.Parse(a);
                    string username = "NO_USER";

                    Cell cell = Client.PlayerBoard.board[i, j];


                    //find cell in gameboard
                    if (cell != null)
                    {
                        //create button for piece in the right panel
                        System.Windows.Forms.Button Button = new System.Windows.Forms.Button();
                        Button.Size = new System.Drawing.Size(72, 80);
                        Button.MouseClick += SelectionControl;
                        Button.FlatStyle = FlatStyle.Flat;

                        //check username
                        if (cell is Soldier)
                        {
                            Soldier c = cell as Soldier;
                            username = c.username;
                            Button.Text = c.soldier.ToString();
                        }
                        else if (cell is Bomb)
                        {
                            Bomb c = cell as Bomb;
                            username = c.username;
                            Button.Text = "Bom";
                        }
                        else if (cell is Flag)
                        {
                            Flag c = cell as Flag;
                            username = c.username;
                            Button.Text = "Vlag";
                        }
                        if (!username.Equals(Client.LoginName))
                        {
                            Button.Text = "EnemyPiece_" + q;
                            Button.Name = "EnemyPiece_" + q;
                        }

                        Button.Tag = cell;
                        Button.Parent = BoardPanel.Controls[q];
                    }
                }
            }

        }


        public void createBoard()
        {
            //buttons create temp
            Client.PlayerBoard = new GameBoard(Client.LoginName);
            if (Mode != GameMode.No_Mode)
            {
                Client.PlayerBoard.CreatePlayerCells(Mode);
            }
            else
            {
                return;
            }

            int k = 0;
            foreach (Cell C in Client.PlayerBoard.MyPieces)
            {
                System.Windows.Forms.Button Button = new System.Windows.Forms.Button();
                Button.Size = new System.Drawing.Size(72, 80);
                Button.MouseClick += SelectionControl;
                Button.Text = "Piece_" + k;
                Button.FlatStyle = FlatStyle.Flat;
                Button.Parent = ButtonPanel;
                //more button settings comming soon....
                
                Button.Tag = C;
                if (C is Soldier)
                {
                    Soldier c = C as Soldier;
                    Button.Text = c.soldier.ToString();
                }
                else if (C is Bomb)
                {
                    Bomb c = C as Bomb;
                    Button.Text = "Bom";
                }
                else if (C is Flag)
                {
                    Flag c = C as Flag;
                    Button.Text = "Vlag";
                }
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
                    Panel.Size = new System.Drawing.Size(79, 87);
                    Panel.MouseClick += SelectionControl;
                    Panel.Tag = Tile;
                    Panel.Name = "Tile_" + i + "," + j;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGameboard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateGUI();
        }
    }
}

