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
    public enum GameState { PiecePlacement, Game, Finished};

    public partial class Form1 : Form
    {
        private GameState StateGame = GameState.PiecePlacement;
        private GameMode Mode;
        private Server.Client Client;
        private Control[] SelectedControls = new Control[2];

        private readonly Color SELECTIONCOLOR = Color.FromArgb(255, 192, 128);
        private readonly Color DESELECTCOLOR = Color.Transparent;
        private readonly Color MOVECOLOR = Color.FromArgb(192, 255, 192);
        private readonly Color HITCOLOR = Color.FromArgb(192, 255, 192);

        public Form1(Server.Client client)
        {
            InitializeComponent();
            Client = client;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mode = GameMode.Normal;
            ButtonPanel.MouseClick += SelectionControl;
            ButtonPanel.Tag = new Tile(101, 101);
            createBoard();
            //testcode
            //Client.PlayerBoard.Test();
        }
        
        
        public void SelectionControl(object sender, MouseEventArgs e)
        {
            //check if button is already selected
            Control C = sender as Control;
            
            if (C.Equals(SelectedControls[0]))
            {
                SelectedControls[0].BackColor = DESELECTCOLOR;
                SelectedControls[0] = null;
            }
            else if (C.Equals(SelectedControls[1]))
            {

                SelectedControls[1].BackColor = DESELECTCOLOR;
                SelectedControls[1] = null;
            }

            //selecting the button
            else if (SelectedControls[0] == null)
            {
                SelectedControls[0] = C;
                SelectedControls[0].BackColor = SELECTIONCOLOR;
            }
            else if (SelectedControls[0] != null && SelectedControls[1] == null)
            {
                SelectedControls[1] = C;
                SelectedControls[1].BackColor = SELECTIONCOLOR;
            }
            ////////
            if (SelectedControls[0] != null && SelectedControls[1] != null)
            {
                SelectMove();
            }
            //when there is 1 panel selected and state is Game
            if (SelectedControls[0] != null || SelectedControls[1] != null)
            {
                if (StateGame == GameState.Game)
                {
                    if (SelectedControls[0] != null)
                    {

                        MakeMoveTileColor(SelectedControls[0] as Button);
                    }
                    else
                    {
                        MakeMoveTileColor(SelectedControls[1] as Button);
                    }

                }
            }
            //if nothing is selected
            if (SelectedControls[0] == null && SelectedControls[1] == null)
            {
                ClearColorField();
            }
        }

        public void ClearColorField()
        {
            foreach(FlowLayoutPanel Panel in BoardPanel.Controls)
            {
                Panel.BackColor = DESELECTCOLOR;
            }
        }

        public void SelectMove()
        {
            ///als er iets in de panel staat dan moet die button gecheckt worden
            ///lege panels heeft geen zin
            ///button en dan panel kan verplaatsen
            ///2 volle panels kunnen slaan
            ///

            //when 2 buttons are selected
            if (SelectedControls[0] is Button && SelectedControls[1] is Button)
            { 
                Console.WriteLine("rip");
            }
            //when 2 panels are selected
            else if (SelectedControls[0] is FlowLayoutPanel && SelectedControls[1] is FlowLayoutPanel)
            {
                Console.WriteLine("rip2");
            }
            //when a button and a panel are selected
            else if (SelectedControls[0] is Button && SelectedControls[1] is FlowLayoutPanel)
            {
                MovePieces(SelectedControls[0] as Button, SelectedControls[1] as FlowLayoutPanel);
            }
            //when a panel and a button are selected
            else if (SelectedControls[0] is FlowLayoutPanel && SelectedControls[1] is Button)
            {
                MovePieces(SelectedControls[1] as Button, SelectedControls[0] as FlowLayoutPanel);
            }

        }
        //colors the tiles when a piece is selected according to the moves it can make
        public void MakeMoveTileColor(Control button)
        {
            //select tiles in line with the selected tile
            if (button is Button)
            {
                Soldier soldier = button.Tag as Soldier;
                Tile SelectedTile = button.Parent.Tag as Tile;
                if (soldier == null){return;}
                if (EnemyCheck(button as Button)) { return; }
                
                foreach (FlowLayoutPanel Panel in BoardPanel.Controls)
                {
                    Tile Other = Panel.Tag as Tile;
                    if (Other.PosX > SelectedTile.PosX && Other.PosY == SelectedTile.PosY)
                    {
                        if (Other.PosX < (SelectedTile.PosX + soldier.WalkNumber))
                        {
                            Panel.BackColor = MOVECOLOR;
                            Other.CellMoveLine = true;
                        }
                    }
                    if (Other.PosX < SelectedTile.PosX && Other.PosY == SelectedTile.PosY)
                    {
                        if (Other.PosX > (SelectedTile.PosX - soldier.WalkNumber))
                        {
                            Panel.BackColor = MOVECOLOR;
                            Other.CellMoveLine = true;
                        }
                    }
                    if (Other.PosY > SelectedTile.PosY && Other.PosX == SelectedTile.PosX)
                    {
                        if (Other.PosY < (SelectedTile.PosY + soldier.WalkNumber))
                        {
                            Panel.BackColor = MOVECOLOR;
                            Other.CellMoveLine = true;
                        }
                    }
                    if (Other.PosY < SelectedTile.PosY && Other.PosX == SelectedTile.PosX)
                    {
                        if (Other.PosY > (SelectedTile.PosY - soldier.WalkNumber))
                        {
                            Panel.BackColor = MOVECOLOR;
                            Other.CellMoveLine = true;
                        }
                    }
                }

                //deselect tiles around dead tiles
                foreach (FlowLayoutPanel Panel in BoardPanel.Controls)
                {
                    Tile Other = Panel.Tag as Tile;
                    if (Other.dead)
                    {
                        //////////////////////////////////X
                        if (SelectedTile.PosX > Other.PosX)
                        {
                            Panel.BackColor = DESELECTCOLOR;
                            foreach (FlowLayoutPanel RestPanel in BoardPanel.Controls)
                            {
                                Tile RestTile = RestPanel.Tag as Tile;
                                if (RestTile.PosX < Other.PosX)
                                {
                                    if (RestTile.PosY == Other.PosY)
                                    {
                                        RestPanel.BackColor = RestPanel.BackColor = DESELECTCOLOR;
                                        RestTile.CellMoveLine = false;
                                    }
                                }
                            }
                        }
                        //////////////////////////////////X
                        if (SelectedTile.PosX < Other.PosX)
                        {
                            Panel.BackColor = DESELECTCOLOR;
                            foreach (FlowLayoutPanel RestPanel in BoardPanel.Controls)
                            {
                                Tile RestTile = RestPanel.Tag as Tile;
                                if (RestTile.PosX > Other.PosX)
                                {
                                    if (RestTile.PosY == Other.PosY)
                                    {
                                        RestPanel.BackColor = RestPanel.BackColor = DESELECTCOLOR;
                                        RestTile.CellMoveLine = false;
                                    }
                                }
                            }
                        }
                        //////////////////////////////////Y
                        if (SelectedTile.PosY > Other.PosY)
                        {
                            Panel.BackColor = DESELECTCOLOR;
                            foreach (FlowLayoutPanel RestPanel in BoardPanel.Controls)
                            {
                                Tile RestTile = RestPanel.Tag as Tile;
                                if (RestTile.PosY < Other.PosY)
                                {
                                    if (RestTile.PosX == Other.PosX)
                                    {
                                        RestPanel.BackColor = RestPanel.BackColor = DESELECTCOLOR;
                                        RestTile.CellMoveLine = false;
                                    }
                                }
                            }
                        }
                        //////////////////////////////////Y
                        if (SelectedTile.PosY < Other.PosY)
                        {
                            Panel.BackColor = DESELECTCOLOR;
                            foreach (FlowLayoutPanel RestPanel in BoardPanel.Controls)
                            {
                                Tile RestTile = RestPanel.Tag as Tile;
                                if (RestTile.PosY > Other.PosY)
                                {
                                    if (RestTile.PosX == Other.PosX)
                                    {
                                        RestPanel.BackColor = DESELECTCOLOR;
                                        RestTile.CellMoveLine = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //moves a piece to the selected panel by the rules
        public void MovePieces(Button button, FlowLayoutPanel panel)
        {
            bool canMove = true;
            Tile T = panel.Tag as Tile;

            if (EnemyCheck(button))
            {
                canMove = false;
            }

            //check if it's playersturn and in game
            if (!Client.IsPlayersTurn && StateGame == GameState.Game)
            {
                canMove = false;
            }

            //check for placement in own half of the field and in piece placement
            if (StateGame == GameState.PiecePlacement)
            {
                
                string a = "" + T.PosX + T.PosY;
                int q = int.Parse(a);
                if (q <= 59)
                {
                    Console.WriteLine("Can't place piece here in this state");
                    canMove = false;
                }
            }
            //check if bomb or flag want to move and in game
            if (StateGame == GameState.Game)
            {
                if (button.Tag is Bomb || button.Tag is Flag)
                {
                    canMove = false;
                    Console.WriteLine("bomb or flag cannot be moved in this state");
                }
            }
            //check if panel is used
            if (panel.Controls.Count > 0 && panel.Controls.Count < 2)
            {
                Console.WriteLine("Panel must be empty");
                canMove = false;
            }

            //check if the panel is in line with the piece and in game
            if (!T.CellMoveLine && StateGame == GameState.Game)
            {
                canMove = false;
            }

            else if(canMove)
            {
                button.Parent = panel;
                if (StateGame == GameState.Game)
                {
                    Client.IsPlayersTurn = false;
                }
            }

            SelectionControl(button, null);
            SelectionControl(panel, null);
        }
        
        //sends current gameboard to the server
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
            }
        }

        //updates the gui according to the gameboard
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
            if (!Client.IsPlayersTurn) button3.Text = "Not your turn"; else button3.Text = "Send gameboard";
        }
        
        public void createBoard()
        {
            //creates buttons for this player and shows them in buttonpanel
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
                //create buttons for the player to use
                System.Windows.Forms.Button Button = new System.Windows.Forms.Button();
                Button.Size = new System.Drawing.Size(72, 80);
                Button.MouseClick += SelectionControl;
                Button.Text = "Piece_" + k;
                Button.FlatStyle = FlatStyle.Flat;
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
                Button.Parent = ButtonPanel;
                k++;
            }
            //creates panels for the gui and shows them in boardpanel
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //create all panels
                    Tile Tile = new Tile(i, j);
                    FlowLayoutPanel Panel = new FlowLayoutPanel();
                    string a = "" + i + j;
                    int q = int.Parse(a);
                    if (q == 42|| q == 43|| q == 46|| q == 47||
                        q == 52|| q == 53|| q == 56|| q == 57)
                    {
                        Panel.BorderStyle = BorderStyle.None;
                        Tile.dead = true;
                    }
                    else
                    {

                        Panel.BorderStyle = BorderStyle.FixedSingle;
                        Panel.MouseClick += SelectionControl;
                    }
                    Panel.Size = new System.Drawing.Size(79, 87);
                    Panel.Tag = Tile;
                    Panel.Name = "Tile_" + i + "," + j;
                    Panel.Parent = BoardPanel;
                }
            }
        }

        public bool EnemyCheck(Button B)
        {
            Character Cha = B.Tag as Character;
            if (Cha.username.Equals(Client.LoginName))
            {
                return false;
            }
            else{
                return true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (StateGame == GameState.PiecePlacement)
            {
                StateGame = GameState.Game;
                return;
            }
            if (StateGame == GameState.Game)
            {
                StateGame = GameState.PiecePlacement;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateGameboard();
            if (Client.IsPlayersTurn)
            {
                Client.SendGameBoard();
            }
        }
    }
}

