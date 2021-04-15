using System;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Commands
{
    internal class PlaceCommand : CommandBase, IPositionCommand
    {
        /// <summary>
        /// Place the robot on a certain position
        /// </summary>
        /// <param name="robot">Robot to placed</param>
        /// <param name="position">Postion to place the robot</param>
        /// <returns>Returns the robot current position</returns>
        public async Task<IPosition> Excute(Robot robot, IPosition position)
        {
            if (ValidateCommand(robot))
            {
                if (robot.Table.ValidatePosition(position.XEastWestAxis, position.YNorthSouthAxis))
                {
                    return robot.SetPositionOnTable(position);
                }

            }

            return null;
        }
        public override bool ValidateCommand(Robot robot)
        {
            if (robot == null) return false;
            return robot.Table != null;
        }
    }
}
