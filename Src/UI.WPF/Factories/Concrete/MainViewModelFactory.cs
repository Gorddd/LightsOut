using Core.Services;
using Environment.Implementations;
using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Configs;
using ViewModel.Abstractions;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    private readonly IDisplayService _displayService;
    private readonly IOpacityRepository _opacityRepository;

    public MainViewModelFactory(IDisplayService displayService, IOpacityRepository opacityRepository)
    {
        _displayService = displayService;
        _opacityRepository = opacityRepository;
    }

    public IMainViewModel Create(IMainView mainView)
    {
        return new MainViewModel(new AppearCommand(mainView), new ExitCommand(mainView, _displayService, _opacityRepository), new ChangeOpacityCommand(_displayService),
            new LightsConsole(new LightsOutCommand(_displayService), new LightsOnCommand(_displayService)), 
            _opacityRepository.GetOpacity(), _displayService);
    }
}
