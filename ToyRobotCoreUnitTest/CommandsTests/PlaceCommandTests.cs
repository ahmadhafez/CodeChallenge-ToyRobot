using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class PlaceCommandTests
    {
        [Theory]
        [InlineData(6, 0)]
        [InlineData(0, 6)]
        [InlineData(6, 6)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-6, -6)]
        public async Task ShouldFailFirstPlaceCommand(int x, int y)
        {
            var robot = new Robot(Table.GetTableInstance());
            Position position = new Position(x, y, Direction.NORTH);
            var command = new PlaceCommand();
            var result = await command.Excute(robot, position);
            result.ShouldBe(null);

            // Set up a location for robot
            robot.SetPosition(new Position(2, 3, Direction.NORTH));

            // execut the command and make sure it doesnot 
            result = await command.Excute(robot, position);
            result.ShouldBe(null);

        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(5, 6)]
        [InlineData(5, 5)]
        [InlineData(8, 10)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-6, -6)]
        public async Task ShouldFailPlaceCommandWithExistingLocation(int x, int y)
        {
            // Setup
            var robot = new Robot(Table.GetTableInstance());
            Position position = new Position(x, y, Direction.NORTH);
            var command = new PlaceCommand();
            var newPosition = new Position(2, 3, Direction.NORTH);

            // Set up a location for robot
            robot.SetPositionOnTable(newPosition);

            // Excute
            var result = await command.Excute(robot, position);

            // Validate
            result.ShouldBe(null);
            robot.GetPosition().ShouldBe(newPosition);
        }

        [Theory]
        [InlineData(1, 2, Direction.NORTH)]
        [InlineData(0, 4, Direction.SOUTH)]
        public async Task ShouldSucceedPlaceRobotForRobotNotOnTable(int x, int y, Direction direction)
        {
            // Setup
            var robot = new Robot(Table.GetTableInstance());
            Position position = new Position(x, y, direction);
            var command = new PlaceCommand();

            // Excute
            var result = await command.Excute(robot, position);

            // Validate
            result.XEastWestAxis.ShouldBe(x);
            result.YNorthSouthAxis.ShouldBe(y);
            result.Direction.ShouldBe(direction);
        }

        [Theory]
        [InlineData(1, 2, Direction.WEST)]
        [InlineData(0, 4, Direction.EAST)]
        public async Task ShouldSucceedPlaceRobotForRobotOnTableWithPosition(int x, int y, Direction direction)
        {
            // Setup
            var robot = new Robot(Table.GetTableInstance());
            Position position = new Position(x, y, direction);
            var command = new PlaceCommand();

            // Set up a location for robot
            robot.SetPositionOnTable(new Position(2, 3, Direction.EAST));

            // Excute
            var result = await command.Excute(robot, position);

            // Validate
            result.XEastWestAxis.ShouldBe(x);
            result.YNorthSouthAxis.ShouldBe(y);
            result.Direction.ShouldBe(direction);
        }
    }
}
