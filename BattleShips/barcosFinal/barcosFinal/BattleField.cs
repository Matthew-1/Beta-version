using System;
using System.Collections.Generic;
using System.Text;
using barcosFinal.Enums;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    public class BattleField : IBattleField
    {
        public char[,] Board { get; set; }

        public BattleField()
        {
            DrawBoard();
        }

        public void DrawBoard()
        {
            Board = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Board[i,j] = 'o';
                }
            }
            
        }

        public void AddShip(IShip ship)
        {

        }
    }
}
