using System;
using System.Windows.Input;

namespace UI.WPF.Commands.Concrete
{
    public class AppearCommand : ICommand
    {
        public Func<object?, bool>? CanExecuteFunc { get; set; }
        public Action? Appear { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return Appear != null && 
                (CanExecuteFunc == null || CanExecuteFunc.Invoke(parameter));
        }

        public void Execute(object? parameter)
        {
            Appear?.Invoke();
        }
    }
}
