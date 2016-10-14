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
        Point position;
        public string name;
        public bool moveable { get; } = true;
        public Image texture;

        public Cell(string name, bool moveable)
        {
            this.name = name;
            this.moveable = moveable;
        }
    }
}
