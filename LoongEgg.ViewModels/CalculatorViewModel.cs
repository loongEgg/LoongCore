using LoongEgg.LoongCore;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoongEgg.ViewModels
{
    // TODO: 18-1 计算器的ViewModel
    /// <summary>
    /// 计算器的ViewModel
    /// </summary>
    public class CalculatorViewModel: ViewModelBase
    {
        /*------------------------------------- Properties --------------------------------------*/        /// <summary>
        /// 左侧操作数
        /// </summary>
        public int Left {
            get => _Left;
            set => SetProperty(ref _Left, value);
        }
        protected int _Left;
         
        /// <summary>
        /// 右侧操作数
        /// </summary>
        public int Right {
            get => _Right;
            set => SetProperty(ref _Right, value);
        }
        protected int _Right;
         
        /// <summary>
        /// 计算结果
        /// </summary>
        public int Answer {
            get => _Answer;
            set => SetProperty(ref _Answer, value);
        }
        protected int _Answer;

        /// <summary>
        /// 运算命令
        /// </summary>
        public ICommand OperationCommand { get; protected set; }

        /*------------------------------------- Constructor -------------------------------------*/
        /// <summary>
        /// 默认构造器
        /// </summary>
        public CalculatorViewModel() {
            OperationCommand = new DelegateCommand(Operation);
        }

        /*----------------------------------- Private Methods -----------------------------------*/ 
        /// <summary>
        /// 运算的具体执行方法
        /// </summary>
        /// <param name="opr"></param>
        protected void Operation(object opr) {
            var self = opr as Button;
            switch (opr.ToString()) {
                case "+": Answer = Left + Right; break;
                case "-": Answer = Left - Right; break;
                case "*": Answer = Left * Right; break;
                case "/": Answer = Left / Right; break;
            };
        }
 
    }
}
