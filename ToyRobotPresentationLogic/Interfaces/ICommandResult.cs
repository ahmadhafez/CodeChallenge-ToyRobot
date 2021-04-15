using ToyRobotCore.Utils;

namespace ToyRobotPresentationLogic.Interfaces
{
    public interface ICommandResult
    {
        /// <summary>
        /// Did the command executed successfully or ignored due validation issues
        /// </summary>
        bool Succeeded { get; }
        /// <summary>
        /// Has position result to output to the user
        /// </summary>
        bool HasPoistionOutput { get; }

        /// <summary>
        /// Has position but no need to output it to the user
        /// </summary>
        bool HasPoistion { get; }

        /// <summary>
        /// Position outcome from the command
        /// </summary>
        IPosition Position { get; }

    }
}