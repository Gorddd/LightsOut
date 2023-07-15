using ViewModel.Abstractions;

namespace Environment.Implementations;

public class OpacityRepository : IOpacityRepository
{
    private const string _fileName = "opacity.cfg";
    private const double defaultOpacity = 10;

    public double GetOpacity()
    {
        if (!new FileInfo(_fileName).Exists)
            return defaultOpacity;

        var opacity = double.Parse(File.ReadAllText(_fileName));

        return opacity;
    }

    public void SaveOpacity(double opacity)
    {
        File.WriteAllText(_fileName, opacity.ToString());
    }
}
