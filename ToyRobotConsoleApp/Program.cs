using System;
using System.Threading.Tasks;
using ToyRobotPresentationLogic.Builders;

namespace ToyRobotConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome robot system!");
            PrintInstrunctions();
            var builder = new CommandInterpreterServiceBuilder();
            var service = builder.GetCommandInterpreterService();
            while (true)
            {
                var result = await service.Execute(Console.ReadLine());
                if(result != null && result.HasPoistionOutput)
                {
                    Console.WriteLine(result.Position);
                }
            }
            
        }

        private static void PrintInstrunctions()
        {
            Console.WriteLine("##############################");
            Console.WriteLine("Valid commands for the robots are:");
            Console.WriteLine(" PLACE X,Y,F");
            Console.WriteLine(" MOVE");
            Console.WriteLine(" LEFT");
            Console.WriteLine(" RIGHT");
            Console.WriteLine(" REPORT ");
            Console.WriteLine("##############################");
        }
    }
}
