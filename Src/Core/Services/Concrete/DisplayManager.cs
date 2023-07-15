using Core.Abstractions;
using Core.Classes;

namespace Core.Services.Concrete;

class DisplayManager : IDisposable
{
    private readonly ICoverFactory _coverFactory;

    record CoverIsCovered(ICover Cover, bool IsCovered);

    private List<CoverIsCovered> _covers = null!;

    public DisplayManager(ICoverFactory coverFactory, IEnumerable<Display> displays)
    {
        _coverFactory = coverFactory;
        InitializeCovers(displays);
    }

    private void InitializeCovers(IEnumerable<Display> displays)
    {
        _covers = new List<CoverIsCovered>();
        foreach (var display in displays)
            _covers.Add(new CoverIsCovered(_coverFactory.Create(display), display.IsCovered!.Value));
    }

    public void UpdateDisplays(IEnumerable<Display> displays)
    {
        InitializeCovers(displays);
    }

    public void CoverDisplays()
    {
        foreach (var cover in _covers)
            if (cover.IsCovered)
                cover.Cover.Appear();
    }

    public void UncoverDisplays()
    {
        foreach (var cover in _covers)
            cover.Cover.Disappear();
    }

    public void ChangeOpacity(double opacity)
    {
        foreach (var cover in _covers)
            cover.Cover.ChangeOpacity(opacity);
    }

    public void Dispose()
    {
        foreach (var cover in _covers)
            cover.Cover.Dispose();
    }
}