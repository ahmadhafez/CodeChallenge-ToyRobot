using System;

namespace ToyRobotCore.Utils
{
    public class Position : IPosition
    {
        public int XEastWestAxis { set; get; }
        public int YNorthSouthAxis { set; get; }
        public Direction Direction { get; set; }

        public Position(int xEastWestAxis, int yNorthSouthAxis, Direction direction)
        {
            XEastWestAxis = xEastWestAxis;
            YNorthSouthAxis = yNorthSouthAxis;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"{XEastWestAxis},{YNorthSouthAxis},{Direction}";
        }

        public bool Equals(IPosition other)
        {
            return other != null
                && XEastWestAxis == other.XEastWestAxis
                && YNorthSouthAxis == other.YNorthSouthAxis
                && Direction == other.Direction;
        }
    }
}
