using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    class Character : Cell
    {
        private bool moveable;
        string username;

        public Character(string name, bool moveable) : base(name, moveable)
        {
            this.name = name;
            this.moveable = moveable;
        }

        public Character(string name, bool moveable, string username) : base(name, moveable)
        {
            this.username = username;
        }
    }
}
