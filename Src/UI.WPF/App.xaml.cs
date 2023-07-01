using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.WPF.Factories;
using UI.WPF.Factories.Concrete;
using UI.WPF.Views;

namespace UI.WPF;

public partial class App : Application
{
    private readonly IHost host;

    public App()
    {
        var builder = Host.CreateDefaultBuilder();

        host = builder.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<IMainViewModelFactory, MainViewModelFactory>();
        }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        host.Start();

        MainWindow = host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        host.StopAsync();
        host.Dispose();

        base.OnExit(e);
    }
}
