using Core.Abstractions;
using Core.Classes;
using Newtonsoft.Json;

namespace Environment.Implementations;

public class DisplayRepository : IDisplayRepository
{
    private const string _fileName = "displays.json";

    public IEnumerable<Display>? GetAll()
    {
        if (!new FileInfo(_fileName).Exists)
            return null;

        var content = File.ReadAllText(_fileName);

        return JsonConvert.DeserializeObject<IEnumerable<Display>>(content)?.ToList();
    }

    public void SaveOrOverwrite(IEnumerable<Display> displays)
    {
        string content = JsonConvert.SerializeObject(displays);

        File.WriteAllText(_fileName, content);
    }
}
