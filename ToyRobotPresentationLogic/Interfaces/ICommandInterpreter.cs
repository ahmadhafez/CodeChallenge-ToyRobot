using System;
using ToyRobotCore.Utils;

namespace ToyRobotPresentationLogic.Interfaces
{
    public interface ICommandInterpreter
    {
        Tuple<Command, IPosition> Interpret(string commandtStr);
    }
}