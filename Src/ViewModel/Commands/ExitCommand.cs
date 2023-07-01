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
    private readonly ICoverView _cover;

    public ExitCommand(IExitView view, ICoverView cover)
    {
        _view = view;
        _cover = cover;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _cover.Exit();
        _view.Exit();
    }
}
