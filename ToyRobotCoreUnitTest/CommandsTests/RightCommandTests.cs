using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class RightCommandTests
    {
        [Fact]
        public async Task ShouldFailValidationRobotNotOnTheTableTest()
        {
            var rightCommand = new RightCommand();
            Robot robot = new Robot(Table.GetTableInstance());

            var result = await rightCommand.Excute(robot);
            result.ShouldBe(false);
        }

        [Theory]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]
        [InlineData(Direction.NORTH, Direction.EAST)]
        public async Task ShouldSucceedTest(Direction from, Direction expected)
        {
            var rightCommand = new RightCommand();
            Robot robot = new Robot(Table.GetTableInstance());
            robot.SetPositionOnTable(new Position(0, 0, from));

            var result = await rightCommand.Excute(robot);
            result.ShouldBe(true);
            robot.Direction.ShouldBe(expected);
        }
    }
}
