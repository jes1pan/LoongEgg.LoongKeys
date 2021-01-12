using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoongEgg.ViewModelBase
{
    public class RelayCommand<T> :ICommand
    {
        public event EventHandler CanExecuteChanged = (s, e) => { };

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExcute = canExecute;
        }

        public bool CanExecute(object parameter)
            => _CanExcute == null ? true : _CanExcute((T)parameter);
        private readonly Func<T, bool> _CanExcute = null;

        public void Execute(object parameter)
            => _Execute((T)parameter);
        private readonly Action<T> _Execute;
    }
}
