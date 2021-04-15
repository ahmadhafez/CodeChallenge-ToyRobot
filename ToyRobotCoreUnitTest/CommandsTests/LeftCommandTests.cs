using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class LeftCommandTests
    {
        [Fact]
        public async Task ShouldFailValidationRobotNotOnTheTableTest()
        {
            var leftCommand = new LeftCommand();
            Robot robot = new Robot(Table.GetTableInstance());

            var result = await leftCommand.Excute(robot);
            result.ShouldBe(false);
        }

        [Theory]
        [InlineData(Direction.EAST, Direction.NORTH)]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        public async Task ShouldSucceedTest(Direction from, Direction expected)
        {
            var leftCommand = new LeftCommand();
            Robot robot = new Robot(Table.GetTableInstance());
            robot.SetPositionOnTable(new Position(0, 0, from));

            var result = await leftCommand.Excute(robot);
            result.ShouldBe(true);
            robot.Direction.ShouldBe(expected);
        }

    }
}
