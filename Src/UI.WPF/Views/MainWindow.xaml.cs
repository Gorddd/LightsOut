using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Factories;

namespace UI.WPF.Views;

public partial class MainWindow : Window, IAppearView
{
    public MainWindow(IMainViewModelFactory viewModelFactory)
    {
        InitializeComponent();

        DataContext = viewModelFactory.Create(this);

        StateChanged += StateChanging;
    }

    public void Appear()
    {
        WindowState = WindowState.Normal;
        Activate();
    }

    public bool CanAppear()
    {
        return WindowState == WindowState.Minimized;
    }

    private void StateChanging(object? sender, EventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            ShowInTaskbar = true;
        }
        if (WindowState == WindowState.Minimized)
        {
            ShowInTaskbar = false;
        }
    }
}
