using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.WPF.Commands;
using UI.WPF.Commands.Concrete;
using UI.WPF.Views;

namespace UI.WPF.UIServices.Concrete;

public class MainWindowService : IMainWindowService
{
    public MainWindowService()
    {
        AppearCommand = new AppearCommand();
    }

    public AppearCommand AppearCommand { get; }
}
