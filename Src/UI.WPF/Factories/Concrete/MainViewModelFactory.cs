using UI.Abstractions.ViewsAbstractions;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    private readonly ICoverView _cover;
    
    public MainViewModelFactory(ICoverView coverView)
    {
        _cover = coverView;
    }

    public IMainViewModel Create(IMainView mainView)
    {
        return new MainViewModel(new AppearCommand(mainView), new ExitCommand(mainView, _cover), 
            new LightsConsole(new LightsOutCommand(_cover), new LightsOnCommand(_cover)));
    }
}
