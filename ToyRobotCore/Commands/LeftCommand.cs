using System;
using System.Threading.Tasks;

namespace ToyRobotCore.Commands
{
    internal class LeftCommand : CommandBase, IMovementCommand
    {
        /// <summary>
        /// Turn the robot direction to the left from the current position
        /// </summary>
        /// <param name="robot">Robot object to perform the action</param>
        /// <returns>Return if the action succeed</returns>
        public async Task<bool> Excute(Robot robot)
        {
            if (ValidateCommand(robot))
            {
                robot.ChangeDirection(Utils.Side.LEFT);
                return true;
            }

            return false;
        }
    }
}
