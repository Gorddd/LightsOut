using Core.Abstractions;
using Core.Classes;

namespace Core.Services.Concrete;

class DisplayManager : IDisposable
{
    private readonly ICoverFactory _coverFactory;

    private List<ICover> _covers = null!;

    public DisplayManager(ICoverFactory coverFactory, IEnumerable<Display> displays)
    {
        _coverFactory = coverFactory;
        InitializeCovers(displays);
    }

    private void InitializeCovers(IEnumerable<Display> displays)
    {
        _covers = new List<ICover>();
        foreach (var display in displays)
            _covers.Add(_coverFactory.Create(display));
    }

    public void UpdateDisplays(IEnumerable<Display> displays)
    {
        InitializeCovers(displays);
    }

    public void CoverDisplays()
    {
        foreach (var cover in _covers)
            cover.Appear();
    }

    public void UncoverDisplays()
    {
        foreach (var cover in _covers)
            cover.Disappear();
    }

    public void ChangeOpacity(double opacity)
    {
        foreach (var cover in _covers)
            cover.ChangeOpacity(opacity);
    }

    public void Dispose()
    {
        foreach (var cover in _covers)
            cover.Dispose();
    }
}
