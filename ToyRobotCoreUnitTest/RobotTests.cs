using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest
{
    public class RobotTests
    {
        [Theory]
        [InlineData(Direction.NORTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]
        public void ShouldSucceedTurnRightFromEachDirection(Direction current, Direction expected)
        {
            var robot = new Robot(Table.GetTableInstance());
            robot.SetPositionOnTable(new Position(0, 0, current));

            robot.ChangeDirection(Side.RIGHT);
            robot.Direction.ShouldBe(expected);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.EAST, Direction.NORTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        public void ShouldSucceedTurnLeftFromEachDirection(Direction current, Direction expected)
        {
            var robot = new Robot(Table.GetTableInstance());
            
            robot.SetPositionOnTable(new Position(0, 0, current));

            robot.ChangeDirection(Side.LEFT);
            robot.Direction.ShouldBe(expected);
        }
    }
}
