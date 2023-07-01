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
using System.Windows.Shapes;

namespace UI.WPF.Views;

public partial class Coverlet : Window
{
    // Import user32.dll to use the SetWindowLong function
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    // Import user32.dll to use the GetWindowLong function
    [DllImport("user32.dll")]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    // Constants for window styles
    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TRANSPARENT = 0x00000020;

    public Coverlet()
    {
        InitializeComponent();
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
}
