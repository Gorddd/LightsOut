using Core.Classes;

namespace Core.Services;

public interface IDisplayService : IDisposable
{
    public IEnumerable<Display> Displays { get; }

    public void Cover();

    public void Uncover();

    public void UpdateDisplay(Display display);

    public void ChangeOpacity(double opacity);
}
