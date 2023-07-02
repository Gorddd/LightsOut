using Core.Classes;

namespace Core.Abstractions;

/// <summary>
/// Displays from storage
/// </summary>
public interface IDisplayRepository
{
    public IEnumerable<Display>? GetAll();

    public void SaveOrOverwrite(IEnumerable<Display> displays);
}
