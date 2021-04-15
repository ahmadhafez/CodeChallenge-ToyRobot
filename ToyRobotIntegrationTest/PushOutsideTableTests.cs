using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ToyRobotIntegrationTest
{
    public class PushOutsideTableTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            _service.Execute("PLACE 0,0,EAST");
        }

        [Test]
        public async Task Test1()
        {
            // Setup
            RepeatMove();
            _commands.Add("Report");
            _commands.Add("LEFT");
            RepeatMove();
            _commands.Add("Report");
            _commands.Add("LEFT");
            RepeatMove();
            _commands.Add("Report");
            _commands.Add("LEFT");
            RepeatMove();
            _commands.Add("Report");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 4);
            Assert.IsTrue(result[0] == "4,0,EAST");
            Assert.IsTrue(result[1] == "4,4,NORTH");
            Assert.IsTrue(result[2] == "0,4,WEST");
            Assert.IsTrue(result[3] == "0,0,SOUTH");
        }

        [Test]
        public async Task Test2()
        {
            // Setup
            await _service.Execute("PLACE 0,0,WEST");
            RepeatMove();
            _commands.Add("Report");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,0,WEST");
        }

        
    }


}
