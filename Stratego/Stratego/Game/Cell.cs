using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Stratego.Game
{
    public class Cell
    {
        public Image Texture;
        public Image CellImage { get { return Texture; } set { Texture = value; } }

        public Cell()
        {
        }
    }
}
