using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class MoveCommandTests
    {

        [Theory]
        [InlineData(Direction.NORTH, 2, 3)]
        [InlineData(Direction.EAST, 3, 2)]
        [InlineData(Direction.SOUTH, 2, 1)]
        [InlineData(Direction.WEST, 1, 2)]
        public async Task ShouldSucceedMove(Direction direction, int expectedX, int expectedY)
        {
            var robot = new Robot(Table.GetTableInstance());

            // Set up a location for robot
            robot.SetPositionOnTable(new Position(2, 2, direction));

            // Execute 
            var command = new MoveCommand();

            await command.Excute(robot);

            // Validate
            robot.XAxisLocation.ShouldBe(expectedX);
            robot.YAxisLocation.ShouldBe(expectedY);
            robot.Direction.ShouldBe(direction);
        }

        [Theory]
        [InlineData(Direction.NORTH, 0, 0, 0, 4)]
        [InlineData(Direction.EAST, 0, 0, 4, 0)]
        [InlineData(Direction.SOUTH, 0, 4, 0, 0)]
        [InlineData(Direction.WEST, 4, 0, 0, 0)]
        public async Task ShouldPreventFromFalling(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            var robot = new Robot(Table.GetTableInstance());

            // Set up a location for robot
            robot.SetPositionOnTable(new Position(startX, startY, direction));

            // Execute 
            var command = new MoveCommand();

            for (int i = 0; i < 10; i++)
            {
                await command.Excute(robot);
            }

            robot.XAxisLocation.ShouldBe(expectedX);
            robot.YAxisLocation.ShouldBe(expectedY);
            robot.Direction.ShouldBe(direction);
        }
    }
}
