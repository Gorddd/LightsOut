using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class ExitCommand : ICommand
{
    private readonly IExitView _view;

    public ExitCommand(IExitView view)
    {
        _view = view;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _view.Exit();
    }
}
