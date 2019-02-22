using barcosFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace barcosFinal
{
    class GameEngine
    {
        private Player _player1;
        private Player _player2;
        private UI _ui;

        public void StartGame(string[] shipsFromFile = null)
        {

            _ui = new UI();
            _player1 = new Player();
            _player2 = new Player();
            PlayersInitiation(_player1, _player2);
            int numberOfShips = _ui.AskForNumberOfShips();

            Thread.Sleep(2000);
            Console.Clear();


            IBattleField bf = new BattleField();
            IBattleField bfToDisplay = new BattleField();
            bf.DrawBoard();
            bfToDisplay.DrawBoard();
            _player1.BattleField = bf;
            _player1.BattleFieldToDisplay = bfToDisplay;
            _ui.ShowBoard(bf.Board);

            _player1.AddShip(numberOfShips);


            Console.Clear();

            IBattleField bf2 = new BattleField();
            IBattleField bfToDisplay2 = new BattleField();
            bf2.DrawBoard();
            bfToDisplay2.DrawBoard();
            _player2.BattleField = bf2;
            _player2.BattleFieldToDisplay = bfToDisplay2;
            _ui.ShowBoard(bf2.Board);

            _player2.AddShip(numberOfShips);


            bool someoneWon = false;

            do
            {
                someoneWon = PlayersTour();

            } while (someoneWon == false);


            if (_player1.AllMasts > _player2.AllMasts)
            {
                Console.WriteLine();
                Console.WriteLine("PLAYER {0} WON", _player1.Name);
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("PLAYER {0} WON", _player2.Name);
            }

            Console.ReadLine();
        }

        private void PlayersInitiation(Player pl1, Player pl2)
        {
            AskPlayerForName(new List<Player>() { pl1, pl2 });
        }

        private void AskPlayerForName(List<Player> players)
        {

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"What is Your name Player {i + 1}?");
                string name = Console.ReadLine();
                players[i].Name = name;
                Console.WriteLine("Welcome in BattleShip Game {0}!", name);

                Console.WriteLine();
            }

        }

        private bool PlayersTour()
        {
            bool someoneWon = false;

            do
            {
                Console.Clear();
                _ui.ShowBoard(_player1.BattleFieldToDisplay.Board);
                Console.WriteLine("{0} write X,Y of enemy", _player1.Name);

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                Console.Clear();
                _ui.ShowBoard(_player1.Shoot(_player2, x, y, _player2.GetCurrentBattleField()));
                Console.WriteLine("Next tour is coming!");
                Thread.Sleep(2000);
                someoneWon = CheckWinningConditions_SomeoneWon();
                if (someoneWon)
                    return true;
            } while (_player1.OnRage == true);


            do
            {
                Console.Clear();
                _ui.ShowBoard(_player2.BattleFieldToDisplay.Board);
                Console.WriteLine("{0} write X,Y of enemy", _player2.Name);

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                Console.Clear();
                _ui.ShowBoard(_player2.Shoot(_player1, x, y, _player1.GetCurrentBattleField()));
                Console.WriteLine("Next tour is coming!");
                Thread.Sleep(2000);
                someoneWon = CheckWinningConditions_SomeoneWon();
                if (someoneWon)
                    return true;
            } while (_player2.OnRage == true);

            return false;
        }

        private bool CheckWinningConditions_SomeoneWon()
        {
            if (_player1.AllMasts == 0 || _player2.AllMasts == 0)
                return true;
            else
                return false;
        }
    }
}
