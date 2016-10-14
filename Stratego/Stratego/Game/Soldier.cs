using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    enum soldierType { Maarschalk, Generaal, Kolonel, Majoor, Kapitein, Lieutenant, Sergeant, Mineur, Verkenner, Spion}
    class Soldier : Character
    {
        int number;
        soldierType soldier;

        public Soldier(string username, soldierType soldier) : base(username)
        {
            this.soldier = soldier;
        }

        public void setNumber()
        {
            switch (soldier)
            {
                case soldierType.Maarschalk:
                    number = 10;
                    break;
                case soldierType.Generaal:
                    number = 9;
                    break;
                case soldierType.Kolonel:
                    number = 8;
                    break;
                case soldierType.Majoor:
                    number = 7;
                    break;
                case soldierType.Kapitein:
                    number = 6;
                    break;
                case soldierType.Lieutenant:
                    number = 5;
                    break;
                case soldierType.Sergeant:
                    number = 4;
                    break;
                case soldierType.Mineur:
                    number = 3;
                    break;
                case soldierType.Verkenner:
                    number = 2;
                    break;
                case soldierType.Spion:
                    number = 1;
                    break;
            }
        }
    }
}
