using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;
using System.Windows.Input;

using System.ComponentModel; // InotifyPropertyChanged
using System.Runtime.CompilerServices;

namespace LearnWpfMvvm
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand CommandOne { get; }

        #region INotifyPropertyChanged stuff
        private int _executionCount = 0;
        public int ExecutionCount 
        { 
            get => _executionCount;
            private set
            {
                _executionCount = value;
                RaisePropertyChanged();
            }             
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public MainWindowViewModel()
        {
            CommandOne = new SimpleCommand(ShowBox);
        }

        public void ShowBox()
        {
            ExecutionCount++;
            MessageBox.Show("Command Executed");
        }
    }
}
