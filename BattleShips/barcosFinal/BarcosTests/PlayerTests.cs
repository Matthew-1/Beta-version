using System;
using System.Collections.Generic;
using System.IO;
using barcosFinal;
using barcosFinal.Enums;
using barcosFinal.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerTests
    {

        [Test]
        public void PlayerShotAndMiss()
        {

            var board1 = new char[9, 9];
            var board2 = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board1[i, j] = 'o'; 
                    board2[i, j] = 'o';

                }
            }
            
            IPlayer player1 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };

            
            IPlayer player2 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };
            Assert.IsTrue('o' == player2.GetCurrentBattleField()[1,2]);
        }
        [Test]
        public void PlayerShotAndHit()
        {

            var board1 = new char[9, 9];
            var board2 = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board1[i, j] = '^';
                    board2[i, j] = '^';

                }
            }

            Player player1 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2,1,2,Orientation.vertical)
                },
                BattleFieldToDisplay = new BattleField()
                {
                    Board = board1
                }
            };

            
            Player player2 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2,1,2,Orientation.vertical)
                },
                BattleFieldToDisplay = new BattleField()
                {
                    Board = board1
                }
            };

            var result = player1.Shoot(player2,1, 2, player2.GetCurrentBattleField());
            //var temp = 1 + 2;
            Assert.IsTrue('x' == player2.GetCurrentBattleField()[0,1]);
        }

        [Test]
        public void PlayerShoots_WrongData_ReturnOnRageTrue()
        {

            var board1 = new char[9, 9];
            var board2 = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board1[i, j] = '^';
                    board2[i, j] = '^';

                }
            }

            Player player1 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2,1,2,Orientation.vertical)
                },
                BattleFieldToDisplay = new BattleField()
                {
                    Board = board1
                }
            };


            Player player2 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2,1,2,Orientation.vertical)
                },
                BattleFieldToDisplay = new BattleField()
                {
                    Board = board1
                }
            };
            Console.SetOut(TextWriter.Null);

            player1.Shoot(player2, 15, 17, player2.GetCurrentBattleField());
            Assert.AreEqual(player1.OnRage, true);
        }
    }
}