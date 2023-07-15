using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Abstractions;

public interface IOpacityRepository
{
    public double GetOpacity();

    public void SaveOpacity(double opacity);
}
