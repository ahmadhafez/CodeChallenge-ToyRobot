using System;

namespace ToyRobotCore.Utils
{
    /// <summary>
    /// Represents robot position properties
    /// </summary>
    public interface IPosition : IEquatable<IPosition>
    {
        /// <summary>
        /// Robot current direction for next movement
        /// </summary>
        Direction Direction { get; set; }
        
        /// <summary>
        /// Robot position on the X axis to move East or West
        /// </summary>
        int XEastWestAxis { get; set; }
        
        /// <summary>
        /// Robot position on the Y axis to move North or South
        /// </summary>
        int YNorthSouthAxis { get; set; }
    }
}