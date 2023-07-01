using System.Windows.Input;
using UI.Abstractions.Other;
using UI.Abstractions.ViewsAbstractions;

namespace ViewModel.Commands;

public class LightsConsole : ILightsConsole
{
    public LightsConsole(ICommand lightsOut, ICommand lightsOn)
    {
        LightsOutCommand = lightsOut;
        LightsOnCommand = lightsOn;
    }

    public ICommand LightsOutCommand { get; }

    public ICommand LightsOnCommand { get; }
}
