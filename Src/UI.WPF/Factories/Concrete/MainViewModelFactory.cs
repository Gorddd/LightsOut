﻿using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Configs;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    private readonly AppSettings _appSettings;
    private readonly ICoverView _cover;
    
    public MainViewModelFactory(ICoverView coverView, AppSettings appSettings)
    {
        _cover = coverView;
        _appSettings = appSettings;
    }

    public IMainViewModel Create(IMainView mainView)
    {
        return new MainViewModel(new AppearCommand(mainView), new ExitCommand(mainView, _cover), new ChangeOpacityCommand(_cover),
            new LightsConsole(new LightsOutCommand(_cover), new LightsOnCommand(_cover)), _appSettings.Opacity);
    }
}
