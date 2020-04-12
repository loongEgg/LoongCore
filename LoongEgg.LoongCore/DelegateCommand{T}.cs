using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/12 18:57:00
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongCore
{
    /// <summary>
    /// 泛型版的<see cref="ICommand"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /*---------------------------------------- Fields ---------------------------------------*/
        /// <summary>
        /// 干活的方法
        /// </summary>
        private readonly Action<T> _Execute;
        /// <summary>
        /// 判断可以干活的方法
        /// </summary>
        private readonly Predicate<T> _CanExecute;
 
        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 主构造器
        /// </summary>
        /// <param name="execute">干活的方法</param>
        /// <param name="canExecute">判断可以干活的方法</param>
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute) {
            _Execute = execute ?? throw new ArgumentNullException("execute 不能为空");
            _CanExecute = canExecute;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="execute">干活的方法</param>
        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged;

        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// 检查是否可以执行命令
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)  => _CanExecute?.Invoke((T)parameter) ?? true;

        /// <summary>
        /// 执行命令操作
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) => _Execute((T)parameter);

        /// <summary>
        /// 引发可执行改变事件
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
