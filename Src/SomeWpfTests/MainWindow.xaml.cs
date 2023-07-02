using Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfScreenHelper;

namespace SomeWpfTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Import user32.dll to use the GetWindowLong function
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Constants for window styles
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x00000020;

        public MainWindow()
        {
            InitializeComponent();

            Closed += (object? sender, EventArgs e) =>
            {
                mainWindows.ForEach(w => w.Close());
                Close();
            };
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get the handle of the window
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;

            // Set the window style to allow click-through
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // Handle mouse down event (optional)
            base.OnMouseDown(e);

            if (e.ChangedButton == MouseButton.Left)
            {
                // Perform your desired action when left mouse button is clicked
                // Example: Drag the window
                DragMove();
            }
        }


        private List<MainWindow> mainWindows = new();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScreenEnvironment screenEnvironment = new ScreenEnvironment();

            void ApplySettings(MainWindow mainWindow, Screen screen)
            {
                mainWindow.Left = screen.WpfWorkingArea.Left;
                mainWindow.Top = screen.WpfWorkingArea.Top;
                mainWindow.Width = screen.WpfWorkingArea.Width;
                mainWindow.Height = screen.WpfWorkingArea.Height;
            }

            var allocateNewWindow = false;
            foreach (var screen in screenEnvironment.GetAllScreens())
            {
                if (allocateNewWindow)
                {
                    var newWindow = new MainWindow();

                    mainWindows.Add(newWindow);
                    ApplySettings(newWindow, screen);
                    newWindow.Show();
                }
                else
                {
                    ApplySettings(this, screen);
                    allocateNewWindow = true;
                }
            }
        }
    }
}
