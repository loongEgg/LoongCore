using LoongEgg.LoongCore;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoongEgg.ViewModels
{
    // TODO: 18-1 计算器的ViewModel
    /// <summary>
    /// 计算器的ViewModel
    /// </summary>
    public class CalculatorViewModel: BaseViewModel
    {
        /*------------------------------------- Properties --------------------------------------*/
        /// <summary>
        /// 左侧操作数
        /// </summary>
        public int Left {
            get => _Left;
            set => SetProperty(ref _Left, value);
        }
        private int _Left;
         
        /// <summary>
        /// 右侧操作数
        /// </summary>
        public int Right {
            get => _Right;
            set => SetProperty(ref _Right, value);
        }
        private int _Right;

        /// <summary>
        /// 计算结果
        /// </summary>
        public int Answer {
            get => _Answer;
            set => SetProperty(ref _Answer, value);
        }
        private int _Answer;
         
        /// <summary>
        /// 运算命令
        /// </summary>
        public ICommand OperationCommand { get; private set; }

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
        public void Operation(object parameter) {
            string opr = parameter.ToString();

            switch (opr) {
                case "+": Answer = Left + Right; break;
                case "-": Answer = Left - Right; break;
                case "*": Answer = Left * Right; break;
                case "/": Answer = Left / Right; break;
                default:
                    break;
            }
        }
    }
}
