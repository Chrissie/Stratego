using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Stratego.Game
{
    [Serializable]
    public class Cell
    {
        public Image Texture = null;
        public Image CellImage { get { return Texture; } set { Texture = value; } }
        public Cell()
        {
        }
    }
}
