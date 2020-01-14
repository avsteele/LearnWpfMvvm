using System;

using System.Windows.Input; //For ICommand

namespace LearnWpfMvvm
{
    public class SimpleCommand : ICommand
    {
        private Action _action;

        public SimpleCommand(Action a)
        {
            _action = a;
        }

        public bool CanExecute(object o)
        {
            return true;
        }

        public void Execute(object o)
        {
            if (CanExecute(o))
                _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
