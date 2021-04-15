using System;
using ToyRobotCore.Utils;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotPresentationLogic
{
    internal class CommandResult : ICommandResult
    {
        public bool Succeeded { get; private set; }
       
        public IPosition Position { get; private set; }

        public bool HasPoistion
        {
            get
            {
                return Position != null;
            }
        }

        public bool HasPoistionOutput
        {
            get
            {
                return _printPosition && Position != null;
            }
        }

        private readonly bool _printPosition;

        internal CommandResult(bool succeeded)
        {
            Succeeded = succeeded;
            Position = null;
        }

        internal CommandResult(IPosition position, bool printPosition)
        {
            Position = position;
            _printPosition = printPosition;
            Succeeded = position != null;
        }
    }
}
