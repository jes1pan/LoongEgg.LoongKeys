using System;
using System.Windows.Input;

namespace LoongEgg.ViewModelBase
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (s, e) => { };

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExcute = canExecute;
        }

        public bool CanExecute(object parameter)
            => _CanExcute == null ? true : _CanExcute(parameter);
        private readonly Func<object, bool> _CanExcute = null;

        public void Execute(object parameter)
            => _Execute(parameter);
        private readonly Action<object> _Execute;
    }
}
