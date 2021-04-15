using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToyRobotPresentationLogic.Builders;
using ToyRobotPresentationLogic.Interfaces;

namespace ToyRobotIntegrationTest
{
    public abstract class TestsBase
    {
        protected  ICommandInterpreterService _service;
        protected List<string> _commands;

        [SetUp]
        public void SetupBase()
        {
            var builder = new CommandInterpreterServiceBuilder();
            _service = builder.GetCommandInterpreterService();
            _commands = new List<string>();
        }

        protected void RepeatMove(int num = 10)
        {
            for (int i = 0; i < num; i++)
            {
                _commands.Add("MOVE");
            }
        }
    }
}
