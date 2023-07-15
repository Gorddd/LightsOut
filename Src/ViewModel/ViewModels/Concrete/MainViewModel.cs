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
using ViewModel.Commands;

namespace ViewModel.ViewModels.Concrete;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public MainViewModel(ICommand appearCommand, ICommand exitCommand, ICommand changeOpacityCommand, 
        ILightsConsole lightsConsole, double opacity, IDisplayService displayService)
    {
        AppearCommand = appearCommand;
        ExitCommand = exitCommand;
        ChangeOpacityCommand = changeOpacityCommand;
        Opacity = opacity;

        LightsOutCommand = new LightsOutCommandWrapper(() => IsChecked = true, lightsConsole.LightsOutCommand);
        LightsOnCommand = new LightsOnCommandWrapper(() => IsChecked = false, lightsConsole.LightsOnCommand);
        UpdateDisplayCommand = new UpdateDisplayCommand(() => IsChecked, displayService);

        _displays = new ObservableCollection<Display>(displayService.Displays);
    }

    public ICommand AppearCommand { get; }

    public ICommand ExitCommand { get; }

    public ICommand ChangeOpacityCommand { get; }

    public ICommand LightsOutCommand { get; }

    public ICommand LightsOnCommand { get; }

    public ICommand UpdateDisplayCommand { get; }

    private bool _isChecked;
    public bool IsChecked
    {
        get
        {
            return _isChecked;
        }
        set
        {
            _isChecked = value;
            OnPropertyChanged(nameof(IsChecked));
        }
    }

    private double _opacity;
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
