using System;
using System.Threading.Tasks;
using ToyRobotCore.Commands;

namespace ToyRobotCore.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementCommand _leftCommand;
        private readonly IMovementCommand _rightCommand;
        private readonly IMovementCommand _moveCommand;


        internal MovementService(IMovementCommand leftCommand, IMovementCommand rightCommand, IMovementCommand moveCommand)
        {
            _leftCommand = leftCommand;
            _rightCommand = rightCommand;
            _moveCommand = moveCommand;
        }

        public async Task<bool> Left(Robot robot)
        {
            return await _leftCommand.Excute(robot);
        }

        public async Task<bool> Right(Robot robot)
        {
            return await _rightCommand.Excute(robot);
        }

        public async Task<bool> Move(Robot robot)
        {
            return await _moveCommand.Excute(robot);
        }
    }
}
