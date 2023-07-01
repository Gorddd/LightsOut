using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.ViewModels.Concrete;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public MainViewModel(ICommand appearCommand, ICommand exitCommand)
    {
        AppearCommand = appearCommand;
        ExitCommand = exitCommand;
    }

    public ICommand AppearCommand { get; }

    public ICommand ExitCommand { get; }
}
