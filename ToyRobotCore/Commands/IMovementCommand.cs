using System.Threading.Tasks;

namespace ToyRobotCore.Commands
{
    /// <summary>
    /// Interface for movement commands actions
    /// </summary>
    internal interface IMovementCommand : ICommand
    {
        /// <summary>
        /// Perform robot movement 
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
       Task<bool> Excute(Robot robot);
    }
}