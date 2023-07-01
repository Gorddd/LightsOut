using UI.Abstractions.ViewsAbstractions;
using ViewModel.Commands;
using ViewModel.ViewModels;
using ViewModel.ViewModels.Concrete;

namespace UI.WPF.Factories.Concrete;

public class MainViewModelFactory : IMainViewModelFactory
{
    public IMainViewModel Create(IAppearView appearView)
    {
        return new MainViewModel(new AppearCommand(appearView));
    }
}
