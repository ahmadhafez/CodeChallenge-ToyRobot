using System;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Commands
{
    internal class ReportCommand : CommandBase, IPositionCommand
    {
        /// <summary>
        /// Report the current position for the robot
        /// </summary>
        /// <param name="robot">robot to report its current position</param>
        /// <returns>Returns the current position for the robot</returns>
        public async Task<IPosition> Excute(Robot robot, IPosition position = null)
        {
            if(ValidateCommand(robot))
            {
                var pos = new Position(robot.XAxisLocation, robot.YAxisLocation, robot.Direction);
                return pos;
            }

            return null;
        }
    }
}
