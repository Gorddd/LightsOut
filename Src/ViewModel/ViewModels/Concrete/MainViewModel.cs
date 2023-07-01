using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.ViewModels.Concrete;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public MainViewModel(ICommand appearCommand)
    {
        AppearCommand = appearCommand;
    }

    public ICommand AppearCommand { get; }
}
