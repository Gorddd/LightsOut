using Core.Classes;
using Environment.Implementations;
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

namespace SomeWpfTests
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DisplayRepository repos = new();

        public Window1()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var actualDisplays = new DisplayProvider().GetAll();

            var storageDisplays = repos.GetAll();
            repos.SaveOrOverwrite(actualDisplays);

            storageDisplays = repos.GetAll();
        }
    }
}
