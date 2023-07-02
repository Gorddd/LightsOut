using Core.Abstractions;
using Core.Classes;
using WpfScreenHelper;

namespace Environment.Implementations;

public class DisplayProvider : IDisplayProvider
{
    public IEnumerable<Display> GetAll()
    {
        return Screen.AllScreens.Select((screen, index) => new Display
        {
            Name = $"Display {index}",
            Left = screen.WpfWorkingArea.Left,
            Top = screen.WpfWorkingArea.Top,
            Height = screen.WpfWorkingArea.Height,
            Width = screen.WpfWorkingArea.Width,
        });
    }
}
