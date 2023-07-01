using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Abstractions.ViewsAbstractions;

public interface IAppearView
{
    public bool CanAppear();
    public void Appear();
}
