using System;
using barcosFinal.Interfaces;
using barcosFinal.Enums;
using System.Collections.Generic;

namespace barcosFinal
{
    public class GameInterface : IGameInterface
    {
        public GameInterface()
        {
        }


        public IPlayer CurrentPlayer { get; set; }
        public List<IPlayer> Players { get; set; }

        public void MessageToPlayer(IPlayer player, string message)
        {
            Console.WriteLine("message");
        }

        public void ReadDataFromPlayer(IPlayer player)
        {

        }

    }
}
