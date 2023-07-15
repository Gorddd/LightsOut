using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.Abstractions.ViewsAbstractions;
using UI.WPF.Factories;
using UI.WPF.Factories.Concrete;
using UI.WPF.Views;
using UI.WPF.Configs;
using Core.Services;
using Core.Services.Concrete;
using Core.Abstractions;
using Environment.Implementations;
using ViewModel.Abstractions;

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
            services.AddTransient<IOpacityRepository, OpacityRepository>();
            services.AddTransient<IMainViewModelFactory, MainViewModelFactory>();
            services.AddTransient<IDisplayService, DisplayService>();
            services.AddTransient<IDisplayRepository, DisplayRepository>();
            services.AddTransient<IDisplayProvider, DisplayProvider>();
            services.AddTransient<ICoverFactory, CoverFactory>();
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
