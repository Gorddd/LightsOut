using Core.Classes;

namespace Core.Services;

public interface IDisplayService
{
    public IEnumerable<Display> GetDisplays();
}
