using System.Collections.Generic;

namespace Command.Business.Commands
{

    public class CommandManager
    {

        private readonly Stack<ICommand> _commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute()) {
                _commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (_commands.Count > 0) {
                var command = _commands.Pop();
                command.Undo();
            }
        }
        
        public void Commit()
        {
            if (_commands.Count > 0) {
                _commands.Clear();
            }
        }

    }

}