using Core.Classes;
using Core.Services;
using System.Windows.Input;

namespace ViewModel.Commands;

public class UpdateDisplayCommand : ICommand
{
    private Func<bool> _canExecute;
    private readonly IDisplayService _displayService;

    public UpdateDisplayCommand(Func<bool> canExecute, IDisplayService displayService)
    {
        _canExecute = canExecute;
        _displayService = displayService;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke();
    }

    public void Execute(object? parameter)
    {
        if (parameter is Display display)
            _displayService.UpdateDisplay(display);
    }
}
