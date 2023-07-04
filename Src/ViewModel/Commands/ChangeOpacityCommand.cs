using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class ChangeOpacityCommand : ICommand
{
    private readonly IDisplayService _displayService;

    public ChangeOpacityCommand(IDisplayService displayService)
    {
        _displayService = displayService;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return parameter is double;
    }

    public void Execute(object? parameter)
    {
        _displayService.ChangeOpacity((double)parameter!);
    }
}
