using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoongEgg.ViewModelBase
{
    public class WindowStateManager : _WindowStateManger
    {
        /// <summary>
        ///     负责控制Windows的最大/最小化/还原和关闭窗口
        ///     NOTE: 使用语法
        ///         1.设置父级DataContext="{x:static DemoWindowStateManager.Instance}"
        ///         2.Button的Command="{Binding CommandClose}", CommandParameter="{Binding ElementName=thisWindow}"
        ///         3.thisWindow为要关闭的窗体名字
        ///         4.或者 CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=Window}}"
        /// </summary>
        public static WindowStateManager Instance => _Instance ?? (_Instance = new WindowStateManager());
        private static WindowStateManager _Instance = null;
        public WindowStateManager()
        {
            CommandMinimze = new RelayCommand<Window>((win) => win.WindowState = WindowState.Minimized);
            CommandMaximize = new RelayCommand<Window>((win) => win.WindowState ^= WindowState.Maximized);
            CommandClose = new RelayCommand<Window>((win) => win.Close());
        }
    }

    public abstract class _WindowStateManger
    {
        public ICommand CommandMinimze { get; protected set; }
        public ICommand CommandMaximize { get; protected set; }
        public ICommand CommandClose { get; protected set; }
    }
}
