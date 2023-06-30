using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.WPF.Commands;
using UI.WPF.Commands.Concrete;

namespace UI.WPF.UIServices;

public interface IMainWindowService
{
    public AppearCommand AppearCommand { get; }
}
