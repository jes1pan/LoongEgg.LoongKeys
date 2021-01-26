using LoongEgg.ViewModelBase;
using System.Windows.Input;

namespace LoongEgg.LoongKeys
{
    class MainContentViewModel : BaseViewModel
    {
        /// <summary>
        /// 按键可用标志
        /// </summary>
        public bool ButtonIsEnabled
        {
            get => _ButtonIsEnabled;
            set => Set(ref _ButtonIsEnabled, value);
        }
        private bool _ButtonIsEnabled;

        /// <summary>
        /// 翻转<see cref="ButtonIsEnabled"/>命令
        /// </summary>
        private RelayCommand _CommandFlipButtonIsEnable;
        public ICommand CommandFlipButtonIsEnable =>
            _CommandFlipButtonIsEnable ?? (_CommandFlipButtonIsEnable = new RelayCommand((e) => ButtonIsEnabled = !ButtonIsEnabled));
    }
}
