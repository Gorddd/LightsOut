using Core.Classes;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    private readonly IDisplayService _displayService;

    public MainViewModel(ICommand appearCommand, ICommand exitCommand, ICommand changeOpacityCommand, 
        ILightsConsole lightsConsole, double opacity, IDisplayService displayService)
    {
        AppearCommand = appearCommand;
        ExitCommand = exitCommand;
        ChangeOpacityCommand = changeOpacityCommand;
        _lightsConsole = lightsConsole;
        Opacity = opacity;
        _displayService = displayService;

        _displays = new ObservableCollection<Display>(_displayService.GetDisplays());
    }

    public ICommand AppearCommand { get; }

    public ICommand ExitCommand { get; }

    public ICommand ChangeOpacityCommand { get; }

    public ICommand LightsOutCommand => _lightsConsole.LightsOutCommand;

    public ICommand LightsOnCommand => _lightsConsole.LightsOnCommand;

    private double _opacity = 10;
    public double Opacity
    {
        get
        {
            return _opacity;
        }
        set
        {
            _opacity = value;
            OnPropertyChanged(nameof(Opacity));
        }
    }

    private readonly ObservableCollection<Display> _displays;
    public IEnumerable<Display> Displays => _displays;
}
