using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotCore
{
    internal class TableObject
    {
        public Guid Guid { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        TableObject(int x, int y)
        {
            Guid = Guid.NewGuid();
            this.X = x;
            this.Y = y;
        }
    }
}
