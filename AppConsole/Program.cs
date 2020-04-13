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
            CalculatorViewModel viewModel = new CalculatorViewModel { Left = 111, Right = 222, Answer = 333 };
            CalculatorView view = new CalculatorView { DataContext = viewModel };
            Application app = new Application();
            app.Run(view);
        }
    }
}
