using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stratego.Game;

namespace Stratego
{
    //enum GameMode { Normal, Duel, Ultra };
    class Logic
    {
        int numOfPieces;
        Cell[] MyPieces;
        //Dictionary<Button, >
        System.Windows.Forms.Button[] MyButtons;
        string clientname;

        public void MakeButtons()
        {
            for(int i = 0; i < MyPieces.Length; i++)
            {
                System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                button.Size = new System.Drawing.Size(77, 85);
                //more button settings comming soon....
                MyButtons[i] = button;
            }
            
        }

        public Logic(GameMode mode)
        {
            int index = 0;
            switch (mode)
            {
                case GameMode.Normal:
                    numOfPieces = 40;
                    
                    MyPieces = new Cell[numOfPieces];

                    MyPieces[index] = new Soldier(clientname, SoldierType.Maarschalk);
                    index++;
                    MyPieces[index] = new Soldier(clientname, SoldierType.Generaal);
                    index++;
                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Kolonel);
                        index++;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Majoor);
                        index++;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Kapitein);
                        index++;
                        MyPieces[index] = new Soldier(clientname, SoldierType.Lieutenant);
                        index++;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Sergeant);
                        index++;
                        MyPieces[index] = new Soldier(clientname, SoldierType.Mineur);
                        index++;
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Verkenner);
                        index++;
                        MyPieces[index] = new Bomb(clientname);
                        index++;
                    }

                    MyPieces[index] = new Soldier(clientname, SoldierType.Spion);
                    index++;
                    MyPieces[index] = new Flag(clientname);
                    break;
                case GameMode.Duel:
                    numOfPieces = 10;
                    MyPieces = new Cell[numOfPieces];
                    MyPieces[index] = new Soldier(clientname, SoldierType.Maarschalk);
                    MyPieces[index] = new Soldier(clientname, SoldierType.Generaal);
                    MyPieces[index] = new Soldier(clientname, SoldierType.Spion);

                    for (int i = 0; i < 2; i++)
                    {
                        MyPieces[index] = new Soldier(clientname, SoldierType.Mineur);
                        index++;
                        MyPieces[index] = new Soldier(clientname, SoldierType.Verkenner);
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
