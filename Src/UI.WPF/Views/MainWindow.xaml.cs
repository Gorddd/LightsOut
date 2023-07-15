using System;
using System.Windows;
using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Factories;

namespace UI.WPF.Views;

public partial class MainWindow : Window, IMainView
{
    public MainWindow(IMainViewModelFactory viewModelFactory)
    {
        InitializeComponent();

        DataContext = viewModelFactory.Create(this);
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

    public void Exit()
    {
        Close();
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
