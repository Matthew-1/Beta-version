using barcosFinal.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal
{
    public interface IShip
    {
        int HP { get; set; }
        int Coordinate_X { get; set; }
        int Coordinate_Y { get; set; }
        Orientation Orientation { get; set; }
    }
}
