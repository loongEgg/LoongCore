using LoongEgg.ViewModels;

namespace LoongEgg.Views
{
    /*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	|
	*/
    public  class CalculatorDesignModel: CalculatorViewModel
    {
        public static CalculatorDesignModel Instance => _Instance ?? (_Instance = new CalculatorDesignModel());
        private static CalculatorDesignModel _Instance;
        public CalculatorDesignModel() : base() {
            Left = 999;
            Right = 666;
            Answer = 233;
        }
    }
}
