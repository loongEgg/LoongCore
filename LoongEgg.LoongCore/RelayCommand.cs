using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/12 19:00:09
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongCore
{
    /// <summary>
    /// 一个不需要参数的<see cref="ICommand"/>实现
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// 不重要
        /// </summary>
        public event EventHandler CanExecuteChanged ;
        
        /*---------------------------------------- Fields ---------------------------------------*/
        private readonly Action _Execute;
        
        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 一个闷头干活，不需要参数的<see cref="ICommand"/>实现
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action) {
            _Execute = action ?? throw new ArgumentNullException("action");
        }


        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// 永远可以执行
        /// </summary>
        ///     <param name="parameter">不重要</param>
        /// <returns>[一直返回true]</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// 执行指定的工作
        /// </summary>
        /// <param name="parameter">不重要</param>
        public void Execute(object parameter) => _Execute();
    }
}
