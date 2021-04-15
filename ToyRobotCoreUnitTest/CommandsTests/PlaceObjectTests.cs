using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using ToyRobotCore;
using ToyRobotCore.Utils;
using ToyRobotCore.Commands;
using System.Threading.Tasks;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class PlaceObjectTests
    {
        [Theory]
        [InlineData(0,0,Direction.EAST)]
        public async Task ShouldSucceedPlaceInFrontOfRobot(int x, int y, Direction direction)
        {
            var robot = new Robot(Table.GetTableInstance());
            Position position = new Position(x, y, direction);
            var command = new PlaceObjectCommand();
          
            var result = await command.Excute(robot, position);

            // TODO: Add moe tests and allow the test code to verify regardless of the input data
            // This is restrictly developed for the interview

            //result.ShouldBe();
        }
    }
}
