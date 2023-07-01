using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class LightsOnCommand : ICommand
{
    private readonly ICoverView _cover;

    public LightsOnCommand(ICoverView cover)
    {
        _cover = cover;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _cover.Hide();
    }
}
