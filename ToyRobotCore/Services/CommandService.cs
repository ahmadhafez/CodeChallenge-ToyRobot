using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToyRobotCore.Utils;

namespace ToyRobotCore.Services
{
    public class CommandService : ICommandService
    {
        private readonly IPositionService _positionService;
        private readonly IMovementService _movementService;
        private readonly Robot _robot;
         
        public CommandService(IPositionService positionService, IMovementService movementService, Robot robot)
        {
            _positionService = positionService;
            _movementService = movementService;
            _robot = robot;
        }

        public async Task<bool> Left()
        {
            return await _movementService.Left(_robot);
        }

        public async Task<bool> Move()
        {
            return await _movementService.Move(_robot);
        }

        public async Task<IPosition> Place(IPosition position)
        {
            return await _positionService.Place(_robot, position);
        }

        public async Task<IPosition> Report()
        {
            return await _positionService.Report(_robot);
        }

        public async Task<bool> Right()
        {
            return await _movementService.Right(_robot);
        }
    }
}
