using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;
using System.Windows.Input;

namespace LearnWpfMvvm
{
    class MainWindowViewModel
    {
        public ICommand CommandOne { get; }

        public MainWindowViewModel()
        {
            CommandOne = new SimpleCommand(ShowBox);
        }

        public void ShowBox()
        {
            MessageBox.Show("Command Executed");
        }
    }
}
