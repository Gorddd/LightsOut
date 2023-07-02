using Core.Classes;

namespace Core.Abstractions;

/// <summary>
/// Actual displays from OS
/// </summary>
public interface IDisplayProvider
{
    public IEnumerable<Display> GetAll();
}
