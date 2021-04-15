using System.Threading.Tasks;

namespace ToyRobotCore.Services
{
    /// <summary>
    /// Interface for robot movement commands service
    /// </summary>
    public interface IMovementService
    {
        /// <summary>
        /// Turn the given robot to the left 90 degree
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        Task<bool> Left(Robot robot);

        /// <summary>
        /// Move the robot to its current direction
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        Task<bool> Move(Robot robot);

        /// <summary>
        /// Turn the given robot to the right 90 degree
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        Task<bool> Right(Robot robot);
    }
}