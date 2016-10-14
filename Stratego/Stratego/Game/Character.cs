using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    class Character : Cell
    {
        string username;
        public Character(string name, bool moveable, string username) : base(name, moveable)
        {
            this.username = username;
        }
    }
}
