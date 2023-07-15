using Core.Abstractions;
using Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concrete;

public class DisplayService : IDisplayService
{
    private readonly IDisplayProvider _displayProvider;
    private readonly IDisplayRepository _repository;
    private IEnumerable<Display> _workingDisplays;

    private readonly DisplayManager _displayManager;

    public IEnumerable<Display> Displays => _workingDisplays.ToList();

    public DisplayService(IDisplayProvider displayProvider, IDisplayRepository displayRepository, ICoverFactory coverFactory)
    {
        _displayProvider = displayProvider;
        _repository = displayRepository;
        _workingDisplays = GetOrUpdateDisplays();
        _displayManager = new DisplayManager(coverFactory, _workingDisplays);
    }

    private IEnumerable<Display> GetOrUpdateDisplays()
    {
        void InitializeActualDisplays(IEnumerable<Display> actualDisplays)
        {
            actualDisplays.Single(d => d.Name == "Display 0").IsCovered = true;

            foreach (var display in actualDisplays)
                if (display.IsCovered == null)
                    display.IsCovered = false;
        }

        var storageDisplays = _repository.GetAll();
        if (storageDisplays == null) // First run or lost data
        {
            var actualDisplays = _displayProvider.GetAll();
            InitializeActualDisplays(actualDisplays);

            _repository.SaveOrOverwrite(actualDisplays);
            return actualDisplays;
        }
        else // Already saved something
        {
            var actualDisplays = _displayProvider.GetAll();

            var hasAnyDiff = storageDisplays
                .Join(actualDisplays,
                    s => s.Name,
                    a => a.Name,
                    (s, a) => new { Storage = s, Actual = a })
                .Any(sa => !sa.Storage.Equals(sa.Actual));

            if (hasAnyDiff)
            {
                InitializeActualDisplays(actualDisplays);

                _repository.SaveOrOverwrite(actualDisplays);
                return actualDisplays;
            }
            return storageDisplays;
        }
    }

    public void Update()
    {
        _workingDisplays = GetOrUpdateDisplays();
        _displayManager.UpdateDisplays(_workingDisplays);
    }

    public void Cover()
    {
        _displayManager.CoverDisplays();
    }

    public void Uncover()
    {
        _displayManager.UncoverDisplays();
    }

    public void ChangeOpacity(double opacity)
    {
        _displayManager.ChangeOpacity(opacity);
    }

    public void Dispose()
    {
        //add save working displays

        _displayManager.Dispose();
    }
}
