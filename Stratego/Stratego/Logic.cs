using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego.Game;

namespace Stratego
{
    enum GameMode { Normal, Duel, Ultra };
    class Logic
    {
        int numOfPieces;
        Cell[] MyPieces;
        string clientname;

        public Logic(GameMode mode)
        {
            int index = 0;
            switch (mode)
            {
                case GameMode.Normal:
                    numOfPieces = 40;
                    
                    MyPieces = new Cell[numOfPieces];

                    MyPieces[index] = new Soldier(clientname, soldierType.Maarschalk);
                    index++;
                    MyPieces[index] = new Soldier(clientname, soldierType.Generaal);
                    index++;
                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Kolonel);
                        index++;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Majoor);
                        index++;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Kapitein);
                        index++;
                        MyPieces[index] = new Soldier(clientname, soldierType.Lieutenant);
                        index++;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Sergeant);
                        index++;
                        MyPieces[index] = new Soldier(clientname, soldierType.Mineur);
                        index++;
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Verkenner);
                        index++;
                        MyPieces[index] = new Bomb(clientname);
                        index++;
                    }

                    MyPieces[index] = new Soldier(clientname, soldierType.Spion);
                    index++;
                    MyPieces[index] = new Flag(clientname);
                    break;
                case GameMode.Duel:
                    numOfPieces = 10;
                    MyPieces = new Cell[numOfPieces];
                    MyPieces[index] = new Soldier(clientname, soldierType.Maarschalk);
                    MyPieces[index] = new Soldier(clientname, soldierType.Generaal);
                    MyPieces[index] = new Soldier(clientname, soldierType.Spion);

                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, soldierType.Mineur);
                        index++;
                        MyPieces[index] = new Soldier(clientname, soldierType.Verkenner);
                        index++;
                        MyPieces[index] = new Bomb(clientname);
                        index++;
                    }

                    MyPieces[index] = new Flag(clientname);
                    break;
                case GameMode.Ultra:
                    numOfPieces = 21;
                    MyPieces = new Cell[numOfPieces];
                    
                    break;
                default:
                    break;
            }
            
        }
    }
}
