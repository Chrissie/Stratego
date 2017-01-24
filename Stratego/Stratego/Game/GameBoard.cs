﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    [Serializable]
    public enum GameMode { No_Mode, Normal, Duel, Ultra };
    public class GameBoard 
    {
        public Cell[,] board = new Cell[10, 10];
        
        public Cell[] MyPieces;
        public string Clientname;

        public GameBoard()
        {

        }

        public GameBoard(string Clientname)
        {
            this.Clientname = Clientname;
        }

        public GameBoard(string Clientname, Cell[,] cells)
        {
            this.Clientname = Clientname;
            board = cells;
        }

        public void RotateBoard180()
        {
            board = RotateBoardRight(RotateBoardRight(board));
        }

        public void CreateFullGameBoard(GameBoard toAdd)
        {
            Cell[,] newcells = toAdd.board;
            for(int i = 0; i< 4; i++)
            {
                for(int j = 0; j<10; j++)
                {
                    board[i, j] = newcells[i, j];
                }
            }
        }

        public void CreateFullGameBoard(Cell[,] toAdd)
        {
            Cell[,] newcells = toAdd;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = newcells[i, j];
                }
            }
        }

        public Cell[,] RotateBoardRight(Cell[,] board)
        {
            int w = board.GetLength(0);
            int h = board.GetLength(1);
            Cell[,] ret = new Cell[h,w];
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    ret[i,j] = board[w - j - 1,i];
                }
            }
            return ret;
        }

        public void PrintBoard()
        {
            Debug.WriteLine("");
            Debug.WriteLine("");
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("");
                for (int j = 0; j < 10; j++)
                {
                    Debug.Write(board[i, j].ToString());
                }
            }
        }

        public void Test()
        {
            Random rand = new Random();
            //board = new Cell[10, 10];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (rand.NextDouble() > 0.5)
                    {
                        board[i, j] = new Soldier("Maarschalk", SoldierType.Verkenner);
                    }
                    else if (rand.NextDouble() > 0.2)
                    {
                        board[i, j] = new Soldier("Spion", SoldierType.Spion);
                    }
                    else
                    {
                        board[i, j] = new Soldier("Generaal", SoldierType.Generaal);
                    }
                }
            }
           // PrintBoard();
            //board = RotateBoard180();
           //PrintBoard();
        }

        public void CreatePlayerCells(GameMode mode)
        {
            int numOfPieces;
            int index = 0;
            switch (mode)
            {
                case GameMode.Normal:
                    numOfPieces = 40;

                    MyPieces = new Cell[numOfPieces];

                    MyPieces[index] = new Soldier(Clientname, SoldierType.Maarschalk);
                    index++;
                    MyPieces[index] = new Soldier(Clientname, SoldierType.Generaal);
                    index++;
                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Kolonel);
                        index++;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Majoor);
                        index++;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Kapitein);
                        index++;
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Lieutenant);
                        index++;
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Sergeant);
                        index++;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                       
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Mineur);
                        index++;
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        MyPieces[index] = new Bomb(Clientname);
                        index++;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Verkenner);
                        index++;
                    }

                    MyPieces[index] = new Soldier(Clientname, SoldierType.Spion);
                    index++;
                    MyPieces[index] = new Flag(Clientname);
                    break;
                case GameMode.Duel:
                    numOfPieces = 10;
                    MyPieces = new Cell[numOfPieces];
                    MyPieces[index] = new Soldier(Clientname, SoldierType.Maarschalk);
                    MyPieces[index] = new Soldier(Clientname, SoldierType.Generaal);
                    MyPieces[index] = new Soldier(Clientname, SoldierType.Spion);

                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Mineur);
                        index++;
                        MyPieces[index] = new Soldier(Clientname, SoldierType.Verkenner);
                        index++;
                        MyPieces[index] = new Bomb(Clientname);
                        index++;
                    }

                    MyPieces[index] = new Flag(Clientname);
                    break;
                case GameMode.Ultra:
                    numOfPieces = 21;
                    MyPieces = new Cell[numOfPieces];

                    break;
                default:
                    break;
            }

        }

    }

}

