using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    [Serializable]
    class Flag : Character
    {
        int number = 0;
        public Flag(string username) : base(username)
        {
        }
    }
}
