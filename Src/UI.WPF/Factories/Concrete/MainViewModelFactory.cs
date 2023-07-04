using Core.Services;
using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Configs;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    private readonly AppSettings _appSettings;

    private readonly IDisplayService _displayService;

    public MainViewModelFactory(AppSettings appSettings, IDisplayService displayService)
    {
        _appSettings = appSettings;
        _displayService = displayService;
    }

    public IMainViewModel Create(IMainView mainView)
    {
        return new MainViewModel(new AppearCommand(mainView), new ExitCommand(mainView, _displayService), new ChangeOpacityCommand(_displayService),
            new LightsConsole(new LightsOutCommand(_displayService), new LightsOnCommand(_displayService)), _appSettings.Opacity, _displayService);
    }
}
