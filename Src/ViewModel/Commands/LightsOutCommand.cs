using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class LightsOutCommand : ICommand
{
    private readonly ICoverView _cover;

    public LightsOutCommand(ICoverView cover)
    {
        _cover = cover;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _cover.CanAppear();
    }

    public void Execute(object? parameter)
    {
        _cover.Appear();
    }
}
