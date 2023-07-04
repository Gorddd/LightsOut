using Core.Services;
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
    private readonly IDisplayService _displayService;

    public ExitCommand(IExitView view, IDisplayService displayService)
    {
        _view = view;
        _displayService = displayService;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _displayService.Dispose();
        _view.Exit();
    }
}
