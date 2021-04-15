using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToyRobotCore.Services;
using ToyRobotCore.Utils;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotPresentationLogic
{
    internal class CommandInterpreterService : ICommandInterpreterService
    {
        private readonly ICommandInterpreter _commandInterpreter;
        private readonly ICommandService _commandService;

        internal CommandInterpreterService(ICommandInterpreter commandInterpreter, ICommandService commandService)
        {
            _commandInterpreter = commandInterpreter;
            _commandService = commandService;
        }

        public async Task<ICommandResult> Execute(string commandStr)
        {
            if (string.IsNullOrEmpty(commandStr)) return new CommandResult(false);

            var result = _commandInterpreter.Interpret(commandStr);
            
            if (result == null) return new CommandResult(false);

            return result.Item1 switch
            {
                Command.LEFT => new CommandResult(await _commandService.Left()),
                Command.RIGHT => new CommandResult(await _commandService.Right()),
                Command.MOVE => new CommandResult(await _commandService.Move()),
                Command.PLACE => new CommandResult(await _commandService.Place(result.Item2), false),
                Command.REPORT => new CommandResult(await _commandService.Report(), true),
                _ => new CommandResult(false),
            };
        }

        public async Task<List<ICommandResult>> Execute(string[] stringCommands)
        {
            var results = new List<ICommandResult>();
            if (stringCommands == null || stringCommands.Length == 0) return results;

            foreach (var commStr in stringCommands)
            {
                results.Add(await Execute(commStr));
            }

            return results;
        }

        public async Task<string[]> ExecuteCommandsWithOutput(string[] stringCommands)
        {
            var results = new List<string>();
            if (stringCommands == null || stringCommands.Length == 0) return results.ToArray();

            foreach (var commStr in stringCommands)
            {
                var result = await Execute(commStr);

                if (result != null && result.HasPoistionOutput)
                {
                    results.Add(result.Position.ToString());
                }
            }

            return results.ToArray();
        }
    }
}
