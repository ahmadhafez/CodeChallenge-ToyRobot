using System;
using System.Threading.Tasks;

namespace ToyRobotCore.Commands
{
    /// <summary>
    /// Generic command interface for all type of commands
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Exercise if the command is valid to execute for the given robot
        /// </summary>
        /// <param name="robot">Robot object to validate it's command</param>
        /// <returns></returns>
        bool ValidateCommand(Robot robot);
    }
}
