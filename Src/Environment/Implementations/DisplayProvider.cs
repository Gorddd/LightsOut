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
            Left = screen.Bounds.Left,
            Top = screen.Bounds.Top,
            Height = screen.Bounds.Height,
            Width = screen.Bounds.Width,
        }).ToList();
    }
}
