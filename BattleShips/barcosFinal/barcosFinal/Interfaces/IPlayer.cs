using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal.Interfaces
{
    public interface IPlayer
    {
        List<IShip> Ships { get; set; }
        IBattleField BattleField { get; set; }
        string Name { get; set; }
        char[,] GetCurrentBattleField();
        char[,] Shoot(Player enemyPlayer,int x, int y, char[,] board); 
    }
}
