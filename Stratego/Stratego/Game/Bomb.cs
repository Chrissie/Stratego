using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    [Serializable]
    class Bomb : Character
    {
        int number = 11;
        public Bomb(string username) : base(username)
        {
            
        }
    }
}
