using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego.Game;

namespace Stratego
{
    enum GameMode { Normal, Duel, Ultra };
    class Logic
    {
        int numOfPieces;
        Cell[] Pieces;

        public Logic()
        {

        }

        private void loadGamePanel(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Normal:
                    numOfPieces = 40;
                    break;
                case GameMode.Duel:
                    numOfPieces = 10;
                    break;
                case GameMode.Ultra:
                    numOfPieces = 84;
                    break;
                default:
                    break;
            }
            Pieces = new Cell[numOfPieces];

            for (int i = 0; i < numOfPieces; i++)
            {

            }

        }
    }
}
