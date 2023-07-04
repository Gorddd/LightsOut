using Core.Services;
using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class LightsOnCommand : ICommand
{
    private readonly IDisplayService _displayService;

    public LightsOnCommand(IDisplayService displayService)
    {
        _displayService = displayService;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _displayService.Uncover();
    }
}
