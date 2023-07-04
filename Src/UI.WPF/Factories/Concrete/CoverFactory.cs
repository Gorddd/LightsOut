using Core.Abstractions;
using Core.Classes;
using UI.WPF.Views;

namespace UI.WPF.Factories.Concrete;

public class CoverFactory : ICoverFactory
{
    public ICover Create(Display display)
    {
        var cover = new Coverlet();

        cover.Left = display.Left;
        cover.Top = display.Top;
        cover.Width = display.Width;
        cover.Height = display.Height;

        return cover;
    }
}
