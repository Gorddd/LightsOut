using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Abstractions.Other;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.ViewModels.Concrete;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    private readonly ILightsConsole _lightsConsole;

    public MainViewModel(ICommand appearCommand, ICommand exitCommand, ILightsConsole lightsConsole)
    {
        AppearCommand = appearCommand;
        _exitCommand = exitCommand;
        _lightsConsole = lightsConsole;
    }

    public ICommand AppearCommand { get; }


    private readonly ICommand _exitCommand;

    public ICommand ExitCommand
    {
        get
        {
            return _exitCommand;
        }
    }


    public ICommand LightsOutCommand => _lightsConsole.LightsOutCommand;

    public ICommand LightsOnCommand => _lightsConsole.LightsOnCommand;
}
