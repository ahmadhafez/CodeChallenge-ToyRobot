using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotCore.Utils;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotPresentationLogic
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public Tuple<Command, IPosition> Interpret(string commandtStr)
        {
            try
            {
                var commandStrArr = commandtStr.Trim().Split(' ');

                // Get the command
                Command command = (Command)Enum.Parse(typeof(Command), commandStrArr[0].Trim(), true);

                // return commands which don't require position
                if (command == Command.LEFT || command == Command.MOVE
                    || command == Command.RIGHT || command == Command.REPORT)
                {
                    return new Tuple<Command, IPosition>(command, null);
                }

                if (command == Command.PLACE)
                {
                    var sub = commandtStr.Trim().Substring(5);
                    if (!string.IsNullOrEmpty(sub))
                    {
                        var positionStrArr = sub.Trim().Split(',');

                        // Extract position properties
                        var x = int.Parse(positionStrArr[0].Trim());
                        var y = int.Parse(positionStrArr[1].Trim());
                        var direction = (Direction)Enum.Parse(typeof(Direction), positionStrArr[2].Trim(), true);
                        var position = new Position(x, y, direction);

                        return new Tuple<Command, IPosition>(command, position);
                    }

                }

                return null;

            }
            catch
            {
                // Default value for inncorrect input data
                return null;
            }

        }
    }
}
