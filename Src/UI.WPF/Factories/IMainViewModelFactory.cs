using UI.Abstractions.ViewsAbstractions;
using ViewModel.ViewModels;

namespace UI.WPF.Factories;

public interface IMainViewModelFactory
{
    public IMainViewModel Create(IMainView mainView);
}
