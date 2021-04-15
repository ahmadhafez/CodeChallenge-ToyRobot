using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Commands
{
    internal class PlaceObjectCommand : CommandBase, IPositionCommand
    {
        public Task<IPosition> Excute(Robot robot, IPosition position = null)
        {
            // Check if robot and table are not nulls
            switch (robot.Direction)
            {
                case Direction.NORTH:
            if (robot.Table.ValidatePosition(robot.XAxisLocation, robot.YAxisLocation))
                    {

                    }
                }
        }
    }
}
