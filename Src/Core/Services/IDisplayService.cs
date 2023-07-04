using Core.Classes;

namespace Core.Services;

public interface IDisplayService : IDisposable
{
    public IEnumerable<Display> Displays { get; }

    public void Update();

    public void Cover();

    public void Uncover();

    public void ChangeOpacity(double opacity);
}
