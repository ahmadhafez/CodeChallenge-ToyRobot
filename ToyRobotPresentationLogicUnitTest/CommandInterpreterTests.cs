using Shouldly;
using System;
using ToyRobotCore.Utils;
using ToyRobotPresentationLogic;
using Xunit;

namespace ToyRobotPresentationLogicUnitTest
{
    public class CommandInterpreterTests
    {
        [Theory]
        [InlineData("Left ",Command.LEFT,null)]
        [InlineData(" LEFT", Command.LEFT, null)]
        [InlineData("LefT ", Command.LEFT, null)]
        [InlineData(" Right  ", Command.RIGHT, null)]
        [InlineData("RIGHT   ", Command.RIGHT, null)]
        [InlineData("   RighT    ", Command.RIGHT, null)]
        [InlineData(" Move  ", Command.MOVE, null)]
        [InlineData("  MOVE  ", Command.MOVE, null)]
        [InlineData("  mOVe  ", Command.MOVE, null)]
        [InlineData(" Report  ", Command.REPORT, null)]
        [InlineData("   REPORT  ", Command.REPORT, null)]
        [InlineData("RePoRt", Command.REPORT, null)]
        public void ShouldInterpretValidCommands(string commandStr, Command expectedCommand, IPosition expectedPosition)
        {
            // Setup
            var interpreter = new CommandInterpreter();
            
            // Execute
            var result = interpreter.Interpret(commandStr);

            // Validate
            result.Item1.ShouldBe(expectedCommand);
            result.Item2.ShouldBe(expectedPosition);
        }

        [Theory]
        [InlineData(" Place 1,2,North", 1, 2,Direction.NORTH)]
        [InlineData("PLACE  0 , 0 , EaSt", 0, 0, Direction.EAST)]
        [InlineData(" PlaCE  4 , 4 , SouTh", 4, 4, Direction.SOUTH)]
        [InlineData("PLaCE  1  ,  1 , WEST", 1, 1, Direction.WEST)]
        public void ShouldInterpretValidPlaceCommand(string commandStr, int x, int y, Direction direction)
        {
            // Setup
            var interpreter = new CommandInterpreter();

            // Execute
            var result = interpreter.Interpret(commandStr);

            // Validate
            result.Item1.ShouldBe(Command.PLACE);
            result.Item2.XEastWestAxis.ShouldBe(x);
            result.Item2.YNorthSouthAxis.ShouldBe(y);
            result.Item2.Direction.ShouldBe(direction);
        }

        [Theory]
        [InlineData("Place")]
        [InlineData("PLACE  0 ")]
        [InlineData("PlaCE  4 , ")]
        [InlineData("PLaCE  1  ,  1 ")]
        [InlineData("PLaCE  1  ,  1 , ")]
        [InlineData("PLACE  0,0,LEFT")]
        [InlineData("PLACE  0,0,Right")]
        public void ShouldNotInterpretInValidPlaceCommand(string commandStr)
        {
            // Setup
            var interpreter = new CommandInterpreter();

            // Execute
            var result = interpreter.Interpret(commandStr);

            // Validate
            result.ShouldBe(null);
        }
    }
}
