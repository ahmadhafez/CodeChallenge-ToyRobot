using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToyRobotPresentationLogic.Builders;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotIntegrationTest
{
    public class ValidSimpleTests : TestsBase
    {
        
        [SetUp]
        public void Setup()
        {
            _service.Execute("PLACE 0,0,NORTH");
        }

        [Test]
        public async Task Test1()
        {
            // Setup
            _commands.Add("MOVE");
            _commands.Add("REPORT");

            // Execute
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());
            
            // Validate
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,1,NORTH");
        }

        [Test]
        public async Task Test2()
        {
            _commands.Add("LEFT");
            _commands.Add("REPORT");
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "0,0,WEST");
        }

        [Test]
        public async Task Test3()
        {
            _commands.Add("PLACE 1,2,EAST");
            _commands.Add("MOVE");
            _commands.Add("MOVE");
            _commands.Add("LEFT");
            _commands.Add("MOVE");
            _commands.Add("REPORT");
            var result = await _service.ExecuteCommandsWithOutput(_commands.ToArray());
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == "3,3,NORTH");
        }
    }
}