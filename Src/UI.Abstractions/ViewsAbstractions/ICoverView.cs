namespace UI.Abstractions.ViewsAbstractions;

public interface ICoverView : IAppearView, IExitView
{
    public void Hide();

    public void ChangeOpacity(double opacity);
}
