namespace Core.Abstractions;

public interface ICover : IDisposable
{
    public void Appear();

    public void Disappear();

    public void ChangeOpacity(double opacity);
}
