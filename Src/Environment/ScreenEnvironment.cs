using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfScreenHelper;

namespace Environment;

public class ScreenEnvironment
{
    public IEnumerable<Screen> GetAllScreens()
    {
        return Screen.AllScreens;
    }
}
