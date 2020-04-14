using LoongEgg.ViewModels;
using LoongEgg.Views;
using System;
using System.Windows;

namespace AppConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) {

            // TODO: 19-1 初始化ViewModel并注入View
            // 初始化一个ViewModel并设置一些初始值以示和DesignModel不一样
            CalculatorViewModel viewModel = new CalculatorViewModel { Left = 111, Right = 222, Answer = 333 };

            // 将ViewModel赋值给View的DataContext
            CalculatorView view = new CalculatorView { DataContext = viewModel };

            Application app = new Application();
            app.Run(view);
        }
    }
}
