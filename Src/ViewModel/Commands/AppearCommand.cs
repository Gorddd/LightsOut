using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class AppearCommand : ICommand
{
    private readonly IAppearView _view;

    public AppearCommand(IAppearView appearView)
    {
        _view = appearView;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return _view.CanAppear();
    }

    public void Execute(object? parameter)
    {
        _view.Appear();
    }
}
