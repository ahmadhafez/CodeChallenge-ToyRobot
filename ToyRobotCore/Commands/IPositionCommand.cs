using System;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Commands
{
    /// <summary>
    /// Interface for postion commands actions
    /// </summary>
    internal interface IPositionCommand : ICommand
    {
        /// <summary>
        /// Perform command actions for the robot positions
        /// </summary>
        /// <param name="robot">Robot object to perform action</param>
        /// <param name="position">Passing the position to the action. Default value is null</param>
        /// <returns>Returns robot's current position</returns>
        Task<IPosition> Excute(Robot robot, IPosition position = null);
    }
}
