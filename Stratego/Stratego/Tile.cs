using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego.Game;

namespace Stratego
{
    class Tile
    {
        private int X;
        private int Y;
        public bool dead = false;
        public bool CellMoveLine = false;

        private Cell piece;

        public int PosX { get { return X; } set { value = X; } }
        public int PosY { get { return Y; } set { value = Y; } }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SwitchCell(Cell c)
        {
            piece = c;
            
        }
    }
}
