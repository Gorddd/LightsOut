using Core.Abstractions;
using Core.Classes;

namespace Core.Services.Concrete;

class DisplayManager : IDisposable
{
    private readonly ICoverFactory _coverFactory;

    record CoverAndDisplay(ICover Cover, Display Display);

    private List<CoverAndDisplay> _coverDisplays = null!;

    public DisplayManager(ICoverFactory coverFactory, IEnumerable<Display> displays)
    {
        _coverFactory = coverFactory;
        InitializeCovers(displays);
    }

    private void InitializeCovers(IEnumerable<Display> displays)
    {
        _coverDisplays = new List<CoverAndDisplay>();
        foreach (var display in displays)
            _coverDisplays.Add(new CoverAndDisplay(_coverFactory.Create(display), display));
    }

    public void CoverDisplays()
    {
        foreach (var coverDisplay in _coverDisplays)
            if (coverDisplay.Display.IsCovered!.Value)
                coverDisplay.Cover.Appear();
    }

    public void UpdateDisplay(Display display)
    {
        var displayToUpdate = _coverDisplays.First(cd => cd.Display.Equals(display));

        if (displayToUpdate.Display.IsCovered!.Value)
            displayToUpdate.Cover.Appear();
        else
            displayToUpdate.Cover.Disappear();
    }

    public void UncoverDisplays()
    {
        foreach (var coverDisplay in _coverDisplays)
            coverDisplay.Cover.Disappear();
    }

    public void ChangeOpacity(double opacity)
    {
        foreach (var coverDisplay in _coverDisplays)
            coverDisplay.Cover.ChangeOpacity(opacity);
    }

    public void Dispose()
    {
        foreach (var coverDisplay in _coverDisplays)
            coverDisplay.Cover.Dispose();
    }
}