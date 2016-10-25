using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Stratego.Game
{
    class Cell
    {
        public Image Texture;
        private System.Windows.Forms.Button Button = new System.Windows.Forms.Button();

        public System.Windows.Forms.Button CellButton { get { return Button; } set { Button = value; } }
        public Image CellImage { get { return Texture; } set { Texture = value; } }

        public Cell()
        {
        }
    }
}
