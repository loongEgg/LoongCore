using System.Windows;
using System.Windows.Controls;

namespace NoMVVM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            if(e.Source is Button btn) {
                bool isDouble = false;  

                isDouble =  double.TryParse( left.Text, out double leftOpr);
                if (!isDouble) return;

                isDouble =  double.TryParse( right.Text, out double rightOpr);
                if (!isDouble) return;

                string opr = btn.Content.ToString();

                switch (opr) {
                    case "+":answer.Text = (leftOpr + rightOpr).ToString(); break;
                    case "-":answer.Text = (leftOpr - rightOpr).ToString(); break;
                    case "*":answer.Text = (leftOpr * rightOpr).ToString(); break;
                    case "/":answer.Text = (leftOpr / rightOpr).ToString(); break; 
                    default:
                        break;
                }
            }
               
        }
    }
}
