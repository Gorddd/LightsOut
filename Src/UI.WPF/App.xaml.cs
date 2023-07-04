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

namespace UI.WPF;

public partial class App : Application
{
    private readonly IHost host;

    public App()
    {
        var builder = Host.CreateDefaultBuilder();

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        var appSettings = config.Get<AppSettings>() ?? throw new InvalidOperationException("You must have appsettings.json file!!!");

        host = builder.ConfigureServices(services =>
        {
            services.AddSingleton(appSettings);
            services.AddSingleton<MainWindow>();
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
