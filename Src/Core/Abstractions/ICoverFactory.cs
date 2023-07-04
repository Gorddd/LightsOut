using Core.Classes;

namespace Core.Abstractions;

public interface ICoverFactory
{
    public ICover Create(Display display);
}
