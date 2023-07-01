using System.Windows.Input;

namespace ViewModel.ViewModels;

public interface IMainViewModel
{
    public ICommand AppearCommand { get; }
}
