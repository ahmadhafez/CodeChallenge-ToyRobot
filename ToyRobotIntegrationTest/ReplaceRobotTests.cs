using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotIntegrationTest
{
    public class ReplaceRobotTests : TestsBase
    { 

        [Test]
        public async Task Test1()
        {
            // Setup
            _commands.Add("MOVE");
            _commands.Add("PLACE 3,3,WEST");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "3,3,WEST");
        }

        [Test]
        public async Task Test2()
        {
            // Setup
            _commands.Add("PLACE 1,2,WEST");
            _commands.Add("MOVE");
            _commands.Add("PLACE 3,3,WEST");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "3,3,WEST");
        }

        [Test]
        public async Task Test3()
        {
            // Setup
            _commands.Add("PLACE 1,2,WEST");
            _commands.Add("MOVE");
            _commands.Add("PLACE -3,3,WEST");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,2,WEST");
        }

        [Test]
        public async Task Test4()
        {
            _commands = new List<string>();
            // Setup
            _commands.Add("PLACE -3,3,WEST");
            _commands.Add("MOVE");
            _commands.Add("LEFT");
            _commands.Add("MOVE");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 0);
        }
    }
}
