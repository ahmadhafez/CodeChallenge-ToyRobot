using System;
using ToyRobotCore.Builders;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotPresentationLogic.Builders
{
    public class CommandInterpreterServiceBuilder
    {
        public ICommandInterpreterService GetCommandInterpreterService()
        {
            var commandInterpreter = new CommandInterpreter();
            var robotBuilder = new RobotCommandServiceBuilder();
            return new CommandInterpreterService(commandInterpreter, robotBuilder.GetRobotCommandService());
        }
    }
}
