using System;
using ToyRobotCore.Utils;

namespace ToyRobotCore
{
    public class Robot : IEquatable<Robot>
    {
        public const int c_defaultSteps = 1;

        public readonly Guid Guid;
        public int XAxisLocation { get; private set; }
        public int YAxisLocation { get; private set; }
        public Direction Direction { get; private set; }
        public Table Table { get; private set; }
        public int MovementSteps { get; private set; }

        #region Constructors
        /// <summary>
        /// Default robot constrctor with robot moves 1 step
        /// </summary>
        public Robot(Table table) : this(c_defaultSteps, table) { }

        /// <summary>
        /// Robot constructor 
        /// </summary>
        /// <param name="movementSteps"></param>
        /// <param name="table"></param>
        public Robot(int movementSteps, Table table)
        {
            this.Guid = Guid.NewGuid();
            MovementSteps = movementSteps;
            this.Table = table;
        }
        #endregion

        /// <summary>
        /// Execute robot's move toward where is the robot heading with robot
        /// number of steps if this move is valid on the table
        /// </summary>
        /// <returns></returns>
        public bool Move()
        {
            if (this.Table == null) return false;

            switch (this.Direction)
            {
                case Direction.EAST:
                    if (this.Table.ValidatePosition(this.XAxisLocation + MovementSteps, this.YAxisLocation))
                    {
                        this.XAxisLocation += MovementSteps;
                        return true;
                    }
                    return false;
                case Direction.SOUTH:
                    if (this.Table.ValidatePosition(this.XAxisLocation, this.YAxisLocation - MovementSteps))
                    {
                        this.YAxisLocation -= MovementSteps;
                        return true;
                    }
                    return false;
                case Direction.WEST:
                    if (this.Table.ValidatePosition(this.XAxisLocation - MovementSteps, this.YAxisLocation))
                    {
                        this.XAxisLocation -= MovementSteps;
                        return true;
                    }
                    return false;
                case Direction.NORTH:
                    if (this.Table.ValidatePosition(this.XAxisLocation, this.YAxisLocation + MovementSteps))
                    {
                        this.YAxisLocation += MovementSteps;
                        return true;
                    }
                    return false;
            }

            return false;
        }


        public bool PlaceRobotOnTable(Table table = null)
        {
            if (table != null) this.Table = table;
            if (this.Table == null) return false;

            return this.Table.AssignRobot(this);
        }

        public bool ChangeDirection(Side side)
        {
            switch (this.Direction)
            {
                case Direction.NORTH:
                    if (side == Side.RIGHT)
                    {
                        Direction = Direction.EAST;
                        return true;
                    }
                    else if (side == Side.LEFT)
                    {
                        Direction = Direction.WEST;
                        return true;
                    }
                    return false;
                case Direction.EAST:
                    if (side == Side.RIGHT)
                    {
                        Direction = Direction.SOUTH;
                        return true;
                    }
                    else if (side == Side.LEFT)
                    {
                        Direction = Direction.NORTH;
                        return true;
                    }
                    return false;
                case Direction.SOUTH:
                    if (side == Side.RIGHT)
                    {
                        Direction = Direction.WEST;
                        return true;
                    }
                    else if (side == Side.LEFT)
                    {
                        Direction = Direction.EAST;
                        return true;
                    }
                    return false;
                case Direction.WEST:
                    if (side == Side.RIGHT)
                    {
                        Direction = Direction.NORTH;
                        return true;
                    }
                    else if (side == Side.LEFT)
                    {
                        Direction = Direction.SOUTH;
                        return true;
                    }
                    return false;
            }

            // Default value if none of the above succeeded
            return false;
        }

        public IPosition SetPositionOnTable(IPosition position, Table table = null)
        {
            if (this.PlaceRobotOnTable(table))
            {
                return SetPosition(position);
            }

            return GetPosition();
        }

        internal IPosition SetPosition(IPosition position)
        {
            // Can't set position is robot is not on the table
            if (!IsRobotOnTable()) return null;

            // Set position only for a valid position on the table
            if (this.Table.ValidatePosition(position.XEastWestAxis, position.YNorthSouthAxis))
            {
                this.Direction = position.Direction;
                this.XAxisLocation = position.XEastWestAxis;
                this.YAxisLocation = position.YNorthSouthAxis;
                return position;
            }

            // null if the can't set a position due to 
            return null;
        }

        public IPosition GetPosition()
        {
            if (IsRobotOnTable())
            {
                return new Position(this.XAxisLocation, this.YAxisLocation, this.Direction);
            }
            return null;
        }

        public bool IsRobotOnTable()
        {
            return this.Table != null && this.Equals(Table.Robot);
        }


        public bool Equals(Robot other)
        {
            return other != null && this.Guid.Equals(other.Guid);
        }

        public override string ToString()
        {
            var str = $"Robot: Guid = {Guid}";

            if (IsRobotOnTable())
            {
                str += $" ,Position: {this.GetPosition()}";
            }

            return str;
        }
    }
}
