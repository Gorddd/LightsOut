using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Abstractions.ViewsAbstractions;
using ViewModel.Abstractions;

namespace ViewModel.Commands;

public class ExitCommand : ICommand
{
    private readonly IExitView _view;
    private readonly IDisplayService _displayService;
    private readonly IOpacityRepository _opacityRepository;

    public ExitCommand(IExitView view, IDisplayService displayService, IOpacityRepository opacityRepository)
    {
        _view = view;
        _displayService = displayService;
        _opacityRepository = opacityRepository;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? opacity)
    {
        if (opacity is double op)
            _opacityRepository.SaveOpacity(op);

        _displayService.Dispose();
        _view.Exit();
    }
}
