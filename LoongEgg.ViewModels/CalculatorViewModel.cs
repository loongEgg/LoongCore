using LoongEgg.LoongCore;
using System.Windows.Controls;
using System.Windows.Input;

namespace LoongEgg.ViewModels
{
    public class CalculatorViewModel: ViewModelBase
    {
        
        public int Left {
            get => _Left;
            set => SetProperty(ref _Left, value);
        }
        protected int _Left;
         
        public int Right {
            get => _Right;
            set => SetProperty(ref _Right, value);
        }
        protected int _Right;
         
        public int Answer {
            get => _Answer;
            set => SetProperty(ref _Answer, value);
        }
        protected int _Answer;

        public ICommand OperationCommand { get; protected set; }

        public CalculatorViewModel() {
            OperationCommand = new DelegateCommand(Operation);
        }

        protected void Operation(object opr) {
            var self = opr as Button;
            switch (opr.ToString()) {
                case "+": Answer = Left + Right; break;
                case "-": Answer = Left - Right; break;
                case "*": Answer = Left * Right; break;
                case "/": Answer = Left / Right; break;
            };
        }
        /*--------------------------------------- Fields ----------------------------------------*/

        /*------------------------------------- Properties --------------------------------------*/

        /*-------------------------------- Dependency Properties --------------------------------*/

        /*------------------------------------- Constructor -------------------------------------*/

        /*------------------------------------ Public Methods -----------------------------------*/

        /*----------------------------------- Private Methods -----------------------------------*/
    }
}
