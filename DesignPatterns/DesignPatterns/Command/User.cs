using System;
using System.Collections.Generic;

namespace Command
{
    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class User
    {
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _commandsCount = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if (_commandsCount < _commands.Count - 1)
                {
                    Command command = _commands[_commandsCount++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (_commandsCount > 0)
                {
                    Command command = _commands[--_commandsCount] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(_calculator, @operator, operand);
            command.Execute();
            _commands.Add(command);
            _commandsCount++;
        }
    }
}
