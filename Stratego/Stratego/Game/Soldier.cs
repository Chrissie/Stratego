﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    enum SoldierType { Maarschalk, Generaal, Kolonel, Majoor, Kapitein, Lieutenant, Sergeant, Mineur, Verkenner, Spion}
    class Soldier : Character
    {
        int number;
        SoldierType soldier;

        public Soldier(string name, bool moveable, SoldierType soldier) : base(name, moveable)
        {
            this.soldier = soldier;
        }

        public override string ToString()
        {
            return name + ", ";
        }

        public void setNumber()
        {
            switch (soldier)
            {
                case SoldierType.Maarschalk:
                    number = 10;
                    break;
                case SoldierType.Generaal:
                    number = 9;
                    break;
                case SoldierType.Kolonel:
                    number = 8;
                    break;
                case SoldierType.Majoor:
                    number = 7;
                    break;
                case SoldierType.Kapitein:
                    number = 6;
                    break;
                case SoldierType.Lieutenant:
                    number = 5;
                    break;
                case SoldierType.Sergeant:
                    number = 4;
                    break;
                case SoldierType.Mineur:
                    number = 3;
                    break;
                case SoldierType.Verkenner:
                    number = 2;
                    break;
                case SoldierType.Spion:
                    number = 1;
                    break;
            }
        }
    }
}
