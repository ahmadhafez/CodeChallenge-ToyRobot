using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Services
{
    /// <summary>
    /// Command service interface to contorl the robot
    /// </summary>
    public interface ICommandService 
    {
        /// <summary>
        /// Turn the robot object 90 degree to the left without moving
        /// </summary>
        /// <returns></returns>
        Task<bool> Left();

        /// <summary>
        /// Turn the robot object 90 degree to the right without moving
        /// </summary>
        /// <returns></returns>
        Task<bool> Right();

        /// <summary>
        /// Move the robot heading to its current direction. You can change direction through other commands in this interface
        /// </summary>
        /// <returns>Returns if the robot object has succedded to move. Robot object will be prevented from moving if doesn't sattisfy the movement validation condition</returns>
        Task<bool> Move();

        /// <summary>
        /// Put the robot on the table with specific position and direction
        /// </summary>
        /// <param name="position">Positon to replace the robot on table and direction</param>
        /// <returns>Return the position the robot placed into or null if cannot place it for validation vaiolations</returns>
        Task<IPosition> Place(IPosition position);

        /// <summary>
        /// Returns the current location and direction for the robot
        /// </summary>
        /// <returns></returns>
        Task<IPosition> Report();
    }
}
