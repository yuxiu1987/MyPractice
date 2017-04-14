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
using System.ComponentModel;

namespace ReadOnlyPropNotify
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// 对只读属性使用INotifyPropertyChanged接口
    /// 只读属性的return源必须进行侦听，源触发PropertyChanged事件时，只读属性也要触发
    /// 触发点在源的属性设置器中  
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Airliner ar = new Airliner();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ar.Name = "B737";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ar.Name = "B707";
            textblock.DataContext = ar;
        }
    }

    public class Airliner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ReadOnlyName"));
                }                
            }
        }
        private string _Name;

        public string ReadOnlyName
        { get
            {                
                return Name;
            }
        }
    }
}
