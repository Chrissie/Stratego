using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    class GameBoard
    {
        public Cell[,] board;

        public GameBoard()
        {
            Random rand = new Random();
            board = new Cell[10,10];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j <10; j++)
                {
                    if (rand.NextDouble() > 0.5)
                    {
                        board[i, j] = new Soldier("Maarschalk", SoldierType.Maarschalk);
                    }
                    else if(rand.NextDouble() > 0.2)
                    {
                        board[i, j] = new Soldier("Spion", SoldierType.Spion);
                    }
                    else
                    {
                        board[i, j] = new Soldier("Generaal", SoldierType.Generaal);
                    }
                }
            }
            PrintBoard();
            board = RotateBoard180();
            PrintBoard();
        }
        
        public void UpdateBoard(GameBoard newBoard)
        {
            board = newBoard.board;
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

        public Cell[,] RotateBoard180()
        {
            return RotateBoardRight(RotateBoardRight(board));
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
    }
}
