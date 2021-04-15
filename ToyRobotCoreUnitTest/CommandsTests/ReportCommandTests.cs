using Shouldly;
using System;
using System.Threading.Tasks;
using ToyRobotCore;
using ToyRobotCore.Commands;
using Xunit;
using ToyRobotCore.Utils;

namespace ToyRobotCoreUnitTest.CommandsTests
{
    public class ReportCommandTests
    {
        [Fact]
        public async Task ShouldReportRobotLocationOnTable()
        {
            var robot = new Robot(Table.GetTableInstance());
            var command = new ReportCommand();
            var result = await command.Excute(robot);
            result.ShouldBe(null);
        }

        [Fact]
        public async Task ShouldNOTReportRobotNOTOnTable()
        {
            // Setup
            var robot = new Robot(Table.GetTableInstance());
            
            // Set up a location for robot
            robot.SetPositionOnTable(new Position(2, 3, Direction.WEST));

            // Execute 
            var command = new ReportCommand();
            var result = await command.Excute(robot);

            // Validate
            result.XEastWestAxis.ShouldBe(2);
            result.YNorthSouthAxis.ShouldBe(3);
            result.Direction = Direction.WEST;
        }
    }
}
