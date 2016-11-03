﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    [Serializable]
    class Character : Cell
    {
        string username;

        public Character(string username) : base()
        {
            this.username = username;
        }
    }
}
