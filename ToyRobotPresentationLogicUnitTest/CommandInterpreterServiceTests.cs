using System;
using Xunit;
using Moq;
using ToyRobotCore.Services;
using System.Threading.Tasks;
using ToyRobotPresentationLogic.Interfaces;
using ToyRobotCore.Utils;
using ToyRobotPresentationLogic;
using Shouldly;

namespace ToyRobotPresentationLogicUnitTest
{
    public class CommandInterpreterServiceTests
    {
        [Theory]
        [InlineData("Left",Command.LEFT)]
        [InlineData("Right", Command.RIGHT)]
        [InlineData("Move", Command.MOVE)]
        public async Task ShouldSucceedValidCommandsAsync(string commandStr, Command command)
        {
            Mock<ICommandService> mock = new Mock<ICommandService>();
            mock.Setup(x => x.Left()).Returns(Task.FromResult(true));
            mock.Setup(x => x.Right()).Returns(Task.FromResult(true));
            mock.Setup(x => x.Move()).Returns(Task.FromResult(true));

            Mock<ICommandInterpreter> commandInterpreterMock = new Mock<ICommandInterpreter>();
            Tuple<Command, IPosition> interpreterResult = new Tuple<Command, IPosition>(command, null);
            commandInterpreterMock.Setup(x => x.Interpret(commandStr)).Returns(interpreterResult);

            var service = new CommandInterpreterService(commandInterpreterMock.Object, mock.Object);

            var result = await service.Execute(commandStr);

            result.Succeeded.ShouldBe(true);
            result.HasPoistionOutput.ShouldBe(false);
        }
    }
}
