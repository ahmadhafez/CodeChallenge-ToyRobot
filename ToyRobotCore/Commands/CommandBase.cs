using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotCore.Commands
{
    internal abstract class CommandBase
    {
        public virtual bool ValidateCommand(Robot robot)
        {
            if (robot == null) return false;
            if (robot.Table == null) return false;
            return robot.Table.IsRobotOnTable(robot);
        }
    }
}
