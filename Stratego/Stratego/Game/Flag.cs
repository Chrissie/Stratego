using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    class Flag : Character
    {

        public Flag(string name, bool moveable) : base(name, moveable)
        {
            moveable = false;
        }
    }
}
