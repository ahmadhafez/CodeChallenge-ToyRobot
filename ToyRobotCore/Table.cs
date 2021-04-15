using System;
using System.Collections.Generic;

namespace ToyRobotCore
{
    public class Table
    {
        public const int c_x = 5;
        public const int c_y = 5;

        public int X { get; private set; }
        public int Y { get; private set; }

        internal List<TableObject> TableObjects { get; private set; }
        
        // Better for perfomance approach.
       // public Dictionary<KeyValuePair<int,int>, Guid> Objects { get; private set; }

        public Robot Robot { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return Robot == null;
            }
        }

        public static Table GetTableInstance()
        {
            return new Table(c_x, c_y);
        }

        public static Table GetTableInstance(int p_x, int p_y)
        {
            
            return new Table(p_x, p_y);
        }

        private Table() { }
        private Table(int p_x, int p_y)
        {
            X = p_x;
            Y = p_y;
            TableObjects = new List<TableObject>();
        }


        public bool AssignRobot(Robot robot)
        {
            //if (!IsEmpty) return false;

            this.Robot = robot;
            return true;
        }

        public bool ValidatePosition(int x, int y)
        {
            // You can validate any obstacles here
            if (x >= X || x < 0) return false;
            if (y >= Y || y < 0) return false;

            // Valid scenario
            return true;
        }


        public bool IsRobotOnTable(Robot robot)
        {
            if (IsEmpty) return false;
            return this.Robot.Equals(robot);
        }
    }
}
