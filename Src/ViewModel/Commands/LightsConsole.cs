using System.Windows.Input;
using UI.Abstractions.Other;

namespace ViewModel.Commands;

public class LightsConsole : ILightsConsole
{
    public LightsConsole(ICommand lightsOut, ICommand lightsOn)
    {
        LightsOutCommand = lightsOut;
        LightsOnCommand = lightsOn;
    }

    public ICommand LightsOutCommand { get; }

    public ICommand LightsOnCommand { get; }
}

class LightsOnCommandWrapper : ICommand
{
    public LightsOnCommandWrapper(Action preAction, ICommand lightsOnCommand)
    {
        _preAction = preAction;
        _lightsOnCommand = lightsOnCommand;
    }

    private Action _preAction { get; set; }
    private ICommand _lightsOnCommand { get; }


    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _lightsOnCommand.CanExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _preAction.Invoke();
        _lightsOnCommand.Execute(parameter);
    }
}

class LightsOutCommandWrapper : ICommand
{
    public LightsOutCommandWrapper(Action preAction, ICommand lightsOutCommand)
    {
        _preAction = preAction;
        _lightsOutCommand = lightsOutCommand;
    }

    private Action _preAction { get; set; }
    private ICommand _lightsOutCommand { get; }


    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _lightsOutCommand.CanExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _preAction.Invoke();
        _lightsOutCommand.Execute(parameter);
    }
}