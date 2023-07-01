using UI.Abstractions.ViewsAbstractions;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    public IMainViewModel Create(IMainView mainView)
    {
        return new MainViewModel(new AppearCommand(mainView), new ExitCommand(mainView));
    }
}
