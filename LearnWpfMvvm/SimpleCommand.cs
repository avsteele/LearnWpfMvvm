using System;

using System.Windows.Input; //For ICommand

namespace LearnWpfMvvm
{
    public class SimpleCommand : ICommand
    {
        private Action _action;
        private bool _canExecute = true;

        public SimpleCommand(Action a)
        {
            _action = a;
        }

        public bool CanExecute(object o)
        {
            return _canExecute;
        }

        public void Execute(object o)
        {
            if (CanExecute(o))
                _action();

            _canExecute = false; // Command is now disabled
            var timer = new System.Timers.Timer(2000);
            timer.Elapsed += (o, e) => _canExecute = true; // when time is up, set _canExecute back to true
            timer.AutoReset = false; // only do 'Elapsed' once when time i sup, not repeateedly
            timer.Enabled = true;

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
