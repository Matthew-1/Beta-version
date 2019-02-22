using barcosFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace barcosFinal
{
    public class UI
    {
        public bool ClearBoard { get; set; }

        public void ShowBoard(char[,] board)
        {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    DrawDependOnIteration(i, j, board);

                }
            }

            if(ClearBoard)
            {
                Console.WriteLine("Next player's tour coming!");
                Thread.Sleep(2000);
                Console.Clear(); 
            }
            
        }

        private void DrawDependOnIteration(int i, int j, char[,] board)
        {
            if (i == 0 && j == 0)
            {
                for (int z = 0; z < 10; z++)
                {
                    if (z == 0)
                        Console.Write("          {0}", z + 1);
                    else
                        Console.Write("       {0}", z + 1);
                }

                Console.WriteLine("");
                Console.Write(" {0} ", i + 1);

            }
            else if (j == 0 && i == 9)
                Console.Write(" {0}", i + 1);
            else if (j == 0)
                Console.Write(" {0} ", i + 1);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("   |   ");
            switch (board[i, j])
            {
                case 'o':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'x':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '^':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.Write(board[i, j]);

            if (j == 9)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   |   ");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ResetColor();
        }

        public int AskForNumberOfShips()
        {
            int ships = 0;
            do
            {
                Console.WriteLine("How many ships do You want to posses? (At least 1):");
                string numberOfShips = Console.ReadLine();

                int.TryParse(numberOfShips, out ships);
            } while (ships < 1);

            Console.WriteLine();
            Console.WriteLine("The game is ready to begin!");

            return ships;
        }
    }
}
