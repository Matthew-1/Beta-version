using barcosFinal.Enums;

namespace barcosFinal
{
    public class Ship : IShip
    {
        public int HP { get; set; }
        public int Coordinate_X { get; set; }
        public int Coordinate_Y { get; set; }
        public Orientation Orientation { get; set; }


        public Ship(int hp, int x, int y, Orientation orientation)
        {
            HP = hp;
            Coordinate_X = x;
            Coordinate_Y = y;
            Orientation = orientation;
        }

        public Ship(ShipShapes shipShape, int x, int y, Orientation orientation)
        {
            HP = (int) shipShape;
            Coordinate_X = x;
            Coordinate_Y = y;
            Orientation = orientation;
        }
    }
}