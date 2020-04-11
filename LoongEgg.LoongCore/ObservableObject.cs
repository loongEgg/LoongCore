using System.ComponentModel;

namespace LoongEgg.LoongCore
{
    /*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	|
	*/
    public  class ObservableObject : INotifyPropertyChanged
    {
        /*--------------------------------------- Fields ----------------------------------------*/

        /*------------------------------------- Properties --------------------------------------*/

        /*-------------------------------- Dependency Properties --------------------------------*/

        /*------------------------------------- Constructor -------------------------------------*/

        /*------------------------------------ Public Methods -----------------------------------*/

        /*----------------------------------- Private Methods -----------------------------------*/
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
