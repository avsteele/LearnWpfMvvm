# LearnWpfMvvm
A basic introduction to WPF, MVVM, Behaviors, Commands, and Bindings.

Provided as a Visual Studio 2019 Solution.  

I wrote this because I found existing examples on the web either outdated or dumped a lot of complexity on the learner all at once.  

**Reccomendation: Spend some time trying to understand each part of Example 1 and the rest should be realtively easy.**

## Simplified Instructions
*	Clone the repository to get started
* Each new example adds a bit of complexity or a new feature from the previous
* To go to a particular example: go to Team explorer->'Tags' and click on the example desired

# Example 1 
Basic Window with View and ViewModel.  It will pop up a message box when the window is clicked indicating the command has executed.
# Example 2
Use of CanExecute to disable command processing.  When you click and the Command executes, it will be disabled for two seconds. Click rapidly after clearing the messageBox to observ this.
# Example 3
Modulate behavior of canExecute by passing a parameter to Execute from the Xaml. The length of time for which can be set through teh `CommandParamter` in tehe XAML
# Example 4
Use of single command on multiple Gui elements. In this one the command will fire if the window is clicked, *or
* Note that single/same instance is used for both the window clicking and the canvas MouseEneter
* Note new event type used ("MouseEnter")
* Since multiple elements of the Wpf (namely the window and he canvas) both use the same command, they both need thier DataContext set to teh same object. I moved this into a 'static resource' to allow both elements to reference this same instance.

# Example 5
Here a Property in the ViewModel is bound to a TextBlock. This allows data from the ViewModel to flow back to the window for display to the user.
The count is incremented every time the command is fired.  

For this to work we require the ViewModel to implement The INotifyPropertyChanged Interface; this interface requires us to add a simple event handler to the ViewModel class.
If we want changes to the property to be reflected in the TextBlock, the every time this value is 'set' we must raise the appropriate event.

# Supplemental Notes: 
* In ALL of the example: I notice that as of this writing (1/14/2020) Visual Studio, in the XAML, sometimes will think there are errors in the code when there are not any (you will see blue squiggles under the XAML).  You may need to ignore these and just build/run. After a run these usually disappear
* To go back to the tip from an tag: to Team Explorer->branches and double click on 'master' (until you do this you will be in 'detached head' mode)

# Basic setup for the Solution through Example 1
Below is some additinal infomration that might help you to recreate example 1 from scratch and/or understand some of its elements.

First, Create a new .Net Core c# WPF app using hte Visual Studio 2019 template.

### Make a new class file for our class (SimpleCommand) that will implement ICommand
* This interface requires you to implement Execute, CanExecute and CanExecuteChanged
* Execute is called when the command is executed by the xaml, 
* CanExecute is a member returning a bool indicating if execution of the command  is currently allowed. 
* CanExecuteChanged is used know when the value returned by CanExecute would change. (I understand how it is used less well than the other parts.)
### Make new Class for the ViewModel
This MUST have
* Property of type ICommand with public getter (if it is just a member field it won't work). Type of this can be Icommand OR any class implementing ICommand
* The constructor constructs it with some Action delegate (message box pop up for example)
### Use NuGet to add "Microsoft.Xaml.Bahaviors.Wpf" to the project
See  the official repo at https://github.com/microsoft/XamlBehaviorsWpf for some more advanced examples.
### Adjustments to the XAML
1. Add `xmlns:i="http://schemas.microsoft.com/xaml/behaviors`  to the window
2. Add a DataContext ofto the window consisting of an instance of thte ViewModel class
3. Add an interactivity event with a trigger of leftmousebuttonclick bound ot the ViewModel(DataCOntext).Command
