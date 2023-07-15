using Core.Abstractions;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace UI.WPF.Views;

public partial class Coverlet : Window, ICover
{
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    // Constants for window styles
    private const int GWL_EXSTYLE = -20;
    private const int WS_EX_TRANSPARENT = 0x00000020;

    private const int HWND_TOPMOST = -1;
    private const int SWP_NOMOVE = 0x0002;
    private const int SWP_NOSIZE = 0x0001;

    public Coverlet(double opacity)
    {
        InitializeComponent();

        ChangeOpacity(opacity);
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);

        // Get the handle of the window
        IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;

        // Set the window style to allow click-through
        int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        // Handle mouse down event (optional)
        base.OnMouseDown(e);

        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    public void Appear()
    {
        Show();
    }

    public void Dispose()
    {
        Close();
    }

    public void ChangeOpacity(double opacity)
    {
        Opacity = opacity / 100;
    }

    public void Disappear()
    {
        Hide();
    }
}
