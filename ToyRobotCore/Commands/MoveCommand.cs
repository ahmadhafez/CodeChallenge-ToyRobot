using System;
using System.Threading.Tasks;

namespace ToyRobotCore.Commands
{
    internal class MoveCommand : CommandBase, IMovementCommand
    {
        /// <summary>
        /// Move the robot step towards to the direction the robot facing
        /// </summary>
        /// <param name="robot">robot to execute the movement</param>
        /// <returns>Returns if the movement succeeded</returns>
        public async Task<bool> Excute(Robot robot)
        {
            if(ValidateCommand(robot))
            {
                return robot.Move();
            }

            return false;
             
        }

    }
}
