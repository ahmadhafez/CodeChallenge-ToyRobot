using System;
using System.Threading.Tasks;

namespace ToyRobotCore.Commands
{
    internal class RightCommand : CommandBase, IMovementCommand
    {
        /// <summary>
        /// Turn the robot direction to the right from the current position
        /// </summary>
        /// <param name="robot">Robot object to perform the action</param>
        /// <returns>Return if the action succeed</returns>
        public async Task<bool> Excute(Robot robot)
        {

            if (ValidateCommand(robot))
            {
                return robot.ChangeDirection(Utils.Side.RIGHT);
            }
            return false;
        }
 

    }
}
