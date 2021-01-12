using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoongEgg.ViewModelBase
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 通知前端属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public bool Set<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            //value没有发生变化
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
