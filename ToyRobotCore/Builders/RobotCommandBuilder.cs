using System;
using ToyRobotCore.Commands;
using ToyRobotCore.Services;

namespace ToyRobotCore.Builders
{
    /// <summary>
    /// Builder for the robot command logic service
    /// </summary>
    public class RobotCommandServiceBuilder
    {
        /// <summary>
        /// Get instance of the robot command logic service
        /// </summary>
        /// <returns></returns>
        public ICommandService GetRobotCommandService()
        {
            Robot robot = new Robot(Table.GetTableInstance());
            var positionService = GetPositionService();
            var movementService = GetMovementService();

            var commandService = new CommandService(positionService, movementService, robot);
            return commandService;
        }

        #region Privat Helper Methods
        private static IPositionService GetPositionService()
        {
            var placeCommand = new PlaceCommand();
            var reportCommand = new ReportCommand();
            return new PositionService(placeCommand, reportCommand);
        }

        private static IMovementService GetMovementService()
        {
            var leftCommand = new LeftCommand();
            var rightCommand = new RightCommand();
            var moveCommand = new MoveCommand();
            return new MovementService(leftCommand, rightCommand, moveCommand);
        }
        #endregion
    }
}
