using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwoWayBindingSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        Airliner boeing707 = new Airliner { TypeName = "Boeing707", TotalPAX = 189, MAXSpeed = 820 };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //使用赋值运算符将对象绑定到用户控件的Datacontext上
            //对于可以输入的文本框，slider这样的控件来说，绑定模式默认为双向
            this.DataContext = boeing707;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(boeing707.TypeName+" "+boeing707.TotalPAX.ToString()+" "+boeing707.MAXSpeed.ToString());
        }
    }


    public class Airliner
    {
        public string TypeName { get; set; }
        public int TotalPAX { get; set; }
        public int MAXSpeed { get; set; }
    }
}
