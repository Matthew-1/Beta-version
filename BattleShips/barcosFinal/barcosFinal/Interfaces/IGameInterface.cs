using System;
using System.Collections.Generic;

namespace barcosFinal.Interfaces
{
    public interface IGameInterface
    {
        IPlayer CurrentPlayer { get; set; }
        List<IPlayer> Players { get; set; }
        void MessageToPlayer(IPlayer player, string message);
        void ReadDataFromPlayer(IPlayer player);
    }
}
