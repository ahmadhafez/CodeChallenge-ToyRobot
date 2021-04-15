using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToyRobotPresentationLogic.Interfaces
{
    public interface ICommandInterpreterService
    {
        Task<ICommandResult> Execute(string commandStr);
        Task<List<ICommandResult>> Execute(string[] stringCommands);
        Task<string[]> ExecuteCommandsWithOutput(string[] stringCommands);
    }
}