using System;
using System.IO;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine startGame = new GameEngine();
            startGame.StartGame();
        }
    }
}
