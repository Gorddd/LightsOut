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
using UI.WPF.UIServices;

namespace UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IMainWindowService MainWindowService { get; }

        public MainWindow(IMainWindowService mainWindowService)
        {
            InitializeComponent();

            MainWindowService = mainWindowService;

            DataContext = this;

            ConfigureOptions();
        }

        private void ConfigureOptions()
        {
            MainWindowService.AppearCommand.Appear = () =>
            {
                WindowState = WindowState.Normal;
                Activate();
            };
            MainWindowService.AppearCommand.CanExecuteFunc = obj =>
                WindowState == WindowState.Minimized;
        }
    }
}
