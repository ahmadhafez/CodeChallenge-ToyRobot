using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotIntegrationTest
{
    public class InvalidCommandsTests : TestsBase
    {
        [SetUp]
        public async Task SetupAsync()
        {
            await _service.Execute("PLACE 0,0,NORTH");
        }

        [Test]
        public async Task Test1()
        {
            // Setup
            _commands.Add("   ");
            _commands.Add("  sdfsd");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,0,NORTH");
            _commands.Add("LEFT");
        }

        [Test]
        public async Task Test2()
        {
            // Setup
            _commands.Add("PLACE ");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());

            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,0,NORTH");
            _commands.Add("LEFT");
        }
    }
}
