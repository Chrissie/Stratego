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

        private Cell piece;

        public int PosX { get { return X; } set { value = X; } }
        public int PosY { get { return Y; } set { value = Y; } }

        public System.Windows.Forms.FlowLayoutPanel panel = new System.Windows.Forms.FlowLayoutPanel();

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
