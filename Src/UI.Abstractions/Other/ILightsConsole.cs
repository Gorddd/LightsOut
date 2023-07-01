using System.Windows.Input;

namespace UI.Abstractions.Other;

public interface ILightsConsole
{
    public ICommand LightsOutCommand { get; }
    public ICommand LightsOnCommand { get; }
}
