using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Services
{
    /// <summary>
    /// Interface for robot position commands service
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// Place the given robot into passed position on the table
        /// </summary>
        /// <param name="robot">robot object to be placed</param>
        /// <param name="position">the location and direction to be placed</param>
        /// <returns></returns>
        Task<IPosition> Place(Robot robot, IPosition position);

        /// <summary>
        /// Returns the passed robot position
        /// </summary>
        /// <param name="robot"></param>
        /// <returns>The current location for the robot. Null is it is not placed yet</returns>
        Task<IPosition> Report(Robot robot);
    }
}