using System;
using System.Threading.Tasks;
using ToyRobotCore.Commands;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionCommand _placeCommand;
        private readonly IPositionCommand _reportCommand;

        internal PositionService(IPositionCommand placeCommand, IPositionCommand reportCommand)
        {
            _placeCommand = placeCommand;
            _reportCommand = reportCommand;
        }

        public async Task<IPosition> Place(Robot robot, IPosition position)
        {
            return await _placeCommand.Excute(robot, position);
        }

        public async Task<IPosition> Report(Robot robot)
        {
            return await _reportCommand.Excute(robot);
        }
    }
}
