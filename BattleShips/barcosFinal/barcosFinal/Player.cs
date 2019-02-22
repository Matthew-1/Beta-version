using System;
using System.Collections.Generic;
using barcosFinal.Enums;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    public class Player : IPlayer
    {
        public List<IShip> Ships { get; set; }
        public int AllMasts { get; set; }
        public IBattleField BattleField { get; set; }
        public IBattleField BattleFieldToDisplay { get; set; }
        public bool OnRage { get; set; }
        public string Name { get; set; }
        public UI ShowBoard = new UI();
        public char[,] GetCurrentBattleField()
        {

            return BattleField.Board;
        }

        public char[,] Shoot(Player enemyPlayer, int x, int y, char[,] enemyBoard)
        {
            OnRage = false;
            try
            {
                if (enemyBoard[y - 1, x - 1] == '^')
                {
                    enemyPlayer.BattleField.Board[y - 1, x - 1] = 'x';
                    BattleFieldToDisplay.Board[y - 1, x - 1] = 'x';
                    OnRage = true;
                    enemyPlayer.AllMasts--;

                }
                else if (BattleFieldToDisplay.Board[y - 1, x - 1] == 'x' || BattleFieldToDisplay.Board[y - 1, x - 1] == ' ')
                {
                    OnRage = true;
                }

                else
                {
                    BattleFieldToDisplay.Board[y - 1, x - 1] = ' ';
                    OnRage = false;
                }

            }

            catch (Exception)
            {

                Console.WriteLine("You didn't shoot on board, try again");
                OnRage = true;
            }


            return BattleFieldToDisplay.Board;
        }

        

        public void AddShip(int numberOfShips)
        {
            UI ui = new UI();
            Ships = new List<IShip>();
            for (int i = 0; i < numberOfShips; i++)
            {
                int masts = 0;
                switch (i)
                {
                    case 1:
                    case 0:
                        masts = 2;
                        AllMasts += masts;
                        break;
                    case 3:
                    case 2:
                        masts = 3;
                        AllMasts += masts;
                        break;
                    case 4:
                    case 5:
                        masts = 4;
                        AllMasts += masts;
                        break;
                    case 6:
                        masts = 5;
                        AllMasts += masts;
                        break;
                    default:
                        masts = 1;
                        AllMasts += masts;
                        break;
                }
                Console.WriteLine("Locate ship with {0} masts on Your board on coordinate X:", masts);

                int x = 0;
                int y = 0;

                while (x == 0)
                {
                    try
                    {
                        int tmpX = int.Parse(Console.ReadLine());
                        if (tmpX > 0 && tmpX < 11)
                        {
                            x = tmpX;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    catch
                    {
                        Console.WriteLine("Readed value is not a number between 1 - 10.");
                        Console.WriteLine("Try again...");
                    }
                }

                Console.WriteLine("Locate ship with {0} masts on Your board on coordinate Y:", masts);

                while (y == 0)
                {
                    try
                    {
                        int tmpY = int.Parse(Console.ReadLine());
                        if (tmpY > 0 && tmpY < 11)
                        {
                            y = tmpY;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    catch
                    {
                        Console.WriteLine("Readed value is not a number between 1 - 10.");
                        Console.WriteLine("Try again...");
                    }
                }

                Console.WriteLine("Locate ship with {0} masts on Your board vertically(0) or horizontally(1)", masts);
                int orientation = 2;

                while (orientation == 2)
                {
                    try
                    {
                        int tmpOrientation = int.Parse(Console.ReadLine());
                        if (tmpOrientation is 0 || tmpOrientation is 1)
                        {
                            orientation = tmpOrientation;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not 0 or 1");
                            Console.WriteLine("Try again...");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Readed value is not 0 or 1");
                        Console.WriteLine("Try again...");
                    }
                }

                Orientation shipOrientation = (orientation == 0) ? Orientation.vertical : Orientation.horizontal;

                IShip ship = new Ship(masts, x, y, shipOrientation);
                Ships.Add(ship);


                try
                {
                    for (int j = 0; j < masts; j++)
                    {
                        if (shipOrientation == Orientation.vertical)
                            BattleField.Board[y + j - 1, x - 1] = '^';
                        else
                            BattleField.Board[y - 1, x - 1 + j] = '^';

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Ship is too big for this board");
                    Console.WriteLine("Try again...");

                    i--;
                    continue;
                }

                finally
                {
                    Console.Clear();
                    ui.ShowBoard(GetCurrentBattleField());
                }

            }
        }
    }
}