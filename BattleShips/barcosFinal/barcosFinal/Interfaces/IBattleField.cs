using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal.Interfaces
{
    public interface IBattleField
    {
        char[,] Board { get; set; }
        void DrawBoard();
    }
}
