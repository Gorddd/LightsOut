using Core.Abstractions;
using Core.Classes;
using Environment.Implementations;
using UI.WPF.Views;
using ViewModel.Abstractions;

namespace UI.WPF.Factories.Concrete;

public class CoverFactory : ICoverFactory
{
    private readonly IOpacityRepository _opacityRepository;

    public CoverFactory(IOpacityRepository opacityRepository)
    {
        _opacityRepository = opacityRepository;
    }

    public ICover Create(Display display)
    {
        var cover = new Coverlet(_opacityRepository.GetOpacity());

        cover.Left = display.Left;
        cover.Top = display.Top;
        cover.Width = display.Width;
        cover.Height = display.Height;

        return cover;
    }
}
