using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Abstractions.ViewsAbstractions;
using ViewModel.ViewModels;

namespace UI.WPF.Factories;

public interface IMainViewModelFactory
{
    public IMainViewModel Create(IAppearView appearView);
}
